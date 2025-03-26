namespace APBD_Task02;

public class DeviceManagerFactory
{
    public static IDeviceManager GetFileDeviceManager(string filePath)
    {
        return new FileDeviceManager(filePath);
    }
}