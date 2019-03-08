using System;
using System.Threading.Tasks;
using System.ServiceProcess;
using System.Windows.Forms;
using System.Diagnostics;

namespace SuperCAL
{
    class McrsCalSrvc
    {
        public static Button StopStartCAL;
        public static TableLayoutPanel Table;
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
            Table.Enabled = false;
            StopStartCAL.Text = "Stopping CAL...";
            Logger.Log("Stopping CAL...");
            return Task.Run(() => {
                Service.Stop();
                TryStopService("World Wide Web Publishing Service");
                TryStopService("MICROS KDS Controller");
                TryStopProcesses(Process.GetProcessesByName("WIN7CALStart"));
                TryStopProcesses(Process.GetProcessesByName("SarOpsWin32"));
                TryStopProcesses(Process.GetProcessesByName("KDSDisplay"));
                Logger.Good("CAL Stopped.");
                StopStartCAL.Invoke(new Action(() => {
                    StopStartCAL.Text = "Start CAL";
                    Table.Enabled = true;
                }));
            });
        }
        public static Task Start()
        {
            Table.Enabled = false;
            StopStartCAL.Text = "Starting CAL...";
            Logger.Log("Starting CAL...");
            return Task.Run(() => {
                TryStartService("World Wide Web Publishing Service");
                TryStartService("MICROS KDS Controller");
                Service.Start();
                Logger.Good("CAL Started.");
                StopStartCAL.Invoke(new Action(() => {
                    StopStartCAL.Text = "Stop CAL";
                    Table.Enabled = true;
                }));
            });
        }
        public static async Task ToggleCal()
        {
            if (IsRunning())
            {
                await Stop();
            }
            else
            {
                await Start();
            }
        }
        public static ServiceController GetService(string serviceName)
        {
            ServiceController service = null;
            foreach (ServiceController serviceController in ServiceController.GetServices())
            {
                if (serviceController.DisplayName == serviceName)
                {
                    service = serviceController;
                    break;
                }
            }
            return service;
        }
        private static void TryStopProcesses(Process[] processes)
        {
            if (processes.Length != 0)
            {
                foreach (Process proc in processes)
                {
                    try
                    {
                        proc.Kill();
                        Logger.Good("Killed: " + proc.ProcessName + ":" + proc.Id.ToString());
                    }
                    catch (Exception)
                    {
                        Logger.Warning("Killing " + proc.ProcessName + ":" + proc.Id.ToString() + " failed. Process may already be ending.");
                    }
                }
            }
        }
        private static void TryStopService(string serviceName)
        {
            Logger.Log(serviceName + ": Checking if service exists...");
            ServiceController service = GetService(serviceName);
            if (service != null)
            {
                try
                {
                    Logger.Log(serviceName + ": Stopping...");
                    service.Stop();
                    Logger.Good(serviceName + ": Stopped.");
                }
                catch (Exception e)
                {
                    Logger.Warning(serviceName + ": " + e.Message);
                }
            }
            else
            {
                Logger.Log(serviceName + ": Service does not exist.");
            }
        }
        private static void TryStartService(string serviceName)
        {
            Logger.Log(serviceName + ": Checking if service exists...");
            ServiceController service = GetService(serviceName);
            if (service != null)
            {
                try
                {
                    Logger.Log(serviceName + ": Starting...");
                    service.Start();
                    Logger.Good(serviceName + ": Started.");
                }
                catch (Exception e)
                {
                    Logger.Warning(serviceName + ": " + e.Message);
                }
            }
            else
            {
                Logger.Log(serviceName + ": Service does not exist.");
            }
        }
    }
}
