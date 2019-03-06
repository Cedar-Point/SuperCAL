using System;
using System.Drawing;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Windows.Forms;
using Microsoft.Win32;

namespace SuperCAL
{
    public partial class IPConfig : Form
    {
        public IPConfig()
        {
            InitializeComponent();

            IPInput = new IPInputBox(UseIPGroup);
            SubnetInput = new IPInputBox(UseIPGroup);
            DGInput = new IPInputBox(UseIPGroup);

            IPInput.TabIndex = 60;
            SubnetInput.TabIndex = 65;
            DGInput.TabIndex = 70;

            IPInput.Location = new Point(185, 30);
            SubnetInput.Location = new Point(185, 60);
            DGInput.Location = new Point(185, 90);

            DNSInput1 = new IPInputBox(dnsGroup);
            DNSInput2 = new IPInputBox(dnsGroup);

            DNSInput1.TabIndex = 80;
            DNSInput2.TabIndex = 85;

            DNSInput1.Location = new Point(185, 30);
            DNSInput2.Location = new Point(185, 60);

            NetworkChange.NetworkAddressChanged += NetworkChange_NetworkAddressChanged;

            InitializeAdapterList();

        }


        private bool AllowInterfaceUpdate = true;
        private NetworkInterface[] networkInterfaces = null;
        private IPInputBox IPInput = null;
        private IPInputBox SubnetInput = null;
        private IPInputBox DGInput = null;
        private IPInputBox DNSInput1 = null;
        private IPInputBox DNSInput2 = null;

        private void InitializeAdapterList()
        {
            networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface netInterface in networkInterfaces)
            {
                adaptersDropDown.Items.Add(netInterface.Name);
            }
        }

        private void GetCurrentInterface()
        {
            if (!AllowInterfaceUpdate) return;
            networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
            NetworkInterface cInterface = null;
            foreach(NetworkInterface networkInt in networkInterfaces)
            {
                if(networkInt.Name == (string)adaptersDropDown.SelectedItem)
                {
                    cInterface = networkInt;
                    break;
                }
            }
            IPInterfaceProperties cInterfaceProperties = cInterface.GetIPProperties();
            IPv4InterfaceProperties cV4InterfaceProperties = cInterfaceProperties.GetIPv4Properties();
            
            string nameServer = (string)Registry.LocalMachine.OpenSubKey(@"SYSTEM\ControlSet001\Services\Tcpip\Parameters\Interfaces\" + cInterface.Id, false).GetValue("NameServer");
            DHCP_IP(cV4InterfaceProperties.IsDhcpEnabled);
            DHCP_DNS(nameServer == "");

            foreach (UnicastIPAddressInformation addressInfo in cInterfaceProperties.UnicastAddresses)
            {
                if (addressInfo.Address.AddressFamily == AddressFamily.InterNetwork)
                {
                    IPInput.IPAddress = addressInfo.Address;
                    SubnetInput.IPAddress = addressInfo.IPv4Mask;
                    break;
                }
            }
            bool gwIsSet = false;
            foreach (GatewayIPAddressInformation gatewayInfo in cInterfaceProperties.GatewayAddresses)
            {
                if (gatewayInfo.Address.AddressFamily == AddressFamily.InterNetwork)
                {
                    DGInput.IPAddress = gatewayInfo.Address;
                    gwIsSet = true;
                    break;
                }
            }
            if (!gwIsSet)
            {
                DGInput.IPAddress = IPAddress.Parse("0.0.0.0");
            }
            int dnsCount = 0;
            foreach (IPAddress dnsAddress in cInterfaceProperties.DnsAddresses)
            {
                if (dnsAddress.AddressFamily == AddressFamily.InterNetwork)
                {
                    if (dnsCount == 0)
                    {
                        DNSInput1.IPAddress = dnsAddress;
                        DNSInput2.IPAddress = IPAddress.Parse("0.0.0.0");
                    }
                    else if (dnsCount == 1)
                    {
                        DNSInput2.IPAddress = dnsAddress;
                    }
                    else
                    {
                        break;
                    }
                    dnsCount++;
                }
            }
            if (dnsCount == 0)
            {
                DNSInput1.IPAddress = DNSInput2.IPAddress = IPAddress.Parse("0.0.0.0");
            }
        }

        private void DHCP_IP(bool enable, bool select = true)
        {
            if (enable)
            {
                if (select) DHCPRadio.Select();
                UseIPGroup.Enabled = false;
                DNSAutoRadio.Enabled = true;
            }
            else
            {
                if (select) StaticRadio.Select();
                DNSStaticRadio.Select();
                UseIPGroup.Enabled = true;
                DNSAutoRadio.Enabled = false;
            }
        }

        private void DHCP_DNS(bool enable, bool select = true)
        {
            if (enable)
            {
                if (select) DNSAutoRadio.Select();
                dnsGroup.Enabled = false;
            }
            else
            {
                if (select) DNSStaticRadio.Select();
                dnsGroup.Enabled = true;
            }
        }

        private async void SetIPConfig()
        {
            AllowInterfaceUpdate = false;
            Enabled = false;
            if (DHCPRadio.Checked)
            {
                await Misc.RunCMD("netsh.exe interface ipv4 set address \"" + adaptersDropDown.SelectedItem + "\" source=dhcp");
            }
            if (StaticRadio.Checked)
            {
                await Misc.RunCMD(
                    "netsh.exe interface ipv4 set address " +
                    " \"" + adaptersDropDown.SelectedItem +
                    "\" static " + IPInput.IPAddress.ToString() +
                    " " + SubnetInput.IPAddress.ToString() + 
                    " " + DGInput.IPAddress.ToString()
                );
            }
            if (DNSAutoRadio.Checked)
            {
                await Misc.RunCMD("netsh.exe interface ipv4 set dnsservers \"" + adaptersDropDown.SelectedItem + "\" source=dhcp");
            }
            if (DNSStaticRadio.Checked)
            {
                await Misc.RunCMD("netsh.exe interface ipv4 set dnsservers \"" + adaptersDropDown.SelectedItem + "\" static " + DNSInput1.IPAddress.ToString());
                await Misc.RunCMD("netsh.exe interface ipv4 add dnsservers \"" + adaptersDropDown.SelectedItem + "\" " + DNSInput2.IPAddress.ToString());
            }
            AllowInterfaceUpdate = true;
            GetCurrentInterface();
            Enabled = true;
        }

        private void NetworkChange_NetworkAddressChanged(object sender, EventArgs e)
        {
            Invoke(new Action(() => {
                GetCurrentInterface();
            }));
        }

        private void OSKButton_Click(object sender, EventArgs e)
        {
            Misc.RunCMD(@"C:\Windows\System32\osk.exe");
        }

        private void adaptersDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetCurrentInterface();
        }

        private void DHCPRadio_CheckedChanged(object sender, EventArgs e)
        {
            DHCP_IP(true, false);
        }

        private void StaticRadio_CheckedChanged(object sender, EventArgs e)
        {
            DHCP_IP(false, false);
        }

        private void DNSAutoRadio_CheckedChanged(object sender, EventArgs e)
        {
            DHCP_DNS(true, false);
        }

        private void DNSStaticRadio_CheckedChanged(object sender, EventArgs e)
        {
            DHCP_DNS(false, false);
        }

        private void ApplyBtn_Click(object sender, EventArgs e)
        {
            SetIPConfig();
        }
    }
}
