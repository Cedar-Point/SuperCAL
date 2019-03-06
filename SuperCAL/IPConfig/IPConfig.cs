using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperCAL
{
    public partial class IPConfig : Form
    {
        public IPConfig()
        {
            InitializeComponent();
            
            IPInputBox IPInput = new IPInputBox(useIPGroup);
            IPInputBox SubnetInput = new IPInputBox(useIPGroup);
            IPInputBox DGInput = new IPInputBox(useIPGroup);

            IPInput.TabIndex = 60;
            SubnetInput.TabIndex = 65;
            DGInput.TabIndex = 70;

            IPInput.Location = new Point(185, 30);
            SubnetInput.Location = new Point(185, 60);
            DGInput.Location = new Point(185, 90);

            IPInputBox DNS1 = new IPInputBox(dnsGroup);
            IPInputBox DNS2 = new IPInputBox(dnsGroup);

            DNS1.TabIndex = 80;
            DNS2.TabIndex = 85;

            DNS1.Location = new Point(185, 30);
            DNS2.Location = new Point(185, 60);

            InitializeAdapterList();

        }

        private NetworkInterface[] networkInterfaces = null;

        private void InitializeAdapterList()
        {
            networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
            foreach(NetworkInterface netInterface in networkInterfaces)
            {
                adaptersDropDown.Items.Add(netInterface.Name);
            }
        }

        private void GetCurrentInterface()
        {
            if(networkInterfaces[adaptersDropDown.SelectedIndex].GetIPProperties().GetIPv4Properties().IsDhcpEnabled)
            {
                DHCPRadio.Select();
            }
        }

        private void OSKButton_Click(object sender, EventArgs e)
        {
            Misc.RunCMD(@"C:\Windows\System32\osk.exe");
        }

        private void adaptersDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetCurrentInterface();
        }
    }
}
