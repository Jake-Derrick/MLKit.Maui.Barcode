using Android.Gms.Extensions;
using Android.Graphics;
using Android.Runtime;
using Java.Util;
using Xamarin.Google.MLKit.Vision.BarCode;
using Xamarin.Google.MLKit.Vision.Common;
using AndroidBarcode = Xamarin.Google.MLKit.Vision.Barcode.Common.Barcode;

namespace MLKit.Maui.Barcode;

/// <summary>
/// Android implementation of <see cref="IBarcodeService"/>
/// </summary>
public class BarcodeService : IBarcodeService
{
    private int[] _barcodeFormats;

    public BarcodeService(BarcodeFormat[] barcodeFormats)
    {
        SetBarcodeFormats(barcodeFormats);
    }

    /// <inheritdoc />
    public void SetBarcodeFormats(params BarcodeFormat[] barcodeFormats)
    {
        _barcodeFormats = barcodeFormats.ToAndroidFormat();
    }

    /// <inheritdoc />
    public async Task<List<BarcodeResult>> GetBarcodesFromImage(FileResult imageFile)
    {
        using var stream = await imageFile.OpenReadAsync();
        using var bitmap = BitmapFactory.DecodeStream(stream);

        return await GetBarcodesFromBitmap(bitmap);
    }

    /// <inheritdoc />
    public async Task<List<BarcodeResult>> GetBarcodesFromImage(byte[] imageBytes)
    {
        using var bitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
        return await GetBarcodesFromBitmap(bitmap);
    }

    private async Task<List<BarcodeResult>> GetBarcodesFromBitmap(Bitmap? bitmap)
    {
        if (bitmap is null)
            return [];

        using var image = InputImage.FromBitmap(bitmap, 0);

        var scanner = BarcodeScanning.GetClient(new BarcodeScannerOptions.Builder().SetBarcodeFormats(_barcodeFormats[0], _barcodeFormats.Skip(1).ToArray()).Build());

        var barcodes = await scanner.Process(image);
        if (barcodes is null)
            return [];

        var javaList = barcodes.JavaCast<ArrayList>();
        if (javaList is null)
            return [];

        return ConvertToBarcodeResults(javaList);
    }

    private static List<BarcodeResult> ConvertToBarcodeResults(ArrayList barcodes)
    {
        var barcodeResults = new List<BarcodeResult>();

        foreach (var barcodeObj in barcodes.ToArray())
        {
            var barcode = barcodeObj.JavaCast<AndroidBarcode>();

            var bounds = barcode.BoundingBox;
            var mauiBounds = new Microsoft.Maui.Graphics.Rect(bounds.Left, bounds.Top, bounds.Width(), bounds.Height());

            List<Microsoft.Maui.Graphics.Point> cornerPoints = [];
            foreach (var cornerPoint in barcode.GetCornerPoints())
                cornerPoints.Add(new Microsoft.Maui.Graphics.Point(cornerPoint.X, cornerPoint.Y));

            barcodeResults.Add(new(barcode.DisplayValue, barcode.RawValue, barcode.GetRawBytes(), mauiBounds, cornerPoints, barcode.ToMauiFormat()));
        }

        return barcodeResults;
    }
}