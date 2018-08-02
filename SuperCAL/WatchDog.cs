using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SuperCAL
{
    class WatchDog
    {
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
        public static Task WaitForCALBusy(string imageName, bool reverse = false)
        {
            return Task.Run(() => {
                Process[] processes = Process.GetProcessesByName(imageName);
                if(reverse)
                {
                    Logger.Log("Waiting for " + imageName + " to not show CAL Busy...");
                    while (processes.Length != 0 && processes[0].MainWindowTitle == "MICROS CAL Busy...")
                    {
                        processes = Process.GetProcessesByName(imageName);
                        Thread.Sleep(100);
                    }
                    Logger.Good(imageName + ": CAL is not busy.");
                }
                else
                {
                    Logger.Log("Waiting for " + imageName + " to show CAL Busy...");
                    while (processes.Length != 0 && processes[0].MainWindowTitle != "MICROS CAL Busy...")
                    {
                        processes = Process.GetProcessesByName(imageName);
                        Thread.Sleep(100);
                    }
                    Logger.Good(imageName + ": CAL is busy.");
                }
            });
        }
        public static Task WaitForProcessStart(string imageName)
        {
            Logger.Log("Waiting for " + imageName + " to start...");
            return Task.Run(() => {
                Process[] processes = Process.GetProcessesByName(imageName);
                while(processes.Length == 0)
                {
                    Thread.Sleep(100);
                    processes = Process.GetProcessesByName(imageName);
                    Logger.Log(processes.Length.ToString());
                }
                Logger.Good(imageName + " started.");
            });
        }
    }
}
