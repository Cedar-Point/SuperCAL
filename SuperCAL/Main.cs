using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing;

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
                if(await DomainJoin.Join())
                {
                    await Misc.InstallScheduledTask(null);
                    await Misc.InstallScheduledTask(Properties.Resources.SuperCALPhaseThree);
                    await Misc.SetAutoLogon(true);
                    Misc.RestartWindows();
                }
            }
            else if(Program.Arguments.Length != 0 && Program.Arguments[0] == "3")
            {
                Table.Enabled = false;
                Logger.Log("Phase three: Checking for auto-logon...");
                if(Misc.IsAutoLogonSet())
                {
                    Logger.Log("AutoLogon found! Removing scheduled task...");
                    await Misc.InstallScheduledTask(null);
                    Close();
                }
                else
                {
                    Logger.Warning("AutoLogon not set! Requesting GPUPDATE to run synchronously on next boot...");
                    await Misc.RunCMD("gpupdate.exe /sync");
                    Misc.RestartWindows();
                }
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
            await Misc.InstallScheduledTask(Properties.Resources.SuperCALPhaseTwo);
            await DomainJoin.Leave();
            await Misc.SetAutoLogon(false);
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
            Logger.Log("Super CAL V" + Application.ProductVersion + ", by Dylan Bickerstaff.");
        }

        private void LogRTB_DoubleClick(object sender, EventArgs e)
        {
            if(MenuBar.Visible)
            {
                LogRTB.Location = new Point(LogRTB.Location.X, 80);
                LogRTB.Height += 25;
                MenuBar.Visible = false;
            }
            else
            {
                LogRTB.Location = new Point(LogRTB.Location.X, 105);
                LogRTB.Height -= 25;
                MenuBar.Visible = true;
            }
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
            await Misc.InstallScheduledTask(Properties.Resources.SuperCALPhaseTwo);
        }

        private async void RmvStartTaskButton_Click(object sender, EventArgs e)
        {
            await Misc.InstallScheduledTask(null);
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

        private void RebootWindows_Click(object sender, EventArgs e)
        {
            Misc.RestartWindows();
        }

        private async void DisableAutoLogon_Click(object sender, EventArgs e)
        {
            await Misc.SetAutoLogon(false);
        }

        private async void EnableAutoLogon_Click(object sender, EventArgs e)
        {
            await Misc.SetAutoLogon(true);
        }

        private async void AddStartupTaskP2_Click(object sender, EventArgs e)
        {
            await Misc.InstallScheduledTask(Properties.Resources.SuperCALPhaseThree);
        }

        private async void RemoveStartupTaskP2_Click(object sender, EventArgs e)
        {
            await Misc.InstallScheduledTask(null);
        }
    }
}
