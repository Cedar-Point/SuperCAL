using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace SuperCAL
{
    class Wipe
    {
        public static Task Do()
        {
            return Task.Run(() => {
                string MicrosRegRoot = @"SOFTWARE\MICROS";
                Dictionary<string, object> r = new Dictionary<string, object>
                {
                    ["ActiveHostIpAddress"] = "http://cp-simapp:8080/EGateway/EGateway.asmx",
                    ["ActiveHost"] = "cp-simapp",
                    ["POSType"] = 101
                };

                RegistryKey McrsReg32 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey(MicrosRegRoot, true);
                RegistryKey McrsReg64 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(MicrosRegRoot, true);
                McrsReg32.DeleteSubKeyTree("CAL");
                McrsReg64.DeleteSubKeyTree("CAL");
                RegistryKey RegCfg32 = McrsReg32.CreateSubKey(@"CAL\Config");
                RegistryKey RegCfg64 = McrsReg64.CreateSubKey(@"CAL\Config");
                McrsReg32.Close();
                McrsReg64.Close();
                foreach (KeyValuePair<string, object> kv in r)
                {
                    RegCfg32.SetValue(kv.Key, kv.Value);
                    RegCfg64.SetValue(kv.Key, kv.Value);
                    Logger.Good(MicrosRegRoot + @"\" + kv.Key + ": " + kv.Value);
                }
                RegCfg32.Close();
                RegCfg64.Close();
            });
        }
    }
}
