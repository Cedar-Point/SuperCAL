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
        public static async Task Join(string NewName)
        {
            Logger.Log("Adding computer to the domain as " + NewName + ": Please wait...");
            while (!OnDomain())
            {
                if (NewName == Environment.MachineName)
                {
                    await Misc.RunPowershell("Add-Computer -DomainName '" + DomainName + "' -Force -Options AccountCreate -Credential 'domain\\username' -OUPath '" + OU + "'");
                }
                else
                {
                    Logger.Log("Join: Mismatch.");
                    await Misc.RunPowershell("Add-Computer -DomainName '" + DomainName + "' -Force -Options AccountCreate -Credential 'domain\\username' -OUPath '" + OU + "' -NewName '" + NewName + "'");
                }
            }
            Logger.Good("Joined.");
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