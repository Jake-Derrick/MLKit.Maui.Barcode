namespace MLKit.Maui.Barcode;

/// <summary>
/// Extension methods for <see cref="IServiceCollection"/>
/// </summary>
public static class IServiceCollectionExtensions
{
    /// <summary>
    /// Adds the BarcodeService to the service collection as a singleton.
    /// </summary>
    public static IServiceCollection AddBarcodeService(this IServiceCollection services, params BarcodeFormat[] formats)
    {
        services.AddSingleton<IBarcodeService>(new BarcodeService(formats));
        return services;
    }
}
