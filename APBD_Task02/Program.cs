using APBD_Task02;

DeviceManager d;
try
{
    d = new DeviceManager("/Users/thebocher/Downloads/input1.txt");
}
catch (ArgumentException e)
{
    Console.WriteLine("Got error while reading the file");
    Console.WriteLine(e.Message);
    return;
}

Console.WriteLine("devices from file:");
d.ShowAllDevices();
Console.WriteLine();

SmartWatch newSmartWatch = new SmartWatch();
newSmartWatch.Id = "SW-5";
newSmartWatch.Name = "some name";
newSmartWatch.TurnedOn = false;
newSmartWatch.BatteryPercentage = 100;

d.AddDevice(newSmartWatch);

Console.WriteLine("after adding new device:");
d.ShowAllDevices();
Console.WriteLine();

d.SaveDataToFile();

try
{
    d.RemoveDevice("SW-19");
}
catch (DeviceNotFound e)
{
    Console.WriteLine("Device SW-19 not found");
}

Console.WriteLine("after removing device:");
d.RemoveDevice("SW-5");
Console.WriteLine();

Console.WriteLine("after editing device:");
newSmartWatch.Id = "SW-1";
d.EditDeviceData("SW-1", newSmartWatch);
d.ShowAllDevices();
Console.WriteLine();


try
{
    d.EditDeviceData("P-1", newSmartWatch);
}
catch (InvalidCastException e)
{
    Console.WriteLine(e.Message);
    Console.WriteLine("cant edit devices of different type");
}
