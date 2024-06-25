using CommunityToolkit.Mvvm.ComponentModel;
using MLKit.Maui.Barcode;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace Example.App;

public partial class BarcodeExampleViewModel : ObservableObject, INotifyPropertyChanged
{
    private readonly IBarcodeService _barcodeService;
    public ICommand SelectImageCommand { get; protected set; }

    [ObservableProperty]
    private ObservableCollection<BarcodeResult> _barcodeResults = [];

    [ObservableProperty]
    private ImageSource _imageSource;

    [ObservableProperty]
    private string _errorMessage;

    public BarcodeExampleViewModel(IBarcodeService barcodeService)
    {
        _barcodeService = barcodeService;
        SelectImageCommand = new Command(SelectImageClicked);

    }

    private async void SelectImageClicked()
    {
        ClearPrevious();

        var file = await GetImageFromStorage();
        if (file is null)
            return;

        var result = await _barcodeService.GetBarcodesFromImage(file);
        if (result is null or [])
        {
            ErrorMessage = "Failed to parse any barcodes";
            return;
        }

        foreach (var barcodeResult in result)
            BarcodeResults.Add(barcodeResult);
    }

    private async Task<FileResult?> GetImageFromStorage()
    {
        var storageReadPermission = await RequestStorageReadPermission();
        if (storageReadPermission is not PermissionStatus.Granted)
            return null;

        var file = await MediaPicker.PickPhotoAsync();
        if (file is not null)
            ImageSource = ImageSource.FromFile(file?.FullPath);

        return file;
    }

    private async Task<PermissionStatus> RequestStorageReadPermission()
    {
        var status = await Permissions.CheckStatusAsync<Permissions.StorageRead>();
        if (status is not PermissionStatus.Granted)
            status = await Permissions.RequestAsync<Permissions.StorageRead>();

        if (status is not PermissionStatus.Granted)
            ErrorMessage = "Storage Read permission is required for selecting an image";

        return status;
    }

    private void ClearPrevious()
    {
        ImageSource = "";
        ErrorMessage = "";
        BarcodeResults.Clear();
    }
}
