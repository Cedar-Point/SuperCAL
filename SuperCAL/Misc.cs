using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SuperCAL
{
    class Misc
    {
        public static Task SetAutoLogon(bool normalize = false)
        {
            Logger.Log("Setting auto logon for next boot...");
            return Task.Run(() =>
            {
                string username = "cp.admin";
                string password = "@xQ6u5Gb26A";
                string fileName = Process.GetCurrentProcess().MainModule.FileName;
                string WinLogonRoot = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon";
                
                RegistryKey WlgReg32 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey(WinLogonRoot, true);
                RegistryKey WlgReg64 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(WinLogonRoot, true);
                if (normalize)
                {
                    WlgReg32.SetValue("DefaultDomain", "");
                    WlgReg64.SetValue("DefaultDomain", "");
                    WlgReg32.SetValue("DefaultUserName", "");
                    WlgReg64.SetValue("DefaultUserName", "");
                    WlgReg32.SetValue("DefaultPassword", "");
                    WlgReg64.SetValue("DefaultPassword", "");
                    WlgReg32.SetValue("AutoAdminLogon", "0");
                    WlgReg64.SetValue("AutoAdminLogon", "0");
                    WlgReg32.SetValue("Userinit", @"C:\Windows\system32\userinit.exe,");
                    WlgReg64.SetValue("Userinit", @"C:\Windows\system32\userinit.exe,");
                }
                else
                {
                    WlgReg32.SetValue("DefaultDomain", ".");
                    WlgReg64.SetValue("DefaultDomain", ".");
                    WlgReg32.SetValue("DefaultUserName", username);
                    WlgReg64.SetValue("DefaultUserName", username);
                    WlgReg32.SetValue("DefaultPassword", password);
                    WlgReg64.SetValue("DefaultPassword", password);
                    WlgReg32.SetValue("AutoAdminLogon", "1");
                    WlgReg64.SetValue("AutoAdminLogon", "1");
                    WlgReg32.SetValue("Userinit", fileName + " 0,");
                    WlgReg64.SetValue("Userinit", fileName + " 0,");
                }
                WlgReg32.Close();
                WlgReg64.Close();
                Logger.Good("Auto logon set.");
            });
        }
        public static string GetCalNameFromRegistry()
        {
            string MicrosRegRoot = @"SOFTWARE\MICROS\CAL\Config";
            RegistryKey McrsReg32 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey(MicrosRegRoot, true);
            RegistryKey McrsReg64 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(MicrosRegRoot, true);
            string devId32 = (string)McrsReg32.GetValue("DeviceId");
            string devId64 = (string)McrsReg64.GetValue("DeviceId");
            McrsReg32.Close();
            McrsReg64.Close();
            if (devId32 != null)
            {
                return devId32;
            }
            if (devId64 != null)
            {
                return devId32;
            }
            return "";
        }
        public static void RestartWindows()
        {
            Logger.Log("Restarting windows...");
            Process.Start("shutdown.exe", "-r -t 0");
        }
    }
}
