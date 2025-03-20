using System.Collections.Generic;
using APBD_Task02;
using JetBrains.Annotations;
using Xunit;

namespace DeviceManagerTest;

[TestSubject(typeof(DeviceManager))]
public class DeviceManagerTest
{
    private string filePath = "/Users/thebocher/Downloads/input.txt";

    [Fact]
    public void TurnOnDevice()
    {
        DeviceManager deviceManager = new DeviceManager(filePath);
        
        SmartWatch smartWatch = new SmartWatch();
        smartWatch.Id = "SM-1";
        
        deviceManager.AddDevice(smartWatch);
        deviceManager.TurnOnDevice(smartWatch.Id);
        Assert.True(smartWatch.TurnedOn);
    }
    
    [Fact]
    public void TurnOffDevice()
    {
        DeviceManager deviceManager = new DeviceManager(filePath);
        
        SmartWatch smartWatch = new SmartWatch();
        smartWatch.Id = "SM-1";
        
        deviceManager.AddDevice(smartWatch);
        deviceManager.TurnOffDevice(smartWatch.Id);
        Assert.False(smartWatch.TurnedOn);
    }
}