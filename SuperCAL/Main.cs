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
    public partial class Window : Form
    {
        public Timer topTimer = new Timer();

        public Window()
        {
            InitializeComponent();
            Logger.LogRTB = LogRTB;
            topTimer.Interval = 1000;
            topTimer.Tick += TopTimer_Tick;
            topTimer.Start();
        }

        private void TopTimer_Tick(object sender, EventArgs e)
        {
            BringToFront();
        }

        private void Window_Load(object sender, EventArgs e)
        {
            Left = Left - 440;
            Logger.Log("Welcome to Super CAL: Press any button to begin.");
            if(McrsCalSrvc.IsRunning())
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

        private async void StopStartCAL_Click(object sender, EventArgs e)
        {
            await toggleCal();
        }

        private async Task toggleCal()
        {
            StopStartCAL.Enabled = false;
            if (McrsCalSrvc.IsRunning())
            {
                StopStartCAL.Text = "Stopping CAL...";
                await McrsCalSrvc.Stop();
                StopStartCAL.Text = "Start CAL";
            }
            else
            {
                StopStartCAL.Text = "Starting CAL...";
                await McrsCalSrvc.Start();
                StopStartCAL.Text = "Stop CAL";
            }
            StopStartCAL.Enabled = true;
        }

        private async void ReCAL_Click(object sender, EventArgs e)
        {
            if(McrsCalSrvc.IsRunning())
            {
                await toggleCal();
            }
            await Wipe.Do();
        }

        private void ReDownloadCAL_Click(object sender, EventArgs e)
        {

        }
    }
}
