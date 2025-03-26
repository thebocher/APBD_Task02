namespace APBD_Task02;

public class PersonalComputer : Device
{
    public String OperationalSystem { get; set; }

    public override void TurnOn()
    {
        if (OperationalSystem == null)
            throw new EmptySystemException();
        
        base.TurnOn();
    }

    public override string ToString()
    {
        return $"PersonalComputer({Id}, {Name}, {TurnedOn}, {OperationalSystem})";
    }

    public override string ToFileRepresentation()
    {
        return $"{Id},{Name},{TurnedOn},{OperationalSystem}";
    }
    
    public override void Update(Device device)
    {
        base.Update(device);
        
        var pc = (PersonalComputer)device;
        Name = pc.Name;
        TurnedOn = pc.TurnedOn;
        OperationalSystem = pc.OperationalSystem;
    }
}