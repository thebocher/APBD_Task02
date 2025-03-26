namespace APBD_Task02;

public interface IDeviceManager : IDeviceModification, IDeviceTurnOnAndOff, IDeviceSearching
{
    public void ShowAllDevices();
}