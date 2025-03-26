namespace APBD_Task02;

public class DeviceNotFoundException : Exception
{
    public DeviceNotFoundException() : base("Device not found") { }
}