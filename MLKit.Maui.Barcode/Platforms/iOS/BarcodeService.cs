
namespace MLKit.Maui.Barcode;

public class BarcodeService : IBarcodeService
{
    public BarcodeService(BarcodeFormat[] barcodeFormats) { }

    public void SetBarcodeFormats(params BarcodeFormat[] barcodeFormats)
    {
        throw new NotImplementedException();
    }

    public Task<List<BarcodeResult>> GetBarcodesFromImage(FileResult imageFile)
    {
        throw new NotImplementedException();
    }

    public Task<List<BarcodeResult>> GetBarcodesFromImage(byte[] imageBytes)
    {
        throw new NotImplementedException();
    }

}
