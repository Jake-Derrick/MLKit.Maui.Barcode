# MLKit.Maui.Barcode
Provides easier access to Google ML Kits Barcode Scanning API for .NET MAUI.

![BarcodeDetection](https://github.com/Jake-Derrick/MLKit.Maui.Barcode/assets/60721064/5c0b0ec6-f220-4b83-9c33-a82e206e9591)

## How to use it?
1. Install the [NuGet package](https://www.nuget.org/packages/MLKit.Maui.Barcode/)
```
Install-Package MLKit.Maui.Barcode
```
2. Initialize Barcode Service in `MauiProgram.cs`. See [Supported formats](#supported-barcode-formats)
```csharp
var builder = MauiApp.CreateBuilder()
    .UseMauiApp<App>()

builder.Services.AddBarcodeService(BarcodeFormat.Code_128, BarcodeFormat.QR, BarcodeFormat.PDF_417);
```
3. Use service to get barcodes from a FileResult or an image byte[]
```csharp
private readonly IBarcodeService _barcodeService;

public BarcodeExampleViewModel(IBarcodeService barcodeService)
{
    _barcodeService = barcodeService;
}

public async List<BarcodeResult> GetBarcodes(FileResult imageFile)
{
    List<BarcodeResult> barcodeResults = await _barcodeService.GetBarcodesFromImage(imageFile);
}

public async List<BarcodeResult> GetBarcodes(byte[] imageBytes)
{
    List<BarcodeResult> barcodeResults = await _barcodeService.GetBarcodesFromImage(imageBytes);
}
```

## Supported Barcode Formats
* Code_128
* Code_39
* Code_93
* Codabar
* EAN_13
* EAN_8
* ITF
* UPC_A
* UPC_E
* QR
* PDF_417
* Aztec
* DataMatrix

Detected Formats can be dynamically changed by using SetBarcodeFormats.
```csharp
_barcodeService.SetBarcodeFormats(BarcodeFormat.All);
```
