namespace APBD_Task02;

public class DeviceManager
{
    private List<IDevice> devices;
    private string _filePath;
    
    public DeviceManager(string filePath)
    {
        _filePath = filePath;
        
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException("File does not exist");
        }
        
        foreach (string deviceString in File.ReadLines(filePath))
        {   
            string[] split = deviceString.Split(',');

            if (split.Length < 1) continue;
            
            string id = split[0];
            string name;
            bool turnedOn;
            
            if (id.StartsWith("SW"))
            {
                if (split.Length != 4) continue;
                
                name = split[1];
                turnedOn = bool.Parse(split[2]);
                float batteryPercentage = float.Parse(split[4].Replace("%", ""));
                
                SmartWatch smartWatch = new SmartWatch();
                smartWatch.Id = id;
                smartWatch.Name = name;
                smartWatch.TurnedOn = turnedOn;
                smartWatch.BatteryPercentage = batteryPercentage;
                
                AddDevice(smartWatch);

            } else if (id.StartsWith("P"))
            {
                if (split.Length != 4) continue;
            
                name = split[1];
                turnedOn = bool.Parse(split[2]);
                string os = split[3];
                
                PersonalComputer personalComputer = new PersonalComputer();
                personalComputer.Id = id;
                personalComputer.Name = name;
                personalComputer.TurnedOn = turnedOn;
                personalComputer.OperationalSystem = os;
                
                AddDevice(personalComputer);
            } else if (id.StartsWith("ED"))
            {
                if (split.Length != 4) continue;
                
                name = split[1];
                string ip = split[2];
                string networkName = split[3];
                turnedOn = false;
                
                EmbeddedDevice ede = new EmbeddedDevice();
                ede.Id = id;
                ede.Name = name;
                ede.TurnedOn = turnedOn;
                ede.IpAddress = ip;
                ede.NetworkName = networkName;
                
                AddDevice(ede);
            }
        }
    }

    public void AddDevice(IDevice device)
    {
        devices.Add(device);
    }

    public void RemoveDevice(string deviceId)
    {
        IDevice device = getDeviceById(deviceId);
        devices.Remove(device);
    }

    public void EditDeviceData(String deviceId, IDevice data)
    {
        IDevice device = getDeviceById(deviceId);
        
        if (device.GetType() != data.GetType())
            throw new InvalidCastException();

        if (device is SmartWatch)
        {
            SmartWatch smartWatch = (SmartWatch)device;
            SmartWatch smartWatch2 = (SmartWatch)data;
            
            smartWatch.Name = smartWatch2.Name;
            smartWatch2.TurnedOn = smartWatch.TurnedOn;
            smartWatch2.BatteryPercentage = smartWatch.BatteryPercentage;
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
        IDevice device = getDeviceById(deviceId);
        device.TurnOn();
    }

    public void TurnOffDevice(string deviceId)
    {
        getDeviceById(deviceId).TurnOff();
    }

    public void ShowAllDevices()
    {
        foreach (var device in devices)
        {
            Console.WriteLine(device);
        }
    }

    public IDevice getDeviceById(string deviceId)
    {
        foreach (var device in devices)
        {
            if (device.Id == deviceId) return device;
        }
        
        throw new DeviceNotFound();
    }

    public void SaveDataToFile()
    {
        string newData = "";

        foreach (var device in devices)
        {
            newData += device;
        }
        
        File.WriteAllText(_filePath, newData);
    }

    public override string ToString()
    {
        string devicesString = "";

        foreach (var device in devices)
        {
            devicesString += device.ToString() + ",";
        }
        devicesString = devicesString.TrimEnd(',');

        return $"DeviceManager(\"{_filePath}\", [{devicesString}])";
    }
}