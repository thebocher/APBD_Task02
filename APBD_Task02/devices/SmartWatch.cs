namespace APBD_Task02;

public class SmartWatch : Device, IPowerNotifier
{
    private float _batteryPercentage;
    
    public float BatteryPercentage
    {
        get => _batteryPercentage;
        set
        {
            if (value < 0) 
                value = 0;

            if (value > 100)
                value = 100;
            
            if (value < 20)
                NotifyLowBattery();
            
            _batteryPercentage = value;
        }
    }

    public void NotifyLowBattery()
    {
        Console.WriteLine("Low battery");
    }

    public override void TurnOn()
    {
        if (BatteryPercentage < 11)
        {
            throw new EmptyBatteryException();
        }
        
        base.TurnOn();
        BatteryPercentage -= 10;
    }

    public override string ToString()
    {
        return $"SmartWatch({Id}, {Name}, {TurnedOn}, {BatteryPercentage})";
    }

    public override string ToFileRepresentation()
    {
        return $"{Id},{Name},{TurnedOn},{BatteryPercentage}";
    }
}