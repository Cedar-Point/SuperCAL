using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceProcess;

namespace SuperCAL
{
    class McrsCalSrvc
    {
        public static ServiceController Service = new ServiceController("MICROS CAL Client");
        public static bool IsRunning()
        {
            Service.Refresh();
            if (Service.Status == ServiceControllerStatus.Stopped)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static Task Stop()
        {
            Logger.Log("Stopping CAL...");
            return Task.Run(() => {
                Service.Stop();
                Logger.Good("CAL Stopped.");
            });
        }
        public static Task Start()
        {
            Logger.Log("Starting CAL...");
            return Task.Run(() => {
                Service.Start();
                Logger.Good("CAL Started.");
            });
        }
    }
}
