using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using MLKit.Maui.Barcode;

namespace Example.App;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder()
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .RegisterViewModelsAndViews();

        builder.Services.AddBarcodeService();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }

    private static MauiAppBuilder RegisterViewModelsAndViews(this MauiAppBuilder builder)
    {
        builder.Services.AddSingleton<BarcodeExampleViewModel>();
        builder.Services.AddSingleton<BarcodeExampleView>();

        return builder;
    }
}
