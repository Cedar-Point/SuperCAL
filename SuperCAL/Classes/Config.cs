using System.Xml.Linq;
using System.IO;
using System;
using System.Collections.Generic;

namespace SuperCAL
{
    public static class Config
    {
        public static void GenerateConfig()
        {
            Config2.SaveConfig();
        }
        public static void ReadConfig()
        {
            Config2.LoadConfig();
            Wipe.EGatewayURL = Config2.Settings["EGatewayURL"];
            Wipe.EGatewayHost = Config2.Settings["EGatewayHostName"];
            DomainJoin.DomainName = Config2.Settings["DomainJoinDomain"];
            DomainJoin.OU = Config2.Settings["DomainJoinOU"];
            Misc.AutoLogonUserName = Config2.Settings["AutoLogonUserName"];
            Misc.AutoLogonPassword = Config2.Settings["AutoLogonPassword"];
            Misc.AutoLogonADDomain = Config2.Settings["AutoLogonADDomain"];
            Pin.UnlockMessage = Config2.Settings["UnlockMessage"];
            Pin.UnlockPin = Config2.Settings["UnlockPIN"];
        }
    }

    public static class Config2
    {
        public static Dictionary<string, string> Settings = new Dictionary<string, string>() {
            {"XComment1", @"The URL to the Micros EGateway Service."},
            {"EGatewayURL", @"http://simphony:8080/EGateway/EGateway.asmx"},

            {"XComment2", @"The EGateway Service Hostname."},
            {"EGatewayHostName", @"simphony"},

            {"XComment3", @"The AD domain to join during the RE-CAL process."},
            {"DomainJoinDomain", @"ad.contoso.com"},

            {"XComment4", @"The LDAP Path to the desired OU to join the PCs into."},
            {"DomainJoinOU", @"OU=Micros,DC=ad,DC=contoso,DC=com"},

            {"XComment5", @"The auto logon username (leave blank if GPO sets this automatically)."},
            {"AutoLogonUserName", @"username"},

            {"XComment6", @"The auto logon password (leave blank if GPO sets this automatically)."},
            {"AutoLogonPassword", @"password"},

            {"XComment7", @"The auto logon domain (leave blank if GPO sets this automatically)."},
            {"AutoLogonADDomain", @"ad.contoso.com"},

            {"XComment8", @"The message shown at the unlock screen."},
            {"UnlockMessage", @"Enter Unlock PIN"},

            {"XComment9", @"The pin for the unlock screen."},
            {"UnlockPIN", @"1234"},

            {"XComment10", @"Pipe delimited list of folders to delete on re-cal / re-download. (Example: C:\Folder1|C:\Folder2 )"},
            {"FoldersToDelete", @"C:\Micros\Simphony"},

            {"XComment11", @"Pipe delimited list of files to delete on re-cal / re-download. (Example: C:\File1.txt|C:\File2.txt )"},
            {"FilesToDelete", @""},

            {"XComment13", @"Pipe delimited list of processes to stop on re-cal / re-download. (Example: Process1|Process2 )"},
            {"ProcessesToStop", @"WIN7CALStart|SarOpsWin32|KDSDisplay"},

            {"XComment14", @"Pipe delimited list of services to stop on re-cal / re-download excluding 'Micros Cal Client'. (Example: Service1|Service2 )"},
            {"ServicesToStop", @"World Wide Web Publishing Service|MICROS KDS Controller"},

            {"XComment15", @"Pipe delimited list of services to start after re-cal / re-download excluding 'Micros Cal Client'. (Example: Service1|Service2 )"},
            {"ServicesToStart", @"World Wide Web Publishing Service|MICROS KDS Controller"}
        };
        public static Dictionary<string, string> DefaultSettings = Settings;
        public static void SaveConfig()
        {
            Logger.Log("Generating SuperCAL.xml...");
            XElement root = new XElement("SuperCAL");
            foreach (KeyValuePair<string, string> setting in Settings)
            {
                if (setting.Key.StartsWith("XComment"))
                {
                    root.Add(new XComment(setting.Value));
                }
                else
                {
                    root.Add(new XElement(setting.Key, setting.Value));
                }
            }
            try
            {
                new XDocument(root).Save(@".\SuperCAL.xml");
                Logger.Good("Saved.");
            }
            catch (Exception)
            {
                Logger.Error("Failed to save the configuration!");
            }
        }
        public static bool CanSaveConfig()
        {
            try
            {
                File.OpenWrite(@".\SuperCAL.xml").Close();
                FileAttributes fa = File.GetAttributes(@".\SuperCAL.xml");
                if (fa.HasFlag(FileAttributes.Hidden)) return false;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static void LoadConfig(string[] parameters = null)
        {
            if (!File.Exists(@".\SuperCAL.xml"))
            {
                SaveConfig();
            }
            try
            {
                XDocument config = XDocument.Load(@".\SuperCAL.xml");
                XElement root = config.Element("SuperCAL");
                bool success = true;
                Dictionary<string, string> xmlSettings = new Dictionary<string, string>();
                foreach (KeyValuePair<string, string> setting in Settings)
                {
                    xmlSettings.Add(setting.Key, setting.Value);
                }
                foreach (KeyValuePair<string, string> setting in Settings)
                {
                    if (!setting.Key.StartsWith("XComment"))
                    {
                        XElement element = root.Element(setting.Key);
                        if (element == null)
                        {
                            success = false;
                            Logger.Warning("SuperCAL.xml is missing: " + setting.Key + "!");
                        }
                        else
                        {
                            xmlSettings[setting.Key] = element.Value;
                        }
                    }
                }
                Settings = xmlSettings;
                if (success)
                {
                    Logger.Good("Config loaded!");
                }
                else
                {
                    Logger.Warning("Config loaded, but is using default values for the missing elements.");
                }
            }
            catch (Exception)
            {
                Logger.Error("Error when loading the config file! SuperCAL.xml");
            }
            if (parameters != null && parameters.Length > 0)
            {
                foreach (string parameter in parameters)
                {
                    if (parameter.StartsWith("/") || parameter.StartsWith("-") && parameter.Contains(":"))
                    {
                        string[] param_parts = parameter.Substring(1).Split(':');
                        if (Settings.ContainsKey(param_parts[0]))
                        {
                            Settings[param_parts[0]] = param_parts[1];
                        }
                    }
                }
            }
        }
    }
}