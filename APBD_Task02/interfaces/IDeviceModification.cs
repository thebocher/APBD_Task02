namespace APBD_Task02;

public interface IDeviceModification
{
    public void AddDevice(Device device);
    public void RemoveDevice(string deviceId);
    public void EditDeviceData(String deviceId, Device data);
    public void SaveData();
}