using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace WMI.Samples
{
    internal class USBWarning
    {
        public void StartListening()
        {
            string wmiQuery = "SELECT * from __InstanceDeletionEvent WITHIN 2 " +
                              "WHERE TargetInstance ISA 'Win32_USBHub'";
            ManagementEventWatcher watcher = new ManagementEventWatcher(wmiQuery);
            watcher.EventArrived += new EventArrivedEventHandler(USBRemoved);
            watcher.Start();
            Console.WriteLine("Извлеките устройство");
            Console.ReadLine();
            watcher.Stop();
        }
        private void USBRemoved(object sender,EventArrivedEventArgs e)
        {
            
            ManagementBaseObject instance = (ManagementBaseObject)e.NewEvent["TargetInstance"];
            string deviceID = (string)instance["DeviceID"];
            string pnpDeviceID = (string)instance["PNPDeviceID"];
            string description = (string)instance["Description"];
            var mes = "USB device removed:\n" +
                "DeviceID=" + deviceID +
                "\nPNPDeviceID=" + pnpDeviceID +
                "\nDescription=" + description;
            Console.WriteLine(mes);
        }
    }
}
