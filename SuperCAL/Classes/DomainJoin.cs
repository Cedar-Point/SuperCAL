using System.Threading.Tasks;
using System.DirectoryServices.ActiveDirectory;
using System.DirectoryServices;
using System;
using System.Net.NetworkInformation;

namespace SuperCAL
{
    class DomainJoin
    {
        public static string DomainName = "";
        public static string OU = "";
        public static async Task<bool> Join()
        {
            /*
            Ping ping = new Ping();
            Logger.Log("Pinging " + DomainName + "...");
            PingReply reply = null;
            try
            {
                reply = await ping.SendPingAsync(DomainName);
            }
            catch (PingException)
            {
                Logger.Error("Ping: Unknown Failure. (Usually a failed hostname lookup)");
            }
            if (reply == null || reply.Status != IPStatus.Success)
            {
                if (reply != null)
                {
                    Logger.Error("Ping: " + reply.Status.ToString() + '.');
                }
                Logger.Log("\n\nTo help resolve network issues, check the IP settings by double pressing anywhere on SuperCAL, and then by selecting \"Tools\" -> \"IP Configuration\"");
                return false;
            }
            Logger.Good("Ping: Success.");
            */
            Logger.Log("Adding computer to domain (" + DomainName + ") in container (" + OU + ")  as (" + Environment.MachineName + "): Please wait...");
            int tries = 4;
            bool popKeyboard = false;
            while (!OnDomain() && tries-- != 0)
            {
                if(popKeyboard)
                {
                    Logger.Log("Starting On Screen Keyboard...");
                    #pragma warning disable
                    Misc.RunCMD(@"C:\Windows\System32\osk.exe");
                    #pragma warning restore
                }
                await Misc.RunPowershell("Add-Computer -DomainName '" + DomainName + "' -Force -Options AccountCreate -Credential 'domain\\username' -OUPath '" + OU + "'");
                popKeyboard = true;
            }
            if(OnDomain())
            {
                Logger.Good("Joined.");
                return true;
            }
            else
            {
                Logger.Error("Failed to join domain! Too many failed attempts!");
                return false;
            }
        }
        public static async Task Leave()
        {
            Logger.Log("Installing netdom...");
            await Misc.InstallNetdom();
            Logger.Log("Leaving domain...");
            await Misc.RunCMD("netdom.exe remove localhost /Force");
            Logger.Good("Done.");
        }
        private static bool OnDomain()
        {
            try
            {
                Domain.GetComputerDomain();
                return true;
            }
            catch(Exception e)
            {
                if(e.InnerException is DirectoryServicesCOMException)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}