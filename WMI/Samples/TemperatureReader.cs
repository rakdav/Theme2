using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace WMI.Samples
{
    internal class TemperatureReader
    {
        public void ReadTemperatures()
        {
            var scope = "root\\WMI";
            var query = "select * from MSAcpi_ThermalZoneTemperature";
            var searcher = new ManagementObjectSearcher(scope, query);
            try
            {
                foreach (var item in searcher.Get())
                {
                    var obj = (ManagementObject)item;
                    var temp = Convert.ToDouble(obj["CurrentTemperature"])/10-273.15;
                    Console.WriteLine($"{temp:F2}");
                }
            }
            catch(ManagementException)
            {
                Console.WriteLine("Виновата Арина");
            }
        }
    }
}
