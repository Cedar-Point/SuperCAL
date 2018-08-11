using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Text;

namespace SuperCAL
{
    public partial class Main : Form
    {
        public Timer topTimer = new Timer();

        public Main()
        {
            InitializeComponent();
            Logger.LogRTB = LogRTB;
            topTimer.Interval = 1000;
            topTimer.Tick += TopTimer_Tick;
            topTimer.Start();
            McrsCalSrvc.StopStartCAL = StopStartCAL;
            McrsCalSrvc.Table = Table;
        }

        private void TopTimer_Tick(object sender, EventArgs e)
        {
            BringToFront();
        }

        private async void Window_Load(object sender, EventArgs e)
        {
            if (Program.Arguments.Length != 0 && Program.Arguments[0] == "0")
            {
                Table.Enabled = false;
                Logger.Log("Phase two: Join domain...");
                await DomainJoin.Join();
                await Misc.InstallPhaseTwo(false);
                Misc.RestartWindows();
            }
            else
            {
                Logger.Log("Welcome to Super CAL: Press any button to begin.");
                if (McrsCalSrvc.IsRunning())
                {
                    Logger.Good("CAL Service is running.");
                    StopStartCAL.Text = "Stop CAL";
                }
                else
                {
                    Logger.Warning("CAL Service is not running.");
                    StopStartCAL.Text = "Start CAL";
                }
            }
        }

        private async void StopStartCAL_Click(object sender, EventArgs e)
        {
            await McrsCalSrvc.ToggleCal();
        }

        private async void ReCAL_Click(object sender, EventArgs e)
        {
            await Misc.InstallPhaseTwo();
            await DomainJoin.Leave();
            await Wipe.Do();
            CenterToScreen();
            Left = Left - 440;
            await McrsCalSrvc.Start();
        }

        private async void ReDownloadCAL_Click(object sender, EventArgs e)
        {
            await Wipe.Do(true);
            await McrsCalSrvc.Start();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logger.Log("Super CAL V" + Application.ProductVersion + ", by Dylan Bickerstaff Aug 2018.");
        }

        private void LogRTB_DoubleClick(object sender, EventArgs e)
        {
            LogRTB.Location = new Point(LogRTB.Location.X, 105);
            LogRTB.Height -= 25;
            MenuBar.Visible = true;
        }

        private void TaskMgrButton_Click(object sender, EventArgs e)
        {
            Logger.Log("Starting Task Manager...");
            Process.Start(Misc.System32Path() + "taskmgr.exe");
        }

        private void CMDButton_Click(object sender, EventArgs e)
        {
            Logger.Log("Starting Command Prompt...");
            Process.Start(Misc.System32Path() + "cmd.exe");
        }

        private void OSKButton_Click(object sender, EventArgs e)
        {
            Logger.Log("Starting On Screen Keyboard...");
            Misc.RunCMD(@"C:\Windows\System32\osk.exe");
        }

        private async void WipeCalButton_Click(object sender, EventArgs e)
        {
            await Wipe.Do();
        }

        private async void WipeKeepCalButton_Click(object sender, EventArgs e)
        {
            await Wipe.Do(true);
        }

        private async void AddSrtTaskButton_Click(object sender, EventArgs e)
        {
            await Misc.InstallPhaseTwo();
        }

        private async void RmvStartTaskButton_Click(object sender, EventArgs e)
        {
            await Misc.InstallPhaseTwo(false);
        }

        private async void JoinDomainButton_Click(object sender, EventArgs e)
        {
            await DomainJoin.Join();
        }

        private async void JoinWorkButton_Click(object sender, EventArgs e)
        {
            await DomainJoin.Leave();
        }

        private async void NetDomButton_Click(object sender, EventArgs e)
        {
            await Misc.InstallNetdom();
        }
    }
}
