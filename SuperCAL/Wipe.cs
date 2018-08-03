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
        public async static Task Do()
        {
            if (McrsCalSrvc.IsRunning())
            {
                await McrsCalSrvc.Stop();
            }
            await Task.Run(() => {
                string MicrosRegRoot = @"SOFTWARE\MICROS";
                Dictionary<string, object> r = new Dictionary<string, object>
                {
                    ["ActiveHostIpAddress"] = "http://cp-simapp:8080/EGateway/EGateway.asmx",
                    ["ActiveHost"] = "cp-simapp",
                    ["POSType"] = 101
                };
                deleteDirectory(@"C:\Micros\Simphony");
                try
                {
                    RegistryKey McrsReg32 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey(MicrosRegRoot, true);
                    McrsReg32.DeleteSubKeyTree("CAL");
                    RegistryKey RegCfg32 = McrsReg32.CreateSubKey(@"CAL\Config");
                    McrsReg32.Close();
                    foreach (KeyValuePair<string, object> kv in r)
                    {
                        RegCfg32.SetValue(kv.Key, kv.Value);
                        Logger.Good(MicrosRegRoot + @"\" + kv.Key + ": " + kv.Value);
                    }
                    RegCfg32.Close();
                }
                catch (Exception)
                {
                    Logger.Warning("Failed to modify the Micros key in the 32 bit registry.");
                }
                try
                {
                    RegistryKey McrsReg64 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(MicrosRegRoot, true);
                    McrsReg64.DeleteSubKeyTree("CAL");
                    RegistryKey RegCfg64 = McrsReg64.CreateSubKey(@"CAL\Config");
                    McrsReg64.Close();
                    foreach (KeyValuePair<string, object> kv in r)
                    {
                        RegCfg64.SetValue(kv.Key, kv.Value);
                        Logger.Good(MicrosRegRoot + @"\" + kv.Key + ": " + kv.Value);
                    }
                    RegCfg64.Close();
                }
                catch (Exception)
                {
                    Logger.Warning("Failed to modify the Micros key in the 64 bit registry.");
                }
            });
            await McrsCalSrvc.Start();
        }
        public static void deleteDirectory(string path)
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
                        deleteDirectory(dir);
                    }
                }
                Directory.Delete(path);
                Logger.Good(path + ": Deleted.");
            }
        }
    }
}
