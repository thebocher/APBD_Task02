namespace APBD_Task02;

public class DeviceNotFound : Exception
{
    public DeviceNotFound() : base("Device not found") { }
}