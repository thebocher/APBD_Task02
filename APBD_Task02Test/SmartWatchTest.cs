using APBD_Task02;
using JetBrains.Annotations;
using Xunit;

namespace SmartWatchTest;

[TestSubject(typeof(SmartWatch))]
public class SmartWatchTest
{

    [Fact]
    public void TestBatteryPercentageLessThanZero()
    {
        SmartWatch smartWatch = new SmartWatch();
        smartWatch.BatteryPercentage = -10;
        Assert.Equal(0, smartWatch.BatteryPercentage);
    }

    [Fact]
    public void TestBatteryPercentageMoreThan100()
    {
        SmartWatch smartWatch = new SmartWatch();
        smartWatch.BatteryPercentage = 10100;
        Assert.Equal(100, smartWatch.BatteryPercentage);
    }


    [Fact]
    public void TestBatteryPercentageEqual()
    {
        SmartWatch smartWatch = new SmartWatch();
        smartWatch.BatteryPercentage = 78;
        Assert.Equal(78, smartWatch.BatteryPercentage);
    }

    [Fact]
    public void TestEmptyBatteryException()
    {
        SmartWatch smartWatch = new SmartWatch();
        smartWatch.BatteryPercentage = 10;
        Assert.Throws<EmptyBatteryException>(
            () => smartWatch.TurnOn()
            );
    }
    
    [Fact]
    public void TestNoEmptyBatteryException()
    {
        SmartWatch smartWatch = new SmartWatch();
        smartWatch.BatteryPercentage = 20;
        smartWatch.TurnOn();
    }


    [Fact]
    public void TestBatteryReduceOnTurnOn()
    {
        SmartWatch smartWatch = new SmartWatch();
        smartWatch.BatteryPercentage = 20;
        smartWatch.TurnOn();
        Assert.Equal(10, smartWatch.BatteryPercentage);
    }
}