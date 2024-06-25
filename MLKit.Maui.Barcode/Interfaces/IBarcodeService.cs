namespace MLKit.Maui.Barcode;

/// <summary>
/// Google ML Kit Barcode Services
/// </summary>
public interface IBarcodeService
{
    /// <summary>
    /// Sets the barcode formats to be recognized by the BarcodeService.
    /// </summary>
    void SetBarcodeFormats(params BarcodeFormat[] barcodeFormats);

    /// <summary>
    /// Scans an image for barcodes.
    /// </summary>
    /// <param name="imageFile">The image to get barcodes from</param>
    /// <returns>A list of BarcodeResults found in the image</returns>
    /// <remarks>This will recognize no more than 10 barcodes per image.</remarks>
    Task<List<BarcodeResult>> GetBarcodesFromImage(FileResult imageFile);

    /// <summary>
    /// Scans an image for barcodes.
    /// </summary>
    /// <param name="imageBytes">The image bytes</param>
    /// <returns>A list of BarcodeResults found in the image</returns>
    /// <remarks>This will recognize no more than 10 barcodes per image.</remarks>
    Task<List<BarcodeResult>> GetBarcodesFromImage(byte[] imageBytes);
}
