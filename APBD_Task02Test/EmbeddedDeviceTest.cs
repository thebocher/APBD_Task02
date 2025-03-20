using System;
using APBD_Task02;
using JetBrains.Annotations;
using Xunit;

namespace EmbeddedDeviceTest;

[TestSubject(typeof(EmbeddedDevice))]
public class EmbeddedDeviceTest
{

    [Fact]
    public void TestIncorrectIpArgumentException()
    {
        EmbeddedDevice embeddedDevice = new EmbeddedDevice();
        Assert.Throws<ArgumentException>(() => embeddedDevice.IpAddress = "127.0a.0.1");
    }


    [Fact]
    public void TestCorrectIpNoArgumentException()
    {
        EmbeddedDevice embeddedDevice = new EmbeddedDevice();
        embeddedDevice.IpAddress = "127.0.0.1";
    }


    [Fact]
    public void TestConnectException()
    {
        EmbeddedDevice embeddedDevice = new EmbeddedDevice();
        embeddedDevice.NetworkName = "";
        Assert.Throws<ConnectionException>(() => embeddedDevice.TurnOn());
    }


    [Fact]
    public void TestNoConnectException()
    {
        EmbeddedDevice embeddedDevice = new EmbeddedDevice();
        embeddedDevice.NetworkName = "MD Ltd. asdf";
        embeddedDevice.TurnOn();
    }
}