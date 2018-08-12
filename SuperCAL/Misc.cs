using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace SuperCAL
{
    class Misc
    {
        public static void RestartWindows()
        {
            Logger.Log("Restarting windows...");
            RunCMD("shutdown.exe /r /t 0");
        }
        public static Task RunPowershell(string Command)
        {
            return Task.Run(() => {
                Process ps = new Process();
                ps.StartInfo.FileName = System32Path() + @"WindowsPowerShell\v1.0\powershell.exe";
                ps.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                ps.StartInfo.Arguments = "-Command " + Command;
                ps.Start();
                ps.WaitForExit();
            });
        }
        public static Task RunCMD(string Command)
        {
            return Task.Run(() => {
                Process ps = new Process();
                ps.StartInfo.FileName = System32Path() + @"cmd.exe";
                ps.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                ps.StartInfo.Arguments = "/C " + Command;
                ps.Start();
                ps.WaitForExit();
            });
        }
        public static Task InstallPhaseTwo(bool install = true)
        {
            return Task.Run(() => {
                if (install)
                {
                    Directory.CreateDirectory(@"C:\MICROS\SuperCAL");
                    Logger.Good(@"C:\MICROS\SuperCAL: Created.");
                    File.WriteAllBytes(@"C:\MICROS\SuperCAL\PsExec.exe", Properties.Resources.PsExec);
                    Logger.Good(@"C:\MICROS\SuperCAL\PsExec.exe: Copied.");
                    File.WriteAllBytes(@"C:\MICROS\SuperCAL\SuperCALTask.xml", Properties.Resources.SuperCALTask);
                    Logger.Good(@"C:\MICROS\SuperCAL\SuperCALTask.xml: Copied.");
                    try
                    {
                        File.Copy("SuperCAL.xml", @"C:\MICROS\SuperCAL\SuperCAL.xml", true);
                        Logger.Good(@"C:\MICROS\SuperCAL\SuperCAL.xml: Copied.");
                    }
                    catch(IOException e)
                    {
                        Logger.Warning(e.Message);
                    }
                    try
                    {
                        File.Copy(Process.GetCurrentProcess().MainModule.FileName, @"C:\MICROS\SuperCAL\SuperCAL.exe", true);
                        Logger.Good(@"C:\MICROS\SuperCAL\SuperCAL.exe: Copied.");
                    }
                    catch(IOException e)
                    {
                        Logger.Warning(e.Message);
                    }
                    Logger.Log("Creating SuperCAL task...");
                    RunCMD(@"schtasks.exe /Create /tn SuperCAL /XML C:\MICROS\SuperCAL\SuperCALTask.xml");
                    Logger.Good("Done.");
                }
                else
                {
                    Logger.Log("Removing SuperCAL task...");
                    RunCMD("schtasks.exe /Delete /f /tn SuperCAL");
                    Logger.Good("Done.");
                }
            });
        }
        public static Task InstallNetdom()
        {
            return Task.Run(() => {
                try
                {
                    if (Environment.OSVersion.Version.Build >= 10240)
                    {
                        Logger.Log("Installing NETDOM for Windows 10...");
                        File.WriteAllBytes(System32Path() + @"netdom.exe", Properties.Resources.netdom10);
                        Logger.Good(@"C:\Windows\System32\netdom.exe: Copied.");
                        File.WriteAllBytes(System32Path() + @"en-US\netdom.exe.mui", Properties.Resources.netdom10_exe);
                        Logger.Good(@"C:\Windows\System32\en-US\netdom.exe.mui: Copied.");
                        Logger.Good("Done.");
                    }
                    else
                    {
                        Logger.Log("Installing NETDOM for Windows 8.1...");
                        File.WriteAllBytes(System32Path() + @"netdom.exe", Properties.Resources.netdom8_1);
                        Logger.Good(@"C:\Windows\System32\netdom.exe: Copied.");
                        File.WriteAllBytes(System32Path() + @"en-US\netdom.exe.mui", Properties.Resources.netdom8_1_exe);
                        Logger.Good(@"C:\Windows\System32\en-US\netdom.exe.mui: Copied.");
                        Logger.Good("Done.");
                    }
                }
                catch(UnauthorizedAccessException e)
                {
                    Logger.Warning(e.Message);
                }
            });
        }
        public static string System32Path()
        {
            if (Environment.Is64BitOperatingSystem)
            {
                return @"C:\Windows\Sysnative\";
            }
            else
            {
                return @"C:\Windows\System32\";
            }
        }
    }
}
