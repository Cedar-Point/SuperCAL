using System.Threading.Tasks;
using System.DirectoryServices.ActiveDirectory;
using System.DirectoryServices;
using System;

namespace SuperCAL
{
    class DomainJoin
    {
        public static string DomainName = "";
        public static string OU = "";
        public static async Task<bool> Join()
        {
            bool popKeyboard = false;
            Logger.Log("Adding computer to domain (" + DomainName + ") in container (" + OU + ")  as (" + Environment.MachineName + "): Please wait...");
            int tries = 2;
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