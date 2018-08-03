using System;
using System.Management;
using System.Threading.Tasks;
using System.Diagnostics;
using System.DirectoryServices.ActiveDirectory;

namespace SuperCAL
{
    class DomainJoin
    {
        public static Task Join(string NewName)
        {
            string DN = "ad.cedarfair.com";
            string OU = "OU=Micros,OU=CP,DC=ad,DC=cedarfair,DC=com";
            string Script = "Add-Computer -DomainName \"" + DN + "\" -Options AccountCreate -Credential \"domain\\username\" -OUPath \"" + OU + "\" -NewName \"" + NewName + "\"";
            Logger.Log("Adding computer to the domain as " + NewName + ": Please wait for credential prompt...");
            return Task.Run(() => {
                Process ps = new Process();
                ps.StartInfo.FileName = "powershell.exe";
                ps.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                ps.StartInfo.Arguments = "-Command " + Script;
                ps.Start();
                ps.WaitForExit();
                Logger.Good("Done!");
            });
        }
        public static Task Leave()
        {
            string Script = "Add-Computer -WorkGroupName WORKGROUP";
            Logger.Log("Joining workgroup...");
            return Task.Run(() => {
                Process ps = new Process();
                ps.StartInfo.FileName = "powershell.exe";
                ps.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                ps.StartInfo.Arguments = "-Command " + Script;
                ps.Start();
                ps.WaitForExit();
                Logger.Good("Done!");
            });
        }
        private static bool OnDomain()
        {
            try
            {
                Domain.GetComputerDomain();
                return true;
            }
            catch(ActiveDirectoryObjectNotFoundException)
            {
                return false;
            }
        }
    }
}