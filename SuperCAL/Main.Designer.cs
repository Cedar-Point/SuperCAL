namespace SuperCAL
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.ReCAL = new System.Windows.Forms.Button();
            this.ReDownloadCAL = new System.Windows.Forms.Button();
            this.StopStartCAL = new System.Windows.Forms.Button();
            this.Table = new System.Windows.Forms.TableLayoutPanel();
            this.LogRTB = new System.Windows.Forms.RichTextBox();
            this.MenuBar = new System.Windows.Forms.MenuStrip();
            this.ToolsButton = new System.Windows.Forms.ToolStripMenuItem();
            this.TaskMgrButton = new System.Windows.Forms.ToolStripMenuItem();
            this.CMDButton = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolsSeperator = new System.Windows.Forms.ToolStripSeparator();
            this.OSKButton = new System.Windows.Forms.ToolStripMenuItem();
            this.ActionsButton = new System.Windows.Forms.ToolStripMenuItem();
            this.WipeMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.WipeCalButton = new System.Windows.Forms.ToolStripMenuItem();
            this.WipeKeepCalButton = new System.Windows.Forms.ToolStripMenuItem();
            this.PhaseTwoMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.AddSrtTaskButton = new System.Windows.Forms.ToolStripMenuItem();
            this.RmvStartTaskButton = new System.Windows.Forms.ToolStripMenuItem();
            this.PhaseThreeMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.AddStartupTaskP2 = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoveStartupTaskP2 = new System.Windows.Forms.ToolStripMenuItem();
            this.DomainMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.JoinDomainButton = new System.Windows.Forms.ToolStripMenuItem();
            this.JoinWorkButton = new System.Windows.Forms.ToolStripMenuItem();
            this.AutoLogon = new System.Windows.Forms.ToolStripMenuItem();
            this.EnableAutoLogon = new System.Windows.Forms.ToolStripMenuItem();
            this.DisableAutoLogon = new System.Windows.Forms.ToolStripMenuItem();
            this.NetDomButton = new System.Windows.Forms.ToolStripMenuItem();
            this.RebootWindows = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutButton = new System.Windows.Forms.ToolStripMenuItem();
            this.Table.SuspendLayout();
            this.MenuBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // ReCAL
            // 
            this.ReCAL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReCAL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReCAL.Location = new System.Drawing.Point(6, 5);
            this.ReCAL.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.ReCAL.Name = "ReCAL";
            this.ReCAL.Size = new System.Drawing.Size(112, 69);
            this.ReCAL.TabIndex = 1;
            this.ReCAL.Text = "Re CAL";
            this.ReCAL.UseVisualStyleBackColor = false;
            this.ReCAL.Click += new System.EventHandler(this.ReCAL_Click);
            // 
            // ReDownloadCAL
            // 
            this.ReDownloadCAL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReDownloadCAL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReDownloadCAL.Location = new System.Drawing.Point(124, 5);
            this.ReDownloadCAL.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.ReDownloadCAL.Name = "ReDownloadCAL";
            this.ReDownloadCAL.Size = new System.Drawing.Size(124, 69);
            this.ReDownloadCAL.TabIndex = 2;
            this.ReDownloadCAL.Text = "Re Download";
            this.ReDownloadCAL.UseVisualStyleBackColor = false;
            this.ReDownloadCAL.Click += new System.EventHandler(this.ReDownloadCAL_Click);
            // 
            // StopStartCAL
            // 
            this.StopStartCAL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StopStartCAL.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLight;
            this.StopStartCAL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StopStartCAL.Location = new System.Drawing.Point(254, 5);
            this.StopStartCAL.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.StopStartCAL.Name = "StopStartCAL";
            this.StopStartCAL.Size = new System.Drawing.Size(113, 69);
            this.StopStartCAL.TabIndex = 3;
            this.StopStartCAL.Text = "CAL Srvc Toggle";
            this.StopStartCAL.UseVisualStyleBackColor = false;
            this.StopStartCAL.Click += new System.EventHandler(this.StopStartCAL_Click);
            // 
            // Table
            // 
            this.Table.ColumnCount = 3;
            this.Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.Table.Controls.Add(this.ReCAL, 0, 0);
            this.Table.Controls.Add(this.StopStartCAL, 2, 0);
            this.Table.Controls.Add(this.ReDownloadCAL, 1, 0);
            this.Table.Dock = System.Windows.Forms.DockStyle.Top;
            this.Table.Location = new System.Drawing.Point(0, 24);
            this.Table.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Table.Name = "Table";
            this.Table.RowCount = 1;
            this.Table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Table.Size = new System.Drawing.Size(373, 79);
            this.Table.TabIndex = 4;
            // 
            // LogRTB
            // 
            this.LogRTB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LogRTB.Location = new System.Drawing.Point(6, 80);
            this.LogRTB.Margin = new System.Windows.Forms.Padding(0);
            this.LogRTB.Name = "LogRTB";
            this.LogRTB.ReadOnly = true;
            this.LogRTB.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.LogRTB.Size = new System.Drawing.Size(361, 354);
            this.LogRTB.TabIndex = 5;
            this.LogRTB.Text = "";
            this.LogRTB.DoubleClick += new System.EventHandler(this.LogRTB_DoubleClick);
            // 
            // MenuBar
            // 
            this.MenuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolsButton,
            this.ActionsButton,
            this.AboutButton});
            this.MenuBar.Location = new System.Drawing.Point(0, 0);
            this.MenuBar.Name = "MenuBar";
            this.MenuBar.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.MenuBar.Size = new System.Drawing.Size(373, 24);
            this.MenuBar.TabIndex = 6;
            this.MenuBar.Visible = false;
            // 
            // ToolsButton
            // 
            this.ToolsButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TaskMgrButton,
            this.CMDButton,
            this.ToolsSeperator,
            this.OSKButton});
            this.ToolsButton.Name = "ToolsButton";
            this.ToolsButton.Size = new System.Drawing.Size(47, 20);
            this.ToolsButton.Text = "Tools";
            // 
            // TaskMgrButton
            // 
            this.TaskMgrButton.Name = "TaskMgrButton";
            this.TaskMgrButton.Size = new System.Drawing.Size(181, 22);
            this.TaskMgrButton.Text = "Task Manager";
            this.TaskMgrButton.Click += new System.EventHandler(this.TaskMgrButton_Click);
            // 
            // CMDButton
            // 
            this.CMDButton.Name = "CMDButton";
            this.CMDButton.Size = new System.Drawing.Size(181, 22);
            this.CMDButton.Text = "Command Prompt";
            this.CMDButton.Click += new System.EventHandler(this.CMDButton_Click);
            // 
            // ToolsSeperator
            // 
            this.ToolsSeperator.Name = "ToolsSeperator";
            this.ToolsSeperator.Size = new System.Drawing.Size(178, 6);
            // 
            // OSKButton
            // 
            this.OSKButton.Name = "OSKButton";
            this.OSKButton.Size = new System.Drawing.Size(181, 22);
            this.OSKButton.Text = "On Screen Keyboard";
            this.OSKButton.Click += new System.EventHandler(this.OSKButton_Click);
            // 
            // ActionsButton
            // 
            this.ActionsButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.WipeMenu,
            this.PhaseTwoMenu,
            this.PhaseThreeMenu,
            this.DomainMenu,
            this.AutoLogon,
            this.NetDomButton,
            this.RebootWindows});
            this.ActionsButton.Name = "ActionsButton";
            this.ActionsButton.Size = new System.Drawing.Size(59, 20);
            this.ActionsButton.Text = "Actions";
            // 
            // WipeMenu
            // 
            this.WipeMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.WipeCalButton,
            this.WipeKeepCalButton});
            this.WipeMenu.Name = "WipeMenu";
            this.WipeMenu.Size = new System.Drawing.Size(228, 22);
            this.WipeMenu.Text = "Wipe...";
            // 
            // WipeCalButton
            // 
            this.WipeCalButton.Name = "WipeCalButton";
            this.WipeCalButton.Size = new System.Drawing.Size(180, 22);
            this.WipeCalButton.Text = "Wipe (Remove CAL)";
            this.WipeCalButton.Click += new System.EventHandler(this.WipeCalButton_Click);
            // 
            // WipeKeepCalButton
            // 
            this.WipeKeepCalButton.Name = "WipeKeepCalButton";
            this.WipeKeepCalButton.Size = new System.Drawing.Size(180, 22);
            this.WipeKeepCalButton.Text = "Wipe (Keep CAL)";
            this.WipeKeepCalButton.Click += new System.EventHandler(this.WipeKeepCalButton_Click);
            // 
            // PhaseTwoMenu
            // 
            this.PhaseTwoMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddSrtTaskButton,
            this.RmvStartTaskButton});
            this.PhaseTwoMenu.Name = "PhaseTwoMenu";
            this.PhaseTwoMenu.Size = new System.Drawing.Size(228, 22);
            this.PhaseTwoMenu.Text = "Phase Two (Domain Join)...";
            // 
            // AddSrtTaskButton
            // 
            this.AddSrtTaskButton.Name = "AddSrtTaskButton";
            this.AddSrtTaskButton.Size = new System.Drawing.Size(184, 22);
            this.AddSrtTaskButton.Text = "Add Startup Task";
            this.AddSrtTaskButton.Click += new System.EventHandler(this.AddSrtTaskButton_Click);
            // 
            // RmvStartTaskButton
            // 
            this.RmvStartTaskButton.Name = "RmvStartTaskButton";
            this.RmvStartTaskButton.Size = new System.Drawing.Size(184, 22);
            this.RmvStartTaskButton.Text = "Remove Startup Task";
            this.RmvStartTaskButton.Click += new System.EventHandler(this.RmvStartTaskButton_Click);
            // 
            // PhaseThreeMenu
            // 
            this.PhaseThreeMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddStartupTaskP2,
            this.RemoveStartupTaskP2});
            this.PhaseThreeMenu.Name = "PhaseThreeMenu";
            this.PhaseThreeMenu.Size = new System.Drawing.Size(228, 22);
            this.PhaseThreeMenu.Text = "Phase Three (Logon Check)...";
            // 
            // AddStartupTaskP2
            // 
            this.AddStartupTaskP2.Name = "AddStartupTaskP2";
            this.AddStartupTaskP2.Size = new System.Drawing.Size(184, 22);
            this.AddStartupTaskP2.Text = "Add Startup Task";
            this.AddStartupTaskP2.Click += new System.EventHandler(this.AddStartupTaskP2_Click);
            // 
            // RemoveStartupTaskP2
            // 
            this.RemoveStartupTaskP2.Name = "RemoveStartupTaskP2";
            this.RemoveStartupTaskP2.Size = new System.Drawing.Size(184, 22);
            this.RemoveStartupTaskP2.Text = "Remove Startup Task";
            this.RemoveStartupTaskP2.Click += new System.EventHandler(this.RemoveStartupTaskP2_Click);
            // 
            // DomainMenu
            // 
            this.DomainMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.JoinDomainButton,
            this.JoinWorkButton});
            this.DomainMenu.Name = "DomainMenu";
            this.DomainMenu.Size = new System.Drawing.Size(228, 22);
            this.DomainMenu.Text = "Domain...";
            // 
            // JoinDomainButton
            // 
            this.JoinDomainButton.Name = "JoinDomainButton";
            this.JoinDomainButton.Size = new System.Drawing.Size(158, 22);
            this.JoinDomainButton.Text = "Join Domain";
            this.JoinDomainButton.Click += new System.EventHandler(this.JoinDomainButton_Click);
            // 
            // JoinWorkButton
            // 
            this.JoinWorkButton.Name = "JoinWorkButton";
            this.JoinWorkButton.Size = new System.Drawing.Size(158, 22);
            this.JoinWorkButton.Text = "Join Workgroup";
            this.JoinWorkButton.Click += new System.EventHandler(this.JoinWorkButton_Click);
            // 
            // AutoLogon
            // 
            this.AutoLogon.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EnableAutoLogon,
            this.DisableAutoLogon});
            this.AutoLogon.Name = "AutoLogon";
            this.AutoLogon.Size = new System.Drawing.Size(228, 22);
            this.AutoLogon.Text = "Auto Logon...";
            // 
            // EnableAutoLogon
            // 
            this.EnableAutoLogon.Name = "EnableAutoLogon";
            this.EnableAutoLogon.Size = new System.Drawing.Size(178, 22);
            this.EnableAutoLogon.Text = "Enable Auto Logon";
            this.EnableAutoLogon.Click += new System.EventHandler(this.EnableAutoLogon_Click);
            // 
            // DisableAutoLogon
            // 
            this.DisableAutoLogon.Name = "DisableAutoLogon";
            this.DisableAutoLogon.Size = new System.Drawing.Size(178, 22);
            this.DisableAutoLogon.Text = "Disable Auto Logon";
            this.DisableAutoLogon.Click += new System.EventHandler(this.DisableAutoLogon_Click);
            // 
            // NetDomButton
            // 
            this.NetDomButton.Name = "NetDomButton";
            this.NetDomButton.Size = new System.Drawing.Size(228, 22);
            this.NetDomButton.Text = "Install NETDOM";
            this.NetDomButton.Click += new System.EventHandler(this.NetDomButton_Click);
            // 
            // RebootWindows
            // 
            this.RebootWindows.Name = "RebootWindows";
            this.RebootWindows.Size = new System.Drawing.Size(228, 22);
            this.RebootWindows.Text = "Restart Windows";
            this.RebootWindows.Click += new System.EventHandler(this.RebootWindows_Click);
            // 
            // AboutButton
            // 
            this.AboutButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.AboutButton.Name = "AboutButton";
            this.AboutButton.Size = new System.Drawing.Size(52, 20);
            this.AboutButton.Text = "About";
            this.AboutButton.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(373, 440);
            this.Controls.Add(this.LogRTB);
            this.Controls.Add(this.Table);
            this.Controls.Add(this.MenuBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MenuBar;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Super CAL";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Window_Load);
            this.Table.ResumeLayout(false);
            this.MenuBar.ResumeLayout(false);
            this.MenuBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button ReCAL;
        private System.Windows.Forms.Button ReDownloadCAL;
        private System.Windows.Forms.Button StopStartCAL;
        private System.Windows.Forms.TableLayoutPanel Table;
        private System.Windows.Forms.RichTextBox LogRTB;
        private System.Windows.Forms.MenuStrip MenuBar;
        private System.Windows.Forms.ToolStripMenuItem ToolsButton;
        private System.Windows.Forms.ToolStripMenuItem ActionsButton;
        private System.Windows.Forms.ToolStripMenuItem AboutButton;
        private System.Windows.Forms.ToolStripMenuItem TaskMgrButton;
        private System.Windows.Forms.ToolStripMenuItem CMDButton;
        private System.Windows.Forms.ToolStripSeparator ToolsSeperator;
        private System.Windows.Forms.ToolStripMenuItem OSKButton;
        private System.Windows.Forms.ToolStripMenuItem WipeMenu;
        private System.Windows.Forms.ToolStripMenuItem PhaseTwoMenu;
        private System.Windows.Forms.ToolStripMenuItem AddSrtTaskButton;
        private System.Windows.Forms.ToolStripMenuItem WipeCalButton;
        private System.Windows.Forms.ToolStripMenuItem WipeKeepCalButton;
        private System.Windows.Forms.ToolStripMenuItem RmvStartTaskButton;
        private System.Windows.Forms.ToolStripMenuItem DomainMenu;
        private System.Windows.Forms.ToolStripMenuItem JoinDomainButton;
        private System.Windows.Forms.ToolStripMenuItem JoinWorkButton;
        private System.Windows.Forms.ToolStripMenuItem NetDomButton;
        private System.Windows.Forms.ToolStripMenuItem RebootWindows;
        private System.Windows.Forms.ToolStripMenuItem AutoLogon;
        private System.Windows.Forms.ToolStripMenuItem DisableAutoLogon;
        private System.Windows.Forms.ToolStripMenuItem EnableAutoLogon;
        private System.Windows.Forms.ToolStripMenuItem PhaseThreeMenu;
        private System.Windows.Forms.ToolStripMenuItem AddStartupTaskP2;
        private System.Windows.Forms.ToolStripMenuItem RemoveStartupTaskP2;
    }
}

