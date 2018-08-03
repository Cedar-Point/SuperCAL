using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        private static string imageName = "WIN7CALStart";
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
                Process[] procs = Process.GetProcessesByName(imageName);
                if (procs.Length != 0)
                {
                    foreach(Process proc in procs)
                    {
                        try
                        {
                            proc.Kill();
                            Logger.Warning("Killed: " + proc.ProcessName + ":" + proc.Id.ToString());
                        }
                        catch(Exception)
                        {
                            Logger.Error("Killing " + proc.ProcessName + ":" + proc.Id.ToString() + " failed. Process may already be ending.");
                        }
                    }
                }
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
    }
}
