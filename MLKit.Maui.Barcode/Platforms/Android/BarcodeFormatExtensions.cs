using AndroidBarcode = Xamarin.Google.MLKit.Vision.Barcode.Common.Barcode;

namespace MLKit.Maui.Barcode;

/// <summary>
/// Android extensions for <see cref="BarcodeFormat"/>
/// </summary>
public static class BarcodeFormatExtensions
{
    public static int[] ToAndroidFormat(this BarcodeFormat[] formats)
    {
        if (formats.Length == 0)
            return [AndroidBarcode.FormatAllFormats];

        var result = new List<int>();
        foreach (BarcodeFormat format in formats)
            result.Add(format.ToAndroidFormat());

        return result.ToArray();
    }

    public static int ToAndroidFormat(this BarcodeFormat format)
    {
        return format switch
        {
            BarcodeFormat.Code_128 => AndroidBarcode.FormatCode128,
            BarcodeFormat.Code_39 => AndroidBarcode.FormatCode39,
            BarcodeFormat.Code_93 => AndroidBarcode.FormatCode93,
            BarcodeFormat.Codabar => AndroidBarcode.FormatCodabar,
            BarcodeFormat.EAN_13 => AndroidBarcode.FormatEan13,
            BarcodeFormat.EAN_8 => AndroidBarcode.FormatEan8,
            BarcodeFormat.ITF => AndroidBarcode.FormatItf,
            BarcodeFormat.UPC_A => AndroidBarcode.FormatUpcA,
            BarcodeFormat.UPC_E => AndroidBarcode.FormatUpcE,
            BarcodeFormat.QR => AndroidBarcode.FormatQrCode,
            BarcodeFormat.PDF_417 => AndroidBarcode.FormatPdf417,
            BarcodeFormat.Aztec => AndroidBarcode.FormatAztec,
            BarcodeFormat.DataMatrix => AndroidBarcode.FormatDataMatrix,
            BarcodeFormat.All => AndroidBarcode.FormatAllFormats,
            _ => (int)BarcodeFormat.Unknown
        };
    }

    public static BarcodeFormat ToMauiFormat(this AndroidBarcode androidBarcode) => ToMauiFormat(androidBarcode.Format);

    private static BarcodeFormat ToMauiFormat(int androidFormat)
    {
        return androidFormat switch
        {
            AndroidBarcode.FormatCode128 => BarcodeFormat.Code_128,
            AndroidBarcode.FormatCode39 => BarcodeFormat.Code_39,
            AndroidBarcode.FormatCode93 => BarcodeFormat.Code_93,
            AndroidBarcode.FormatCodabar => BarcodeFormat.Codabar,
            AndroidBarcode.FormatEan13 => BarcodeFormat.EAN_13,
            AndroidBarcode.FormatEan8 => BarcodeFormat.EAN_8,
            AndroidBarcode.FormatItf => BarcodeFormat.ITF,
            AndroidBarcode.FormatUpcA => BarcodeFormat.UPC_A,
            AndroidBarcode.FormatUpcE => BarcodeFormat.UPC_E,
            AndroidBarcode.FormatQrCode => BarcodeFormat.QR,
            AndroidBarcode.FormatPdf417 => BarcodeFormat.PDF_417,
            AndroidBarcode.FormatAztec => BarcodeFormat.Aztec,
            AndroidBarcode.FormatDataMatrix => BarcodeFormat.DataMatrix,
            AndroidBarcode.FormatAllFormats => BarcodeFormat.All,
            _ => BarcodeFormat.Unknown
        };
    }
}