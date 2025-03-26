namespace APBD_Task02;

public class FileDeviceManager : IDeviceManager
{
    private List<Device> _devices;
    private readonly string _filePath;
    
    public FileDeviceManager(string filePath)
    {
        _filePath = filePath;
        
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException("File does not exist");
        }

        _devices = CsvDeviceFileParser.Parse(filePath);
    }

    public void AddDevice(Device device)
    {
        _devices.Add(device);
    }

    public void RemoveDevice(string deviceId)
    {
        Device device = GetDeviceById(deviceId);
        _devices.Remove(device);
    }

    public void EditDeviceData(String deviceId, Device data)
    {
        Device device = GetDeviceById(deviceId);
        
        if (device.GetType() != data.GetType())
            throw new InvalidCastException();

        if (device is SmartWatch)
        {
            SmartWatch smartWatch = (SmartWatch)device;
            SmartWatch smartWatch2 = (SmartWatch)data;
            
            smartWatch.Name = smartWatch2.Name;
            smartWatch.TurnedOn = smartWatch2.TurnedOn;
            smartWatch.BatteryPercentage = smartWatch2.BatteryPercentage;
        } else if (device is PersonalComputer)
        {
            PersonalComputer personalComputer = (PersonalComputer)device;
            PersonalComputer personalComputer2 = (PersonalComputer)data;
            
            personalComputer.Name = personalComputer2.Name;
            personalComputer.TurnedOn = personalComputer2.TurnedOn;
            personalComputer.OperationalSystem = personalComputer2.OperationalSystem;
        } else if (device is EmbeddedDevice)
        {
            EmbeddedDevice ede = (EmbeddedDevice)device;
            EmbeddedDevice ede2 = (EmbeddedDevice)data;
            
            ede.Name = ede2.Name;
            ede.TurnedOn = ede2.TurnedOn;
            ede2.TurnedOn = ede2.TurnedOn;
            ede2.IpAddress = ede2.IpAddress;
            ede2.NetworkName = ede2.NetworkName;
        } else
        {
            throw new ArgumentException();
        }
    }

    public void TurnOnDevice(string deviceId)
    {
        Device device = GetDeviceById(deviceId);
        device.TurnOn();
    }

    public void TurnOffDevice(string deviceId)
    {
        GetDeviceById(deviceId).TurnOff();
    }

    public void ShowAllDevices()
    {
        foreach (var device in _devices)
        {
            Console.WriteLine(device);
        }
    }

    public Device GetDeviceById(string deviceId)
    {
        foreach (var device in _devices)
        {
            if (device.Id == deviceId) return device;
        }
        
        throw new DeviceNotFoundException();
    }

    public void SaveData()
    {
        string newData = "";

        foreach (var device in _devices)
        {
            newData += device.ToFileRepresentation() + "\n";
        }

        newData.TrimEnd();
        
        File.WriteAllText(_filePath, newData);
    }

    public override string ToString()
    {
        string devicesString = "";

        foreach (var device in _devices)
        {
            devicesString += device;
        }
        devicesString = devicesString.TrimEnd(',');

        return $"DeviceManager(\"{_filePath}\", [{devicesString}])";
    }
}