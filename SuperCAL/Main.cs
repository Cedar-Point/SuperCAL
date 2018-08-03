using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                Logger.Log("Initiating phase two...");
                await WatchDog.WaitForProcessStart();
                if (McrsCalSrvc.IsRunning())
                {
                    await McrsCalSrvc.Stop();
                    string newName = Misc.GetCalNameFromRegistry();
                    if(newName != "")
                    {
                        await DomainJoin.Join(newName);
                        Misc.RestartWindows();
                    }
                }
            }
            else
            {
                Left = Left - 440;
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
            await DomainJoin.Leave();
            await Misc.SetAutoLogon();
            await Wipe.Do();
            await WatchDog.WaitForProcessStart();
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
        }

        private void ReDownloadCAL_Click(object sender, EventArgs e)
        {

        }

        private void LogRTB_DoubleClick(object sender, EventArgs e)
        {
            Logger.Log("Super CAL: Written by Dylan Bickerstaff Aug 2018.");
        }
    }
}
