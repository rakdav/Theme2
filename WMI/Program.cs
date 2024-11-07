//WMI
using WMI.Samples;

BIOSReader bios = new BIOSReader();
bios.ReadBIOsDetails();
TemperatureReader temp = new TemperatureReader();
temp.ReadTemperatures();