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
            topTimer.Interval = 500;
            topTimer.Tick += TopTimer_Tick;
            topTimer.Start();
            McrsCalSrvc.StopStartCAL = StopStartCAL;
        }
        private void TopTimer_Tick(object sender, EventArgs e)
        {
            BringToFront();
        }
        private void Window_Load(object sender, EventArgs e)
        {
            bool allowContinue = true;
            if(Program.Arguments.Length != 0)
            {
                string firstArg = Program.Arguments[0].ToLower();
                if (firstArg == "0")
                {
                    PhaseTwo();
                    allowContinue = false;
                }
                if (firstArg == "3")
                {
                    PhaseThree();
                    allowContinue = false;
                }
                if (firstArg == "/recal" || firstArg == "-recal")
                {
                    Logger.Log("ReCAL: ReCAL Switch Passed in CLI, Starting ReCAL process...");
                    ReCAL.PerformClick();
                    allowContinue = false;
                }
                if (firstArg == "/redownload" || firstArg == "-redownload")
                {
                    Logger.Log("ReDownload: ReDownload Switch Passed in CLI, Starting ReDownload process...");
                    ReDownloadCAL.PerformClick();
                    allowContinue = false;
                }
            }
            if (allowContinue)
            {
                if (Pin.UnlockPin != "")
                {
                    Control pin = new Pin();
                    pin.Disposed += Pin_Disposed;
                    Controls.Add(pin);
                    pin.Width = ClientSize.Width;
                    pin.Height = ClientSize.Height;
                    pin.Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Left;
                    pin.BringToFront();
                    pin.Select();
                    pin.Show();
                }
                else
                {
                    if (McrsCalSrvc.IsRunning())
                    {
                        StopStartCAL.PerformClick();
                    }
                    else
                    {
                        StopStartCAL.Text = "Start CAL";
                    }
                    Menu = MenuBar;
                }
                Logger.Log("Welcome to Super CAL: Press any button to begin.");
            }
        }
        private void Pin_Disposed(object sender, EventArgs e)
        {
            if (McrsCalSrvc.IsRunning())
            {
                StopStartCAL.PerformClick();
            }
            else
            {
                StopStartCAL.Text = "Start CAL";
            }
            Menu = MenuBar;
        }
        private async void PhaseTwo()
        {
            Table.Enabled = false;
            Logger.Log("Phase two: Join domain...");
            if (await DomainJoin.Join())
            {
                await Misc.InstallScheduledTask(null, "2");
                await Misc.SetAutoLogon(true);
                if (!Misc.IsAutoLogonSet())
                {
                    await Misc.InstallScheduledTask(Properties.Resources.SuperCALPhaseThree, "3");
                }
                Misc.RestartWindows();
            }
            else
            {
                Logger.Log("\n\nIf you would like to retry this phase, double press anywhere on SuperCAL, and then select \"Actions\" -> \"Phase Two (Domain Join)\" -> \"Start Phase Two...\"");
            }
        }
        private async void PhaseThree()
        {
            Table.Enabled = false;
            Logger.Log("Phase three: Checking for auto-logon...");
            if (Misc.IsAutoLogonSet())
            {
                Logger.Log("AutoLogon found! Removing scheduled task...");
                await Misc.InstallScheduledTask(null, "3");
                Misc.RestartWindows();
            }
            else
            {
                Logger.Warning("AutoLogon not set!");
                Logger.Log("Running: gpupdate.exe /Target:Computer /Force /Wait:300");
                await Misc.RunCMD("gpupdate.exe /Target:Computer /Force /Wait:300");
                if (Misc.IsAutoLogonSet())
                {
                    Logger.Log("AutoLogon found! Removing scheduled task...");
                    await Misc.InstallScheduledTask(null, "3");
                }
                else
                {
                    Logger.Log("Running: gpupdate.exe /Target:Computer /Boot /Sync");
                    await Misc.RunCMD("gpupdate.exe /Target:Computer /Boot /Sync");
                }
                Misc.RestartWindows();
            }
        }
        private async void StopStartCAL_Click(object sender, EventArgs e)
        {
            Enabled = false;
            await McrsCalSrvc.ToggleCal();
            Enabled = true;
        }
        private async void ReCAL_Click(object sender, EventArgs e)
        {
            Enabled = false;
            await Misc.InstallScheduledTask(Properties.Resources.SuperCALPhaseTwo, "2");
            await DomainJoin.Leave();
            await Misc.SetAutoLogon(false);
            if (await Wipe.Do())
            {
                await McrsCalSrvc.Start();
                CenterToScreen();
                Left = Left - 440;
            }
            Enabled = true;
        }
        private async void ReDownloadCAL_Click(object sender, EventArgs e)
        {
            Enabled = false;
            if(await Wipe.Do(true))
            {
                await McrsCalSrvc.Start();
                CenterToScreen();
                Left = Left - 440;
            }
            Enabled = true;
        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logger.Log("Super CAL V" + Application.ProductVersion + ", by Dylan Bickerstaff.");
        }
        private void LogRTB_DoubleClick(object sender, EventArgs e)
        {
            if(Menu != null)
            {
                Menu = null;
            }
            else
            {
                Menu = MenuBar;
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
            Enabled = false;
            await Wipe.Do();
            Enabled = true;
        }
        private async void WipeKeepCalButton_Click(object sender, EventArgs e)
        {
            Enabled = false;
            await Wipe.Do(true);
            Enabled = true;
        }
        private async void AddSrtTaskButton_Click(object sender, EventArgs e)
        {
            Enabled = false;
            await Misc.InstallScheduledTask(Properties.Resources.SuperCALPhaseTwo, "2");
            Enabled = true;
        }
        private async void RmvStartTaskButton_Click(object sender, EventArgs e)
        {
            Enabled = false;
            await Misc.InstallScheduledTask(null, "2");
            Enabled = true;
        }
        private async void JoinDomainButton_Click(object sender, EventArgs e)
        {
            Enabled = false;
            await DomainJoin.Join();
            Enabled = true;
        }
        private async void JoinWorkButton_Click(object sender, EventArgs e)
        {
            Enabled = false;
            await DomainJoin.Leave();
            Enabled = true;
        }
        private async void NetDomButton_Click(object sender, EventArgs e)
        {
            Enabled = false;
            await Misc.InstallNetdom();
            Enabled = true;
        }
        private void RebootWindows_Click(object sender, EventArgs e)
        {
            Enabled = false;
            Misc.RestartWindows();
        }
        private async void DisableAutoLogon_Click(object sender, EventArgs e)
        {
            Enabled = false;
            await Misc.SetAutoLogon(false);
            Enabled = true;
        }
        private async void EnableAutoLogon_Click(object sender, EventArgs e)
        {
            Enabled = false;
            await Misc.SetAutoLogon(true);
            Enabled = true;
        }
        private async void AddStartupTaskP2_Click(object sender, EventArgs e)
        {
            Enabled = false;
            await Misc.InstallScheduledTask(Properties.Resources.SuperCALPhaseThree, "3");
            Enabled = true;
        }
        private async void RemoveStartupTaskP2_Click(object sender, EventArgs e)
        {
            Enabled = false;
            await Misc.InstallScheduledTask(null, "3");
            Enabled = true;
        }
        private void IPConfigMenuBtn_Click(object sender, EventArgs e)
        {
            Logger.Log("IP Configuration: Starting...");
            Enabled = false;
            Form ipConfig = new IPConfig();
            ipConfig.FormClosed += IpConfig_FormClosed;
            ipConfig.Show(this);
        }
        private void IpConfig_FormClosed(object sender, FormClosedEventArgs e)
        {
            Logger.Good("IP Configuration: Done.");
            Enabled = true;
        }
        private void StartPhaseTwoMenuBtn_Click(object sender, EventArgs e)
        {
            PhaseTwo();
        }
        private void StartPhaseThreeMenuBtn_Click(object sender, EventArgs e)
        {
            PhaseThree();
        }
    }
}
