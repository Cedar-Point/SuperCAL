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
                Logger.Good("CAL Stopped.");
                KillProcesses(Process.GetProcessesByName("WIN7CALStart"));
                KillProcesses(Process.GetProcessesByName("SarOpsWin32"));
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
        private static void KillProcesses(Process[] processes)
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
    }
}
