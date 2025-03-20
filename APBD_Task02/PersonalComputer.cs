namespace APBD_Task02;

public class PersonalComputer : IDevice
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
}