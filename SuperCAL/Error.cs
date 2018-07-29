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
    public partial class Error : Form
    {
        public Error(string message)
        {
            InitializeComponent();
            ErrorBox.Text = message;
        }

        private void Ok_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
