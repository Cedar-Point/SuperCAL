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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.ReCAL = new System.Windows.Forms.Button();
            this.ReDownloadCAL = new System.Windows.Forms.Button();
            this.StopStartCAL = new System.Windows.Forms.Button();
            this.Table = new System.Windows.Forms.TableLayoutPanel();
            this.LogRTB = new System.Windows.Forms.RichTextBox();
            this.MenuBar = new System.Windows.Forms.MainMenu(this.components);
            this.ToolsButton = new System.Windows.Forms.MenuItem();
            this.TaskMgrButton = new System.Windows.Forms.MenuItem();
            this.CMDButton = new System.Windows.Forms.MenuItem();
            this.IPConfigMenuBtn = new System.Windows.Forms.MenuItem();
            this.ToolsSeperator = new System.Windows.Forms.MenuItem();
            this.OSKButton = new System.Windows.Forms.MenuItem();
            this.ActionsButton = new System.Windows.Forms.MenuItem();
            this.WipeMenu = new System.Windows.Forms.MenuItem();
            this.WipeCalButton = new System.Windows.Forms.MenuItem();
            this.WipeKeepCalButton = new System.Windows.Forms.MenuItem();
            this.PhaseTwoMenu = new System.Windows.Forms.MenuItem();
            this.StartPhaseTwoMenuBtn = new System.Windows.Forms.MenuItem();
            this.PhaseTwoSeperator = new System.Windows.Forms.MenuItem();
            this.AddSrtTaskButton = new System.Windows.Forms.MenuItem();
            this.RmvStartTaskButton = new System.Windows.Forms.MenuItem();
            this.PhaseThreeMenu = new System.Windows.Forms.MenuItem();
            this.StartPhaseThreeMenuBtn = new System.Windows.Forms.MenuItem();
            this.PhaseThreeSeperator = new System.Windows.Forms.MenuItem();
            this.AddStartupTaskP2 = new System.Windows.Forms.MenuItem();
            this.RemoveStartupTaskP2 = new System.Windows.Forms.MenuItem();
            this.DomainMenu = new System.Windows.Forms.MenuItem();
            this.JoinDomainButton = new System.Windows.Forms.MenuItem();
            this.JoinWorkButton = new System.Windows.Forms.MenuItem();
            this.AutoLogon = new System.Windows.Forms.MenuItem();
            this.EnableAutoLogon = new System.Windows.Forms.MenuItem();
            this.DisableAutoLogon = new System.Windows.Forms.MenuItem();
            this.NetDomButton = new System.Windows.Forms.MenuItem();
            this.RebootWindows = new System.Windows.Forms.MenuItem();
            this.AboutButton = new System.Windows.Forms.MenuItem();
            this.Table.SuspendLayout();
            this.SuspendLayout();
            // 
            // ReCAL
            // 
            this.ReCAL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReCAL.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ReCAL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReCAL.Location = new System.Drawing.Point(6, 5);
            this.ReCAL.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.ReCAL.Name = "ReCAL";
            this.ReCAL.Size = new System.Drawing.Size(113, 69);
            this.ReCAL.TabIndex = 1;
            this.ReCAL.TabStop = false;
            this.ReCAL.Text = "Re CAL";
            this.ReCAL.UseVisualStyleBackColor = false;
            this.ReCAL.Click += new System.EventHandler(this.ReCAL_Click);
            // 
            // ReDownloadCAL
            // 
            this.ReDownloadCAL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReDownloadCAL.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ReDownloadCAL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReDownloadCAL.Location = new System.Drawing.Point(125, 5);
            this.ReDownloadCAL.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.ReDownloadCAL.Name = "ReDownloadCAL";
            this.ReDownloadCAL.Size = new System.Drawing.Size(125, 69);
            this.ReDownloadCAL.TabIndex = 2;
            this.ReDownloadCAL.TabStop = false;
            this.ReDownloadCAL.Text = "Re Download";
            this.ReDownloadCAL.UseVisualStyleBackColor = false;
            this.ReDownloadCAL.Click += new System.EventHandler(this.ReDownloadCAL_Click);
            // 
            // StopStartCAL
            // 
            this.StopStartCAL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StopStartCAL.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLight;
            this.StopStartCAL.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.StopStartCAL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StopStartCAL.Location = new System.Drawing.Point(256, 5);
            this.StopStartCAL.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.StopStartCAL.Name = "StopStartCAL";
            this.StopStartCAL.Size = new System.Drawing.Size(114, 69);
            this.StopStartCAL.TabIndex = 3;
            this.StopStartCAL.TabStop = false;
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
            this.Table.Location = new System.Drawing.Point(0, 0);
            this.Table.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Table.Name = "Table";
            this.Table.RowCount = 1;
            this.Table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Table.Size = new System.Drawing.Size(376, 79);
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
            this.MenuBar.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.ToolsButton,
            this.ActionsButton,
            this.AboutButton});
            // 
            // ToolsButton
            // 
            this.ToolsButton.Index = 0;
            this.ToolsButton.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.TaskMgrButton,
            this.CMDButton,
            this.IPConfigMenuBtn,
            this.ToolsSeperator,
            this.OSKButton});
            this.ToolsButton.Text = "Tools";
            // 
            // TaskMgrButton
            // 
            this.TaskMgrButton.Index = 0;
            this.TaskMgrButton.Text = "Task Manager";
            this.TaskMgrButton.Click += new System.EventHandler(this.TaskMgrButton_Click);
            // 
            // CMDButton
            // 
            this.CMDButton.Index = 1;
            this.CMDButton.Text = "Command Prompt";
            this.CMDButton.Click += new System.EventHandler(this.CMDButton_Click);
            // 
            // IPConfigMenuBtn
            // 
            this.IPConfigMenuBtn.Index = 2;
            this.IPConfigMenuBtn.Text = "IP Configuration";
            this.IPConfigMenuBtn.Click += new System.EventHandler(this.IPConfigMenuBtn_Click);
            // 
            // ToolsSeperator
            // 
            this.ToolsSeperator.Index = 3;
            this.ToolsSeperator.Text = "-";
            // 
            // OSKButton
            // 
            this.OSKButton.Index = 4;
            this.OSKButton.Text = "On Screen Keyboard";
            this.OSKButton.Click += new System.EventHandler(this.OSKButton_Click);
            // 
            // ActionsButton
            // 
            this.ActionsButton.Index = 1;
            this.ActionsButton.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.WipeMenu,
            this.PhaseTwoMenu,
            this.PhaseThreeMenu,
            this.DomainMenu,
            this.AutoLogon,
            this.NetDomButton,
            this.RebootWindows});
            this.ActionsButton.Text = "Actions";
            // 
            // WipeMenu
            // 
            this.WipeMenu.Index = 0;
            this.WipeMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.WipeCalButton,
            this.WipeKeepCalButton});
            this.WipeMenu.Text = "Wipe";
            // 
            // WipeCalButton
            // 
            this.WipeCalButton.Index = 0;
            this.WipeCalButton.Text = "Wipe (Remove CAL)...";
            this.WipeCalButton.Click += new System.EventHandler(this.WipeCalButton_Click);
            // 
            // WipeKeepCalButton
            // 
            this.WipeKeepCalButton.Index = 1;
            this.WipeKeepCalButton.Text = "Wipe (Keep CAL)...";
            this.WipeKeepCalButton.Click += new System.EventHandler(this.WipeKeepCalButton_Click);
            // 
            // PhaseTwoMenu
            // 
            this.PhaseTwoMenu.Index = 1;
            this.PhaseTwoMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.StartPhaseTwoMenuBtn,
            this.PhaseTwoSeperator,
            this.AddSrtTaskButton,
            this.RmvStartTaskButton});
            this.PhaseTwoMenu.Text = "Phase Two (Domain Join)";
            // 
            // StartPhaseTwoMenuBtn
            // 
            this.StartPhaseTwoMenuBtn.Index = 0;
            this.StartPhaseTwoMenuBtn.Text = "Start Phase Two...";
            this.StartPhaseTwoMenuBtn.Click += new System.EventHandler(this.StartPhaseTwoMenuBtn_Click);
            // 
            // PhaseTwoSeperator
            // 
            this.PhaseTwoSeperator.Index = 1;
            this.PhaseTwoSeperator.Text = "-";
            // 
            // AddSrtTaskButton
            // 
            this.AddSrtTaskButton.Index = 2;
            this.AddSrtTaskButton.Text = "Add Startup Task...";
            this.AddSrtTaskButton.Click += new System.EventHandler(this.AddSrtTaskButton_Click);
            // 
            // RmvStartTaskButton
            // 
            this.RmvStartTaskButton.Index = 3;
            this.RmvStartTaskButton.Text = "Remove Startup Task...";
            this.RmvStartTaskButton.Click += new System.EventHandler(this.RmvStartTaskButton_Click);
            // 
            // PhaseThreeMenu
            // 
            this.PhaseThreeMenu.Index = 2;
            this.PhaseThreeMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.StartPhaseThreeMenuBtn,
            this.PhaseThreeSeperator,
            this.AddStartupTaskP2,
            this.RemoveStartupTaskP2});
            this.PhaseThreeMenu.Text = "Phase Three (Logon Check)";
            // 
            // StartPhaseThreeMenuBtn
            // 
            this.StartPhaseThreeMenuBtn.Index = 0;
            this.StartPhaseThreeMenuBtn.Text = "Start Phase Three...";
            this.StartPhaseThreeMenuBtn.Click += new System.EventHandler(this.StartPhaseThreeMenuBtn_Click);
            // 
            // PhaseThreeSeperator
            // 
            this.PhaseThreeSeperator.Index = 1;
            this.PhaseThreeSeperator.Text = "-";
            // 
            // AddStartupTaskP2
            // 
            this.AddStartupTaskP2.Index = 2;
            this.AddStartupTaskP2.Text = "Add Startup Task";
            this.AddStartupTaskP2.Click += new System.EventHandler(this.AddStartupTaskP2_Click);
            // 
            // RemoveStartupTaskP2
            // 
            this.RemoveStartupTaskP2.Index = 3;
            this.RemoveStartupTaskP2.Text = "Remove Startup Task";
            this.RemoveStartupTaskP2.Click += new System.EventHandler(this.RemoveStartupTaskP2_Click);
            // 
            // DomainMenu
            // 
            this.DomainMenu.Index = 3;
            this.DomainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.JoinDomainButton,
            this.JoinWorkButton});
            this.DomainMenu.Text = "Domain";
            // 
            // JoinDomainButton
            // 
            this.JoinDomainButton.Index = 0;
            this.JoinDomainButton.Text = "Join Domain...";
            this.JoinDomainButton.Click += new System.EventHandler(this.JoinDomainButton_Click);
            // 
            // JoinWorkButton
            // 
            this.JoinWorkButton.Index = 1;
            this.JoinWorkButton.Text = "Join Workgroup...";
            this.JoinWorkButton.Click += new System.EventHandler(this.JoinWorkButton_Click);
            // 
            // AutoLogon
            // 
            this.AutoLogon.Index = 4;
            this.AutoLogon.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.EnableAutoLogon,
            this.DisableAutoLogon});
            this.AutoLogon.Text = "Auto Logon";
            // 
            // EnableAutoLogon
            // 
            this.EnableAutoLogon.Index = 0;
            this.EnableAutoLogon.Text = "Enable Auto Logon...";
            this.EnableAutoLogon.Click += new System.EventHandler(this.EnableAutoLogon_Click);
            // 
            // DisableAutoLogon
            // 
            this.DisableAutoLogon.Index = 1;
            this.DisableAutoLogon.Text = "Disable Auto Logon...";
            this.DisableAutoLogon.Click += new System.EventHandler(this.DisableAutoLogon_Click);
            // 
            // NetDomButton
            // 
            this.NetDomButton.Index = 5;
            this.NetDomButton.Text = "Install NETDOM...";
            this.NetDomButton.Click += new System.EventHandler(this.NetDomButton_Click);
            // 
            // RebootWindows
            // 
            this.RebootWindows.Index = 6;
            this.RebootWindows.Text = "Restart Windows...";
            this.RebootWindows.Click += new System.EventHandler(this.RebootWindows_Click);
            // 
            // AboutButton
            // 
            this.AboutButton.Index = 2;
            this.AboutButton.Text = "About";
            this.AboutButton.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(373, 440);
            this.Controls.Add(this.LogRTB);
            this.Controls.Add(this.Table);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Super CAL";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Window_Load);
            this.Table.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button ReCAL;
        private System.Windows.Forms.Button ReDownloadCAL;
        private System.Windows.Forms.Button StopStartCAL;
        private System.Windows.Forms.TableLayoutPanel Table;
        private System.Windows.Forms.RichTextBox LogRTB;
        private System.Windows.Forms.MainMenu MenuBar;
        private System.Windows.Forms.MenuItem ToolsButton;
        private System.Windows.Forms.MenuItem ActionsButton;
        private System.Windows.Forms.MenuItem AboutButton;
        private System.Windows.Forms.MenuItem TaskMgrButton;
        private System.Windows.Forms.MenuItem CMDButton;
        private System.Windows.Forms.MenuItem OSKButton;
        private System.Windows.Forms.MenuItem WipeMenu;
        private System.Windows.Forms.MenuItem PhaseTwoMenu;
        private System.Windows.Forms.MenuItem AddSrtTaskButton;
        private System.Windows.Forms.MenuItem WipeCalButton;
        private System.Windows.Forms.MenuItem WipeKeepCalButton;
        private System.Windows.Forms.MenuItem RmvStartTaskButton;
        private System.Windows.Forms.MenuItem DomainMenu;
        private System.Windows.Forms.MenuItem JoinDomainButton;
        private System.Windows.Forms.MenuItem JoinWorkButton;
        private System.Windows.Forms.MenuItem NetDomButton;
        private System.Windows.Forms.MenuItem RebootWindows;
        private System.Windows.Forms.MenuItem AutoLogon;
        private System.Windows.Forms.MenuItem DisableAutoLogon;
        private System.Windows.Forms.MenuItem EnableAutoLogon;
        private System.Windows.Forms.MenuItem PhaseThreeMenu;
        private System.Windows.Forms.MenuItem AddStartupTaskP2;
        private System.Windows.Forms.MenuItem RemoveStartupTaskP2;
        private System.Windows.Forms.MenuItem IPConfigMenuBtn;
        private System.Windows.Forms.MenuItem StartPhaseTwoMenuBtn;
        private System.Windows.Forms.MenuItem StartPhaseThreeMenuBtn;
        private System.Windows.Forms.MenuItem PhaseThreeSeperator;
        private System.Windows.Forms.MenuItem ToolsSeperator;
        private System.Windows.Forms.MenuItem PhaseTwoSeperator;
    }
}

