using System.Xml.Linq;

namespace SuperCAL
{
    class Config
    {
        public static void GenerateConfig()
        {
            new XDocument(new XElement("SuperCAL",
                new XElement("EGatewayURL", "http://simphony:8080/EGateway/EGateway.asmx"),
                new XElement("EGatewayHostName", "simphony"),
                new XElement("DomainJoinDomain", "ad.contoso.com"),
                new XElement("DomainJoinOU", "OU=Micros,DC=ad,DC=contoso,DC=com"),
                new XElement("AutoLogonUserName", "username"),
                new XElement("AutoLogonPassword", "password"),
                new XElement("AutoLogonADDomain", "addomain")
            )).Save("SuperCAL.xml");
        }
        public static void ReadConfig()
        {
            XElement root = XDocument.Load("SuperCAL.xml").Root;
            Wipe.EGatewayURL = root.Element("EGatewayURL").Value;
            Wipe.EGatewayHost = root.Element("EGatewayHostName").Value;
            DomainJoin.DomainName = root.Element("DomainJoinDomain").Value;
            DomainJoin.OU = root.Element("DomainJoinOU").Value;
            Misc.AutoLogonUserName = root.Element("AutoLogonUserName").Value;
            Misc.AutoLogonPassword = root.Element("AutoLogonPassword").Value;
            Misc.AutoLogonADDomain = root.Element("AutoLogonADDomain").Value;
        }
    }
}
