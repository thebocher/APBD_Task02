namespace APBD_Task02.parsers;

public class EmbeddedDeviceParser : IParser
{
    public bool CanParse(string s)
    {
        return s.StartsWith("ED") && s.Split(",").Length == 4;
    }

    public Device Parse(string s)
    {
        var split = s.Split(",");
        var id = split[0];
        var name = split[1];
        var ip = split[2];
        var networkName = split[3];
        
        return new EmbeddedDevice
        {
            Id = id,
            Name = name,
            TurnedOn = false,
            IpAddress = ip,
            NetworkName = networkName
        };
    }
}