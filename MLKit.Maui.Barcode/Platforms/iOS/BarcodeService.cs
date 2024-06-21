
namespace MLKit.Maui.Barcode;

public class BarcodeService : IBarcodeService
{
    public Task<List<BarcodeResult>> GetBarcodesFromImage(FileResult imageFile)
    {
        throw new NotImplementedException();
    }

    public Task<List<BarcodeResult>> GetBarcodesFromImage(byte[] imageBytes)
    {
        throw new NotImplementedException();
    }
}
