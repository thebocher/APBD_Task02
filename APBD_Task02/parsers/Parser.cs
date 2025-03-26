namespace APBD_Task02.parsers;

public interface IParser
{
    public bool CanParse(string s);
    public Device Parse(string s);
}