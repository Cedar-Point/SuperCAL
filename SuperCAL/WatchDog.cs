using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.Diagnostics;

namespace SuperCAL
{
    class WatchDog
    {
        private static string imageName = "WIN7CALStart";
        public static Task WaitForProcessExit(string imageName)
        {
            Logger.Log("Waiting for " + imageName + " to exit...");
            return Task.Run(() => {
                Process[] processes = Process.GetProcessesByName(imageName);
                if (processes.Length != 0)
                {
                    processes[0].WaitForExit();
                    Logger.Good(imageName + " exited.");
                }
            });
        }
        public static Task WaitForCALBusy(bool reverse = false)
        {
            return Task.Run(() => {
                string endMsg = "";
                Process[] processes = Process.GetProcessesByName(imageName);
                Logger.Log("Waiting for " + imageName + "...");
                if (reverse)
                {
                    while (processes.Length != 0 && processes[0].MainWindowTitle == "MICROS CAL Busy...")
                    {
                        processes = Process.GetProcessesByName(imageName);
                        Thread.Sleep(100);
                    }
                    endMsg = "CAL is no longer busy...";
                }
                else
                {
                    while (processes.Length != 0 && processes[0].MainWindowTitle != "MICROS CAL Busy...")
                    {
                        processes = Process.GetProcessesByName(imageName);
                        Thread.Sleep(100);
                    }
                    endMsg = "CAL is busy...";
                }
                if(processes.Length == 0)
                {
                    Logger.Error(imageName + ": CAL was terminated!");
                }
                else
                {
                    Logger.Good(imageName + ": " + endMsg);
                }
            });
        }
        public static Task WaitForProcessStart()
        {
            Logger.Log("Waiting for " + imageName + " to start...");
            return Task.Run(() => {
                Process[] processes = Process.GetProcessesByName(imageName);
                while(processes.Length == 0)
                {
                    Thread.Sleep(100);
                    processes = Process.GetProcessesByName(imageName);
                }
                Logger.Good(imageName + " started.");
            });
        }
    }
}
