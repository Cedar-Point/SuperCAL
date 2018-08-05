using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.IO;

namespace SuperCAL
{
    class Wipe
    {
        public static string EGatewayURL = "";
        public static string EGatewayHost = "";
        private static Dictionary<string, object> RegDictionary = null;
        private static string MicrosRegRoot = @"SOFTWARE\MICROS";
        public async static Task Do(bool softWipe = false)
        {
            if (McrsCalSrvc.IsRunning())
            {
                await McrsCalSrvc.Stop();
            }
            await Task.Run(() => {
                RegDictionary = new Dictionary<string, object>
                {
                    ["ActiveHostIpAddress"] = EGatewayURL,
                    ["ActiveHost"] = EGatewayHost,
                    ["POSType"] = 101
                };
                if(softWipe)
                {
                    SaveImportantKeys(false);
                    SaveImportantKeys(true);
                }
                DeleteDirectory(@"C:\Micros\Simphony");
                RegClear(false);
                RegClear(true);
                if(softWipe)
                {
                    Logger.Log("Adding HwConfigured value to the CAL registry key...");
                    try
                    {
                        RegistryKey regKey32 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey(MicrosRegRoot + @"\CAL", true);
                        regKey32.SetValue("HwConfigured", 1);
                        regKey32.Close();
                    }
                    catch (Exception)
                    {
                        Logger.Warning("Failed to set HwConfigured key in the 32 bit hive.");
                    }
                    try
                    {
                        RegistryKey regKey64 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(MicrosRegRoot + @"\CAL", true);
                        regKey64.SetValue("HwConfigured", 1);
                        regKey64.Close();
                    }
                    catch (Exception)
                    {
                        Logger.Warning("Failed to set HwConfigured key in the 64 bit hive.");
                    }
                    Logger.Good("Done.");
                }
            });
            await McrsCalSrvc.Start();
        }
        public static void DeleteDirectory(string path)
        {
            if(Directory.Exists(path))
            {
                string[] files = Directory.EnumerateFiles(path).ToArray();
                if (files.Length != 0)
                {
                    foreach(string file in files)
                    {
                        File.Delete(file);
                        Logger.Good(file + ": Deleted.");
                    }
                }
                string[] dirs = Directory.EnumerateDirectories(path).ToArray();
                if(dirs.Length != 0)
                {
                    foreach(string dir in dirs)
                    {
                        DeleteDirectory(dir);
                    }
                }
                Directory.Delete(path);
                Logger.Good(path + ": Deleted.");
            }
        }
        private static void RegClear(bool bit64)
        {
            RegistryView view = RegistryView.Registry32;
            string bit = "32";
            if (bit64)
            {
                bit = "64";
            }
            if (bit64)
            {
                view = RegistryView.Registry64;
            }
            try
            {
                RegistryKey regKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, view).OpenSubKey(MicrosRegRoot, true);
                regKey.DeleteSubKeyTree("CAL");
                RegistryKey newKey = regKey.CreateSubKey(@"CAL\Config");
                regKey.Close();
                foreach (KeyValuePair<string, object> kv in RegDictionary)
                {
                    newKey.SetValue(kv.Key, kv.Value);
                    Logger.Good(bit + "Bit Reg: " + kv.Key + ": " + kv.Value);
                }
                newKey.Close();
            }
            catch (Exception)
            {
                Logger.Warning("Failed to modify the Micros key in the " + bit + " bit registry.");
            }
        }
        private static void SaveImportantKeys(bool bit64)
        {
            RegistryView view = RegistryView.Registry32;
            string bit = "32";
            if (bit64)
            {
                view = RegistryView.Registry64;
                bit = "64";
            }
            try
            {
                Logger.Log("Trying to save the " + bit + " bit registry.");
                RegistryKey regKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, view).OpenSubKey(MicrosRegRoot + @"\CAL\Config", false);
                object DeviceId = regKey.GetValue("DeviceId");
                if (DeviceId != null)
                {
                    RegDictionary["DeviceId"] = DeviceId;
                }
                object ProductType = regKey.GetValue("ProductType");
                if (ProductType != null)
                {
                    RegDictionary["ProductType"] = ProductType;
                }
                object ServiceHostId = regKey.GetValue("ServiceHostId");
                if (ServiceHostId != null)
                {
                    RegDictionary["ServiceHostId"] = ServiceHostId;
                }
                object WSId = regKey.GetValue("WSId");
                if (WSId != null)
                {
                    RegDictionary["WSId"] = WSId;
                }
                regKey.Close();
            }
            catch (Exception)
            {
                Logger.Warning("Failed to save the Micros key in the " + bit + " bit registry.");
            }
        }
    }
}
