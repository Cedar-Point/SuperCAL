﻿using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace SuperCAL
{
    class Misc
    {
        public static string AutoLogonUserName = "";
        public static string AutoLogonPassword = "";
        public static string AutoLogonADDomain = "";
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
                    if (Environment.OSVersion.Version.Build >= 10240 && Environment.Is64BitOperatingSystem)
                    {
                        Logger.Log("Installing NETDOM for Windows 10 x64...");
                        File.WriteAllBytes(System32Path() + @"netdom.exe", Properties.Resources.netdom1064);
                        Logger.Good(@"C:\Windows\System32\netdom.exe: Copied.");
                        File.WriteAllBytes(System32Path() + @"en-US\netdom.exe.mui", Properties.Resources.netdom1064_exe);
                        Logger.Good(@"C:\Windows\System32\en-US\netdom.exe.mui: Copied.");
                        Logger.Good("Done.");
                    }
                    else if(Environment.OSVersion.Version.Build >= 10240 && !Environment.Is64BitOperatingSystem)
                    {
                        Logger.Log("Installing NETDOM for Windows 10 x86...");
                        File.WriteAllBytes(System32Path() + @"netdom.exe", Properties.Resources.netdom10);
                        Logger.Good(@"C:\Windows\System32\netdom.exe: Copied.");
                        File.WriteAllBytes(System32Path() + @"en-US\netdom.exe.mui", Properties.Resources.netdom10_exe);
                        Logger.Good(@"C:\Windows\System32\en-US\netdom.exe.mui: Copied.");
                        Logger.Good("Done.");
                    }
                    else if(!Environment.Is64BitOperatingSystem)
                    {
                        Logger.Log("Installing NETDOM for Windows 8.1 x86...");
                        File.WriteAllBytes(System32Path() + @"netdom.exe", Properties.Resources.netdom8_1);
                        Logger.Good(@"C:\Windows\System32\netdom.exe: Copied.");
                        File.WriteAllBytes(System32Path() + @"en-US\netdom.exe.mui", Properties.Resources.netdom8_1_exe);
                        Logger.Good(@"C:\Windows\System32\en-US\netdom.exe.mui: Copied.");
                        Logger.Good("Done.");
                    }
                    else
                    {
                        throw new Exception("SuperCAL is not compatible with this version of Windows!");
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
        public static Task SetAutoLogon(bool enable = true)
        {
            return Task.Run(() =>
            {
                Logger.Log("Setting the 32Bit AutoLogon REG...");
                try
                {
                    RegistryKey regKey32 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon", true);
                    if (enable)
                    {
                        regKey32.SetValue("AutoAdminLogon", "1");
                        Logger.Good("32Bit Reg: AutoAdminLogon: 1");
                        regKey32.SetValue("DefaultUserName", AutoLogonUserName);
                        Logger.Good("32Bit Reg: DefaultUserName: " + AutoLogonUserName);
                        regKey32.SetValue("DefaultPassword", AutoLogonPassword);
                        Logger.Good("32Bit Reg: DefaultPassword: " + AutoLogonPassword);
                        regKey32.SetValue("DefaultDomainName", AutoLogonADDomain);
                        Logger.Good("32Bit Reg: DefaultDomainName: " + AutoLogonADDomain);
                    }
                    else
                    {
                        regKey32.SetValue("AutoAdminLogon", "0");
                        Logger.Good("32Bit Reg: AutoAdminLogon: 0");
                        regKey32.SetValue("DefaultUserName", "");
                        Logger.Good("32Bit Reg: DefaultUserName: null");
                        regKey32.SetValue("DefaultPassword", "");
                        Logger.Good("32Bit Reg: DefaultPassword: null");
                        regKey32.SetValue("DefaultDomainName", "");
                        Logger.Good("32Bit Reg: DefaultDomainName: null");
                    }
                    regKey32.Close();
                }
                catch (Exception)
                {
                    Logger.Warning("Failed to modify the WinLogon key in the 32Bit registry.");
                }
                Logger.Log("Done.");
                Logger.Log("Setting the 64Bit AutoLogon REG...");
                try
                {
                    RegistryKey regKey64 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon", true);
                    if (enable)
                    {
                        regKey64.SetValue("AutoAdminLogon", "1");
                        Logger.Good("64Bit Reg: AutoAdminLogon: 1");
                        regKey64.SetValue("DefaultUserName", AutoLogonUserName);
                        Logger.Good("64Bit Reg: DefaultUserName: " + AutoLogonUserName);
                        regKey64.SetValue("DefaultPassword", AutoLogonPassword);
                        Logger.Good("64Bit Reg: DefaultPassword: " + AutoLogonPassword);
                        regKey64.SetValue("DefaultDomainName", AutoLogonADDomain);
                        Logger.Good("64Bit Reg: DefaultDomainName: " + AutoLogonADDomain);
                    }
                    else
                    {
                        regKey64.SetValue("AutoAdminLogon", "0");
                        Logger.Good("64Bit Reg: AutoAdminLogon: 0");
                        regKey64.SetValue("DefaultUserName", "");
                        Logger.Good("64Bit Reg: DefaultUserName: null");
                        regKey64.SetValue("DefaultPassword", "");
                        Logger.Good("64Bit Reg: DefaultPassword: null");
                        regKey64.SetValue("DefaultDomainName", "");
                        Logger.Good("64Bit Reg: DefaultDomainName: null");
                    }
                    regKey64.Close();
                }
                catch (Exception)
                {
                    Logger.Warning("Failed to modify the WinLogon key in the 64Bit registry.");
                }
                Logger.Log("Done.");
            });
        }
    }
}
