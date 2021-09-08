using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace SuperCAL
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Arguments = args;
            bool prePass = true;
            try
            {
                McrsCalSrvc.Service.Status.ToString();
            }
            catch (InvalidOperationException e)
            {
                Application.Run(new Error(e.Message + "\n\nTry and install Micros CAL next time maybe?\n\nSuper CAL: " + Application.ProductVersion));
                prePass = false;
            }
            if (prePass)
            {
                try
                {
                    if (File.Exists("SuperCAL.xml"))
                    {
                        if (Arguments.Length != 0 && Arguments[0] == "1")
                        {
                            BelowAverage.SecureDesktop.StartProcess(Application.ExecutablePath + " 0");
                        }
                        else if (Arguments.Length != 0 && Arguments[0] == "2")
                        {
                            BelowAverage.SecureDesktop.StartProcess(Application.ExecutablePath + " 3");
                        }
                        else
                        {
                            Config.ReadConfig();
                            Application.Run(new Main());
                        }
                    }
                    else
                    {
                        Config.GenerateConfig();
                        Application.Run(new Error("A config XML (SuperCAL.xml) was just generated...\n\nPlease take the time to set it up correctly.\n\nSuper CAL: " + Application.ProductVersion));
                    }
                }
                catch(Exception e)
                {
                    if (e.InnerException != null)
                    {
                        Application.Run(new Error(e.Message + "\n\n" + e.StackTrace + "\n\n" + e.InnerException.Message + "\n\n" + e.InnerException.StackTrace));
                    }
                    else
                    {
                        Application.Run(new Error(e.Message + "\n\n" + e.StackTrace));
                    }
                }
            }
            if (RetryLaunch)
            {
                Process.Start(Process.GetCurrentProcess().MainModule.FileName);
            }
        }
        public static bool RetryLaunch = false;
        public static string[] Arguments;
    }
}
