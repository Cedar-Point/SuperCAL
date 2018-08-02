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
            this.ReCAL = new System.Windows.Forms.Button();
            this.ReDownloadCAL = new System.Windows.Forms.Button();
            this.StopStartCAL = new System.Windows.Forms.Button();
            this.Table = new System.Windows.Forms.TableLayoutPanel();
            this.LogRTB = new System.Windows.Forms.RichTextBox();
            this.Table.SuspendLayout();
            this.SuspendLayout();
            // 
            // ReCAL
            // 
            this.ReCAL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReCAL.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReCAL.Location = new System.Drawing.Point(6, 5);
            this.ReCAL.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.ReCAL.Name = "ReCAL";
            this.ReCAL.Size = new System.Drawing.Size(110, 66);
            this.ReCAL.TabIndex = 1;
            this.ReCAL.Text = "Re CAL";
            this.ReCAL.UseVisualStyleBackColor = false;
            this.ReCAL.Click += new System.EventHandler(this.ReCAL_Click);
            // 
            // ReDownloadCAL
            // 
            this.ReDownloadCAL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReDownloadCAL.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReDownloadCAL.Location = new System.Drawing.Point(122, 5);
            this.ReDownloadCAL.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.ReDownloadCAL.Name = "ReDownloadCAL";
            this.ReDownloadCAL.Size = new System.Drawing.Size(122, 66);
            this.ReDownloadCAL.TabIndex = 2;
            this.ReDownloadCAL.Text = "Re Download";
            this.ReDownloadCAL.UseVisualStyleBackColor = false;
            this.ReDownloadCAL.Click += new System.EventHandler(this.ReDownloadCAL_Click);
            // 
            // StopStartCAL
            // 
            this.StopStartCAL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StopStartCAL.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLight;
            this.StopStartCAL.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StopStartCAL.Location = new System.Drawing.Point(250, 5);
            this.StopStartCAL.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.StopStartCAL.Name = "StopStartCAL";
            this.StopStartCAL.Size = new System.Drawing.Size(110, 66);
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
            this.Table.Location = new System.Drawing.Point(0, 0);
            this.Table.Name = "Table";
            this.Table.RowCount = 1;
            this.Table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Table.Size = new System.Drawing.Size(366, 76);
            this.Table.TabIndex = 4;
            // 
            // LogRTB
            // 
            this.LogRTB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LogRTB.Location = new System.Drawing.Point(6, 82);
            this.LogRTB.Name = "LogRTB";
            this.LogRTB.ReadOnly = true;
            this.LogRTB.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.LogRTB.Size = new System.Drawing.Size(354, 346);
            this.LogRTB.TabIndex = 5;
            this.LogRTB.Text = "";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 435);
            this.Controls.Add(this.LogRTB);
            this.Controls.Add(this.Table);
            this.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
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
    }
}

