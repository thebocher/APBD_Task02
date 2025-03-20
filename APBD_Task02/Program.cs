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

d.ShowAllDevices();

SmartWatch newSmartWatch = new SmartWatch();
newSmartWatch.Id = "SW-5";
newSmartWatch.Name = "some name";
newSmartWatch.TurnedOn = false;
newSmartWatch.BatteryPercentage = 100;

d.AddDevice(newSmartWatch);

d.ShowAllDevices();

d.SaveDataToFile();

try
{
    d.RemoveDevice("SW-19");
}
catch (DeviceNotFound e)
{
    Console.WriteLine("Device SW-19 not found");
}

d.RemoveDevice("SW-5");
d.SaveDataToFile();

