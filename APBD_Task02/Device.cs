namespace APBD_Task02;

public class Device
{
    public string Id { get; set; }
    public string Name { get; set; }
    public bool TurnedOn { get; set; }

    public virtual void TurnOn()
    {
        TurnedOn = true;
    }

    public virtual void TurnOff()
    {
        TurnedOn = false;
    }

    public virtual string ToFileRepresentation()
    {
        return $"{Id}, {Name}, {TurnedOn}";
    }
}