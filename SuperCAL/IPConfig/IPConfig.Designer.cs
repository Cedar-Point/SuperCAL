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
            this.components = new System.ComponentModel.Container();
            this.CloseBtn = new System.Windows.Forms.Button();
            this.OSKButton = new System.Windows.Forms.Button();
            this.UseIPGroup = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.StaticRadio = new System.Windows.Forms.RadioButton();
            this.DHCPRadio = new System.Windows.Forms.RadioButton();
            this.dnsGroup = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.DNSStaticRadio = new System.Windows.Forms.RadioButton();
            this.DNSAutoRadio = new System.Windows.Forms.RadioButton();
            this.adaptersDropDown = new System.Windows.Forms.ComboBox();
            this.DNSRadioPanel = new System.Windows.Forms.Panel();
            this.IPRadioPanel = new System.Windows.Forms.Panel();
            this.ApplyBtn = new System.Windows.Forms.Button();
            this.topTimer = new System.Windows.Forms.Timer(this.components);
            this.UseIPGroup.SuspendLayout();
            this.dnsGroup.SuspendLayout();
            this.DNSRadioPanel.SuspendLayout();
            this.IPRadioPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // CloseBtn
            // 
            this.CloseBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.CloseBtn.Location = new System.Drawing.Point(265, 387);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(75, 23);
            this.CloseBtn.TabIndex = 4;
            this.CloseBtn.Text = "Close";
            this.CloseBtn.UseVisualStyleBackColor = true;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // OSKButton
            // 
            this.OSKButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.OSKButton.Location = new System.Drawing.Point(10, 387);
            this.OSKButton.Name = "OSKButton";
            this.OSKButton.Size = new System.Drawing.Size(74, 23);
            this.OSKButton.TabIndex = 5;
            this.OSKButton.Text = "Keyboard";
            this.OSKButton.UseVisualStyleBackColor = true;
            this.OSKButton.Click += new System.EventHandler(this.OSKButton_Click);
            // 
            // UseIPGroup
            // 
            this.UseIPGroup.Controls.Add(this.label4);
            this.UseIPGroup.Controls.Add(this.label3);
            this.UseIPGroup.Controls.Add(this.label2);
            this.UseIPGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.UseIPGroup.Location = new System.Drawing.Point(10, 70);
            this.UseIPGroup.Name = "UseIPGroup";
            this.UseIPGroup.Size = new System.Drawing.Size(329, 143);
            this.UseIPGroup.TabIndex = 8;
            this.UseIPGroup.TabStop = false;
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
            this.StaticRadio.Location = new System.Drawing.Point(4, 27);
            this.StaticRadio.Name = "StaticRadio";
            this.StaticRadio.Size = new System.Drawing.Size(168, 18);
            this.StaticRadio.TabIndex = 10;
            this.StaticRadio.TabStop = true;
            this.StaticRadio.Text = "Use the following IP address:";
            this.StaticRadio.UseVisualStyleBackColor = true;
            this.StaticRadio.CheckedChanged += new System.EventHandler(this.StaticRadio_CheckedChanged);
            // 
            // DHCPRadio
            // 
            this.DHCPRadio.AutoSize = true;
            this.DHCPRadio.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.DHCPRadio.Location = new System.Drawing.Point(4, 3);
            this.DHCPRadio.Name = "DHCPRadio";
            this.DHCPRadio.Size = new System.Drawing.Size(194, 18);
            this.DHCPRadio.TabIndex = 9;
            this.DHCPRadio.Text = "Obtain an IP address automatically";
            this.DHCPRadio.UseVisualStyleBackColor = true;
            this.DHCPRadio.CheckedChanged += new System.EventHandler(this.DHCPRadio_CheckedChanged);
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
            // DNSStaticRadio
            // 
            this.DNSStaticRadio.AutoSize = true;
            this.DNSStaticRadio.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.DNSStaticRadio.Location = new System.Drawing.Point(4, 27);
            this.DNSStaticRadio.Name = "DNSStaticRadio";
            this.DNSStaticRadio.Size = new System.Drawing.Size(224, 18);
            this.DNSStaticRadio.TabIndex = 10;
            this.DNSStaticRadio.TabStop = true;
            this.DNSStaticRadio.Text = "Use the following DNS server addresses:";
            this.DNSStaticRadio.UseVisualStyleBackColor = true;
            this.DNSStaticRadio.CheckedChanged += new System.EventHandler(this.DNSStaticRadio_CheckedChanged);
            // 
            // DNSAutoRadio
            // 
            this.DNSAutoRadio.AutoSize = true;
            this.DNSAutoRadio.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.DNSAutoRadio.Location = new System.Drawing.Point(4, 3);
            this.DNSAutoRadio.Name = "DNSAutoRadio";
            this.DNSAutoRadio.Size = new System.Drawing.Size(224, 18);
            this.DNSAutoRadio.TabIndex = 14;
            this.DNSAutoRadio.Text = "Obtain DNS server address automatically";
            this.DNSAutoRadio.UseVisualStyleBackColor = true;
            this.DNSAutoRadio.CheckedChanged += new System.EventHandler(this.DNSAutoRadio_CheckedChanged);
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
            this.adaptersDropDown.DropDown += new System.EventHandler(this.adaptersDropDown_DropDown);
            this.adaptersDropDown.SelectedIndexChanged += new System.EventHandler(this.adaptersDropDown_SelectedIndexChanged);
            this.adaptersDropDown.DropDownClosed += new System.EventHandler(this.adaptersDropDown_DropDownClosed);
            // 
            // DNSRadioPanel
            // 
            this.DNSRadioPanel.Controls.Add(this.DNSAutoRadio);
            this.DNSRadioPanel.Controls.Add(this.DNSStaticRadio);
            this.DNSRadioPanel.Location = new System.Drawing.Point(15, 229);
            this.DNSRadioPanel.Name = "DNSRadioPanel";
            this.DNSRadioPanel.Size = new System.Drawing.Size(220, 49);
            this.DNSRadioPanel.TabIndex = 16;
            // 
            // IPRadioPanel
            // 
            this.IPRadioPanel.Controls.Add(this.DHCPRadio);
            this.IPRadioPanel.Controls.Add(this.StaticRadio);
            this.IPRadioPanel.Location = new System.Drawing.Point(15, 41);
            this.IPRadioPanel.Name = "IPRadioPanel";
            this.IPRadioPanel.Size = new System.Drawing.Size(188, 49);
            this.IPRadioPanel.TabIndex = 17;
            // 
            // ApplyBtn
            // 
            this.ApplyBtn.Enabled = false;
            this.ApplyBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ApplyBtn.Location = new System.Drawing.Point(184, 387);
            this.ApplyBtn.Name = "ApplyBtn";
            this.ApplyBtn.Size = new System.Drawing.Size(75, 23);
            this.ApplyBtn.TabIndex = 18;
            this.ApplyBtn.Text = "Apply";
            this.ApplyBtn.UseVisualStyleBackColor = true;
            this.ApplyBtn.Click += new System.EventHandler(this.ApplyBtn_Click);
            // 
            // IPConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 420);
            this.ControlBox = false;
            this.Controls.Add(this.ApplyBtn);
            this.Controls.Add(this.IPRadioPanel);
            this.Controls.Add(this.DNSRadioPanel);
            this.Controls.Add(this.adaptersDropDown);
            this.Controls.Add(this.dnsGroup);
            this.Controls.Add(this.UseIPGroup);
            this.Controls.Add(this.OSKButton);
            this.Controls.Add(this.CloseBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IPConfig";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Super CAL: IPv4 Configuration";
            this.TopMost = true;
            this.UseIPGroup.ResumeLayout(false);
            this.UseIPGroup.PerformLayout();
            this.dnsGroup.ResumeLayout(false);
            this.dnsGroup.PerformLayout();
            this.DNSRadioPanel.ResumeLayout(false);
            this.DNSRadioPanel.PerformLayout();
            this.IPRadioPanel.ResumeLayout(false);
            this.IPRadioPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        
        private System.Windows.Forms.Button CloseBtn;
        private System.Windows.Forms.Button OSKButton;
        
        private System.Windows.Forms.GroupBox UseIPGroup;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton StaticRadio;
        private System.Windows.Forms.RadioButton DHCPRadio;
        private System.Windows.Forms.GroupBox dnsGroup;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton DNSStaticRadio;
        private System.Windows.Forms.RadioButton DNSAutoRadio;
        private System.Windows.Forms.ComboBox adaptersDropDown;
        private System.Windows.Forms.Panel DNSRadioPanel;
        private System.Windows.Forms.Panel IPRadioPanel;
        private System.Windows.Forms.Button ApplyBtn;
        private System.Windows.Forms.Timer topTimer;
    }
}