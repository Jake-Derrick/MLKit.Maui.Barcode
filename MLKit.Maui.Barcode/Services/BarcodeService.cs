
namespace MLKit.Maui.Barcode;
#if !ANDROID && !IOS
// See the Platforms folder for the device specific implementation of this service.
/// <summary>
/// The plain .Net implementation of <see cref="IBarcodeService"/>.
/// </summary>
public class BarcodeService : IBarcodeService
{
    public BarcodeService(BarcodeFormat[] barcodeFormats) { }
    public Task<List<BarcodeResult>> GetBarcodesFromImage(FileResult imageFile) => throw new NotImplementedException();
    public Task<List<BarcodeResult>> GetBarcodesFromImage(byte[] imageBytes) => throw new NotImplementedException();
    public void SetBarcodeFormats(params BarcodeFormat[] barcodeFormats) => throw new NotImplementedException();
}
#endif
