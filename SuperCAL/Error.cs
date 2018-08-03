using System;
using System.Windows.Forms;

namespace SuperCAL
{
    public partial class Error : Form
    {
        public Error(string message)
        {
            InitializeComponent();
            ErrorBox.Text = message;
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Retry_Click(object sender, EventArgs e)
        {
            Program.RetryLaunch = true;
            Close();
        }
    }
}
