using System;
using System.Windows.Forms;

namespace SuperCAL
{
    public partial class Pin : Form
    {
        public static string UnlockPin = "";
        public static string UnlockMessage = "";
        private string pinBuffer = "";
        private Timer topTimer = new Timer();
        public Pin()
        {
            InitializeComponent();
            topTimer.Interval = 1000;
            topTimer.Tick += TopTimer_Tick;
            topTimer.Start();
            lblDisplay.Text = UnlockMessage;
        }
        private void TopTimer_Tick(object sender, EventArgs e)
        {
            BringToFront();
        }
        private void Btn_Click(object sender, EventArgs e)
        {
            Button thisButton = (Button)sender;
            lblDisplay.Focus();
            if(thisButton.Text == "Enter")
            {
                Close();
            }
            else
            {
                pinBuffer += thisButton.Text;
            }
            UpdateDisplay();
        }
        private void UpdateDisplay()
        {
            string starDisplay = "";
            for(int count = 0; count != pinBuffer.Length; count++)
            {
                starDisplay += '*';
            }
            lblDisplay.Text = starDisplay;
        }
        private void Pin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (pinBuffer == UnlockPin)
            {
                Close();
            }
            else
            {
                Application.Exit();
            }
        }
    }
}
