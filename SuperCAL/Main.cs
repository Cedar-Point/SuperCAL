using System;
using System.Diagnostics;
using System.Windows.Forms;

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
                Logger.Log("Phase two: Join domain...");
                await WatchDog.WaitForProcessStart();
                if (McrsCalSrvc.IsRunning())
                {
                    await McrsCalSrvc.Stop();
                    string newName = await Misc.GetCalNameFromRegistry();
                    if(newName != "")
                    {
                        CenterToScreen();
                        Left = Left - 440;
                        await DomainJoin.Join(newName);
                        CenterToScreen();
                        await Misc.InstallPhaseTwo(false);
                        Misc.RestartWindows();
                    }
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
            await Misc.InstallPhaseTwo();
            await DomainJoin.Leave();
            await Wipe.Do();
            await WatchDog.WaitForProcessStart();
            CenterToScreen();
            Left = Left - 440;
            if (McrsCalSrvc.IsRunning())
            {
                await WatchDog.WaitForCALBusy();
            }
            if (McrsCalSrvc.IsRunning())
            {
                await WatchDog.WaitForCALBusy(true);
            }
            if (McrsCalSrvc.IsRunning())
            {
                await WatchDog.WaitForCALBusy();
            }
            if (McrsCalSrvc.IsRunning())
            {
                await McrsCalSrvc.Stop();
                Misc.RestartWindows();
            }
            else
            {
                Logger.Error("ReCAL process failed! Cleaning up...");
                await Misc.InstallPhaseTwo(false);
                CenterToScreen();
                Left = Left - 440;
                await DomainJoin.Join(Environment.MachineName);
                CenterToScreen();
            }
        }

        private void ReDownloadCAL_Click(object sender, EventArgs e)
        {

        }

        private void LogRTB_DoubleClick(object sender, EventArgs e)
        {
            Logger.Log("Super CAL: Written by Dylan Bickerstaff Aug 2018.");
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(e.CloseReason == CloseReason.WindowsShutDown)
            {
                Process.Start("shutdown.exe", "/a");
            }
        }
    }
}
