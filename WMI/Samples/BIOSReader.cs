using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace WMI.Samples
{
    internal class BIOSReader
    {
        public void ReadBIOsDetails()
        {
            ManagementScope scope = new ManagementScope("\\\\.\\ROOT\\cimv2");
            scope.Connect();
            ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_BIOS");
            using ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope,query);
            foreach (var item in searcher.Get())
            {
                var queryObj = (ManagementObject)item;
                Console.WriteLine($"Manufactor:{queryObj["Manufacturer"]}");
                Console.WriteLine($"Name:{queryObj["Name"]}");
                Console.WriteLine($"Version:{queryObj["Version"]}");
            }
        }
    }
}
