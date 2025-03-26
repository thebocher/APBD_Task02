namespace APBD_Task02;

public static class CsvDeviceFileParser
{
    public static List<Device> Parse(string filePath)
    {
        List<Device> devices = [];
        foreach (var str in File.ReadLines(filePath))
        {
            string[] split = str.Split(',');

            if (split.Length < 1) continue;
            
            string id = split[0];
            string name;
            bool turnedOn;
            
            if (id.StartsWith("SW"))
            {
                if (split.Length != 4) continue;
                
                name = split[1];
                turnedOn = bool.Parse(split[2]);
                var batteryPercentage = float.Parse(split[3].Replace("%", ""));
                SmartWatch smartWatch = new SmartWatch();
                smartWatch.Id = id;
                smartWatch.Name = name;
                smartWatch.BatteryPercentage = batteryPercentage;
                smartWatch.TurnedOn = turnedOn;
                devices.Add(smartWatch);
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
                devices.Add(personalComputer);
            } else if (id.StartsWith("ED"))
            {
                if (split.Length != 4) continue;
                
                name = split[1];
                string ip = split[2];
                string networkName = split[3];
                
                EmbeddedDevice ede = new EmbeddedDevice();
                ede.Id = id;
                ede.Name = name;
                ede.TurnedOn = false;
                ede.IpAddress = ip;
                ede.NetworkName = networkName;
                devices.Add(ede);
            }
        }

        return devices;
    }
    
}