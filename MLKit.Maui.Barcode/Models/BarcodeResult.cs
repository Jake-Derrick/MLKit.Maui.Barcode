namespace MLKit.Maui.Barcode;

public record BarcodeResult(string DisplayValue, string RawValue, byte[] RawBytes, Rect BoundingBox, List<Point> CornerPoints, BarcodeFormat Format);
