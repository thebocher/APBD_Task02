using APBD_Task02.parsers;

namespace APBD_Task02;

public class CsvDeviceFileParser
{
    List<IParser> _parsers;
    
    public CsvDeviceFileParser(List<IParser> parsers)
    {
        _parsers = parsers;
    }
    public List<Device> Parse(string filePath)
    {
        List<Device> devices = [];
        foreach (var str in File.ReadLines(filePath))
        {
            var parser = _parsers.FirstOrDefault(p => p.CanParse(str));

            if (parser == null) continue;
            
            devices.Add(parser.Parse(str));
        }

        return devices;
    }
    
}