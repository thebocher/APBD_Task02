using System;
using System.Collections.Generic;
using APBD_Task02;
using JetBrains.Annotations;
using Xunit;
using Xunit.Abstractions;

namespace DeviceManagerTest;

[TestSubject(typeof(FileDeviceManager))]
public class FileDeviceManagerTest
{
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly string filePath = "/Users/thebocher/Downloads/input.txt";

    public FileDeviceManagerTest(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void TurnOnDevice()
    {
        IDeviceManager fileDeviceManager = DeviceManagerFactory.GetFileDeviceManager(filePath);
        
        SmartWatch smartWatch = new SmartWatch();
        smartWatch.Id = "SM-1";
        smartWatch.BatteryPercentage = 20;
        
        fileDeviceManager.AddDevice(smartWatch);
        fileDeviceManager.TurnOnDevice(smartWatch.Id);
        Assert.True(smartWatch.TurnedOn);
    }
    
    [Fact]
    public void TurnOffDevice()
    {
        IDeviceManager fileDeviceManager = DeviceManagerFactory.GetFileDeviceManager(filePath);
        
        SmartWatch smartWatch = new SmartWatch();
        smartWatch.Id = "SM-1";
        
        fileDeviceManager.AddDevice(smartWatch);
        fileDeviceManager.TurnOffDevice(smartWatch.Id);
        Assert.False(smartWatch.TurnedOn);
    }
}