using System.Text.RegularExpressions;

namespace APBD_Task02;

public class EmbeddedDevice : IDevice
{
    static bool IsValidIPv4(string ip)
    {
        string pattern = @"^(25[0-5]|2[0-4][0-9]|1?[0-9]?[0-9])(\.(25[0-5]|2[0-4][0-9]|1?[0-9]?[0-9])){3}$";
        return Regex.IsMatch(ip, pattern);
    }
    private string _ipAddress;
    public string IpAddress
    {
        get => _ipAddress;
        set
        {
            if (!IsValidIPv4(value))
                throw new ArgumentException("Invalid IP address");
        }
    }
    public string NetworkName { get; set; }

    public override void TurnOn()
    {
        base.TurnOn();
        Connect();
    }
    
    public void Connect()
    {
        if (!NetworkName.Contains("MD Ltd."))
            throw new ConnectionException();
    }

    public override string ToString()
    {
        return $"EmbeddedDevice({Id}, {Name}, {TurnedOn}, {IpAddress}, {NetworkName})";
    }
}