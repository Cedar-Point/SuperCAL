namespace SuperCAL
{
    partial class IPConfig
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.OSKButton = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.useIPGroup = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.StaticRadio = new System.Windows.Forms.RadioButton();
            this.DHCPRadio = new System.Windows.Forms.RadioButton();
            this.dnsGroup = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.adaptersDropDown = new System.Windows.Forms.ComboBox();
            this.DNSRadioPanel = new System.Windows.Forms.Panel();
            this.useIPGroup.SuspendLayout();
            this.dnsGroup.SuspendLayout();
            this.DNSRadioPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Location = new System.Drawing.Point(264, 391);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // OSKButton
            // 
            this.OSKButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.OSKButton.Location = new System.Drawing.Point(12, 391);
            this.OSKButton.Name = "OSKButton";
            this.OSKButton.Size = new System.Drawing.Size(74, 23);
            this.OSKButton.TabIndex = 5;
            this.OSKButton.Text = "Keyboard";
            this.OSKButton.UseVisualStyleBackColor = true;
            this.OSKButton.Click += new System.EventHandler(this.OSKButton_Click);
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button3.Location = new System.Drawing.Point(183, 391);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 6;
            this.button3.Text = "Cancel";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // useIPGroup
            // 
            this.useIPGroup.Controls.Add(this.label4);
            this.useIPGroup.Controls.Add(this.label3);
            this.useIPGroup.Controls.Add(this.label2);
            this.useIPGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.useIPGroup.Location = new System.Drawing.Point(10, 70);
            this.useIPGroup.Name = "useIPGroup";
            this.useIPGroup.Size = new System.Drawing.Size(329, 143);
            this.useIPGroup.TabIndex = 8;
            this.useIPGroup.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label4.Location = new System.Drawing.Point(11, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Default gateway:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label3.Location = new System.Drawing.Point(11, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Subnet mask:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label2.Location = new System.Drawing.Point(11, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "IP address:";
            // 
            // StaticRadio
            // 
            this.StaticRadio.AutoSize = true;
            this.StaticRadio.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.StaticRadio.Location = new System.Drawing.Point(16, 68);
            this.StaticRadio.Name = "StaticRadio";
            this.StaticRadio.Size = new System.Drawing.Size(168, 18);
            this.StaticRadio.TabIndex = 10;
            this.StaticRadio.TabStop = true;
            this.StaticRadio.Text = "Use the following IP address:";
            this.StaticRadio.UseVisualStyleBackColor = true;
            // 
            // DHCPRadio
            // 
            this.DHCPRadio.AutoSize = true;
            this.DHCPRadio.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.DHCPRadio.Location = new System.Drawing.Point(16, 44);
            this.DHCPRadio.Name = "DHCPRadio";
            this.DHCPRadio.Size = new System.Drawing.Size(194, 18);
            this.DHCPRadio.TabIndex = 9;
            this.DHCPRadio.TabStop = true;
            this.DHCPRadio.Text = "Obtain an IP address automatically";
            this.DHCPRadio.UseVisualStyleBackColor = true;
            // 
            // dnsGroup
            // 
            this.dnsGroup.Controls.Add(this.label5);
            this.dnsGroup.Controls.Add(this.label6);
            this.dnsGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.dnsGroup.Location = new System.Drawing.Point(10, 258);
            this.dnsGroup.Name = "dnsGroup";
            this.dnsGroup.Size = new System.Drawing.Size(329, 112);
            this.dnsGroup.TabIndex = 13;
            this.dnsGroup.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label5.Location = new System.Drawing.Point(11, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Alternate DNS server:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label6.Location = new System.Drawing.Point(11, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Preferred DNS server:";
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioButton3.Location = new System.Drawing.Point(4, 27);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(224, 18);
            this.radioButton3.TabIndex = 10;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Use the following DNS server addresses:";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioButton4.Location = new System.Drawing.Point(4, 3);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(224, 18);
            this.radioButton4.TabIndex = 14;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "Obtain DNS server address automatically";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // adaptersDropDown
            // 
            this.adaptersDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.adaptersDropDown.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.adaptersDropDown.FormattingEnabled = true;
            this.adaptersDropDown.IntegralHeight = false;
            this.adaptersDropDown.Location = new System.Drawing.Point(12, 12);
            this.adaptersDropDown.Name = "adaptersDropDown";
            this.adaptersDropDown.Size = new System.Drawing.Size(327, 21);
            this.adaptersDropDown.Sorted = true;
            this.adaptersDropDown.TabIndex = 15;
            this.adaptersDropDown.SelectedIndexChanged += new System.EventHandler(this.adaptersDropDown_SelectedIndexChanged);
            // 
            // DNSRadioPanel
            // 
            this.DNSRadioPanel.Controls.Add(this.radioButton4);
            this.DNSRadioPanel.Controls.Add(this.radioButton3);
            this.DNSRadioPanel.Location = new System.Drawing.Point(15, 229);
            this.DNSRadioPanel.Name = "DNSRadioPanel";
            this.DNSRadioPanel.Size = new System.Drawing.Size(220, 49);
            this.DNSRadioPanel.TabIndex = 16;
            // 
            // IPConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 425);
            this.Controls.Add(this.DNSRadioPanel);
            this.Controls.Add(this.adaptersDropDown);
            this.Controls.Add(this.dnsGroup);
            this.Controls.Add(this.StaticRadio);
            this.Controls.Add(this.DHCPRadio);
            this.Controls.Add(this.useIPGroup);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.OSKButton);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IPConfig";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Super CAL: IPv4 Configuration";
            this.TopMost = true;
            this.useIPGroup.ResumeLayout(false);
            this.useIPGroup.PerformLayout();
            this.dnsGroup.ResumeLayout(false);
            this.dnsGroup.PerformLayout();
            this.DNSRadioPanel.ResumeLayout(false);
            this.DNSRadioPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button OSKButton;
        private System.Windows.Forms.Button button3;
        
        private System.Windows.Forms.GroupBox useIPGroup;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton StaticRadio;
        private System.Windows.Forms.RadioButton DHCPRadio;
        private System.Windows.Forms.GroupBox dnsGroup;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.ComboBox adaptersDropDown;
        private System.Windows.Forms.Panel DNSRadioPanel;
    }
}