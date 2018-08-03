using System.Threading.Tasks;
using System.DirectoryServices.ActiveDirectory;

namespace SuperCAL
{
    class DomainJoin
    {
        public static string DomainName = "";
        public static string OU = "";
        public static async Task Join(string NewName)
        {
            Logger.Log("Adding computer to the domain as " + NewName + ": Please wait for credential prompt...");
            await Misc.RunPowershell("Add-Computer -DomainName \"" + DomainName + "\" -Force -Options AccountCreate -Credential \"domain\\username\" -OUPath \"" + OU + "\" -NewName \"" + NewName + "\"");
            Logger.Log("Done.");
        }
        public static async Task Leave()
        {
            Logger.Log("Joining workgroup...");
            await Misc.RunPowershell("Add-Computer -Force -WorkGroupName WORKGROUP");
            Logger.Log("Done.");
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