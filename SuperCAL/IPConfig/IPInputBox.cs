using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperCAL
{
    class IPInputBox
    {
        public string IPAddress
        {
            get
            {
                return octetTB1.Text + '.' + octetTB2.Text + '.' + octetTB3.Text + '.' + octetTB4.Text;
            }
            set
            {

            }
        }

        public int TabIndex
        {
            get
            {
                return octetTB1.TabIndex;
            }
            set
            {
                octetTB1.TabIndex = value;
                octetTB2.TabIndex = value + 1;
                octetTB3.TabIndex = value + 2;
                octetTB4.TabIndex = value + 3;
            }
        }

        public Point Location
        {
            get
            {
                return outlineLbl.Location;
            }
            set
            {
                outlineLbl.Location = value;
                octetTB1.Location = new Point(value.X + 7, value.Y + 7);
                octetTB2.Location = new Point(value.X + 38, value.Y + 7);
                octetTB3.Location = new Point(value.X + 68, value.Y + 7);
                octetTB4.Location = new Point(value.X + 98, value.Y + 7);
            }
        }

        public IPInputBox(Control parentControl)
        {
            pControl = parentControl;
            Initialize();
            Location = new Point(0, 0);
            TabIndex = 0;
            BringToFront();
        }

        public void BringToFront()
        {
            outlineLbl.BringToFront();
            octetTB1.BringToFront();
            octetTB2.BringToFront();
            octetTB3.BringToFront();
            octetTB4.BringToFront();
        }

        private Control pControl = null;
        private Label outlineLbl;
        private TextBox octetTB1, octetTB2, octetTB3, octetTB4;

        private void Initialize()
        {
            outlineLbl = new Label();
            octetTB1 = new TextBox();
            octetTB2 = new TextBox();
            octetTB3 = new TextBox();
            octetTB4 = new TextBox();

            outlineLbl.BackColor = octetTB1.BackColor = octetTB2.BackColor = octetTB3.BackColor = octetTB4.BackColor = Color.White;
            outlineLbl.BorderStyle = BorderStyle.Fixed3D;
            outlineLbl.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            outlineLbl.Location = new Point(0, 0);
            outlineLbl.Name = "outlineLbl";
            outlineLbl.Size = new Size(126, 25);
            outlineLbl.Text = ".    .    .";
            outlineLbl.TextAlign = ContentAlignment.BottomCenter;

            octetTB1.BorderStyle = octetTB2.BorderStyle = octetTB3.BorderStyle = octetTB4.BorderStyle = BorderStyle.None;
            octetTB1.MaxLength = octetTB2.MaxLength = octetTB3.MaxLength = octetTB4.MaxLength = 3;
            octetTB1.Size = octetTB2.Size = octetTB3.Size = octetTB4.Size = new Size(22, 13);
            octetTB1.TextAlign = octetTB2.TextAlign = octetTB3.TextAlign = octetTB4.TextAlign = HorizontalAlignment.Center;

            octetTB1.Name = "octetTB1";
            octetTB2.Name = "octetTB2";
            octetTB3.Name = "octetTB3";
            octetTB4.Name = "octetTB4";

            octetTB1.KeyDown += OctetTB_KeyDown;
            octetTB2.KeyDown += OctetTB_KeyDown;
            octetTB3.KeyDown += OctetTB_KeyDown;
            octetTB4.KeyDown += OctetTB_KeyDown;

            octetTB1.KeyPress += OctetTB_KeyPress;
            octetTB2.KeyPress += OctetTB_KeyPress;
            octetTB3.KeyPress += OctetTB_KeyPress;
            octetTB4.KeyPress += OctetTB_KeyPress;

            octetTB1.TextChanged += OctetTB_TextChanged;
            octetTB2.TextChanged += OctetTB_TextChanged;
            octetTB3.TextChanged += OctetTB_TextChanged;
            octetTB4.TextChanged += OctetTB_TextChanged;

            pControl.Controls.Add(outlineLbl);
            pControl.Controls.Add(octetTB1);
            pControl.Controls.Add(octetTB2);
            pControl.Controls.Add(octetTB3);
            pControl.Controls.Add(octetTB4);

        }


        private void prev(TextBox thisTb)
        {
            Control prev = pControl.GetNextControl(thisTb, false);
            if (prev != null && thisTb.Name != "octetTB1")
            {
                prev.Focus();
            }
        }

        private void next(TextBox thisTb)
        {
            Control next = pControl.GetNextControl(thisTb, true);
            if (next != null && thisTb.Name != "octetTB4")
            {
                next.Focus();
            }
        }

        private void OctetTB_TextChanged(object sender, EventArgs e)
        {
            TextBox thisTb = (TextBox)sender;
            int octet = 0;
            if (int.TryParse(thisTb.Text, out octet))
            {
                thisTb.Text = octet.ToString();
                thisTb.SelectionStart = thisTb.TextLength;
            }
        }

        private void OctetTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox thisTb = (TextBox)sender;
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
            if (char.IsDigit(e.KeyChar) && thisTb.SelectionStart == 2 && int.Parse(thisTb.Text + e.KeyChar.ToString()) > 255)
            {
                e.Handled = true;
            }
        }

        private void OctetTB_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox thisTb = (TextBox)sender;
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Back)
            {
                if (thisTb.SelectionStart == 0)
                {
                    prev(thisTb);
                }
            }
            if (
                (
                    e.KeyCode == Keys.Decimal
                    || (
                        thisTb.SelectionStart == thisTb.TextLength
                        && e.KeyCode == Keys.Right
                    )
                )
                && e.KeyCode != Keys.Back
            )
            {
                next(thisTb);
                e.SuppressKeyPress = true;
            }
        }
    }
}
