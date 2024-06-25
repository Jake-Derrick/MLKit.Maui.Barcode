namespace Example.App;

public partial class BarcodeExampleView : ContentPage
{
    public BarcodeExampleView(BarcodeExampleViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

}
