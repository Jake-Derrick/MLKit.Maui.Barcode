namespace MLKit.Maui.Barcode;

/// <summary>
/// Helper methods for <see cref="Permissions"/>
/// </summary>
public class PermissionHelpers
{
    /// <summary>
    /// Requests the necessary permissions for <see cref="IBarcodeService"/>
    /// </summary>
    /// <remarks>Required Permissions: <see cref="Permissions.StorageRead"/></remarks>
    public static async Task<PermissionStatus> RequestBarcodeServicePermissions()
    {
        var status = await Permissions.CheckStatusAsync<Permissions.StorageRead>();
        if (status != PermissionStatus.Granted)
            status = await Permissions.RequestAsync<Permissions.StorageRead>();

        return status;
    }
}
