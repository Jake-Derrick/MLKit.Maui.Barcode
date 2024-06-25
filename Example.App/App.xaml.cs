namespace Example.App;

public partial class App : Application
{
    public App(IServiceProvider serviceProvider)
    {
        InitializeComponent();

        MainPage = new NavigationPage(serviceProvider.GetRequiredService<BarcodeExampleView>());
    }
}
