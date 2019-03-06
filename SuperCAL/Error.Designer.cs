namespace SuperCAL
{
    partial class Error
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
            this.Exit = new System.Windows.Forms.Button();
            this.ErrorBox = new System.Windows.Forms.RichTextBox();
            this.Retry = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Exit
            // 
            this.Exit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Exit.Location = new System.Drawing.Point(256, 139);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(64, 23);
            this.Exit.TabIndex = 0;
            this.Exit.Text = "Exit";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // ErrorBox
            // 
            this.ErrorBox.BackColor = System.Drawing.SystemColors.Control;
            this.ErrorBox.Location = new System.Drawing.Point(10, 12);
            this.ErrorBox.Name = "ErrorBox";
            this.ErrorBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedHorizontal;
            this.ErrorBox.Size = new System.Drawing.Size(311, 113);
            this.ErrorBox.TabIndex = 1;
            this.ErrorBox.Text = "";
            // 
            // Retry
            // 
            this.Retry.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Retry.Location = new System.Drawing.Point(187, 139);
            this.Retry.Name = "Retry";
            this.Retry.Size = new System.Drawing.Size(64, 23);
            this.Retry.TabIndex = 2;
            this.Retry.Text = "Retry";
            this.Retry.UseVisualStyleBackColor = true;
            this.Retry.Click += new System.EventHandler(this.Retry_Click);
            // 
            // Error
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 174);
            this.ControlBox = false;
            this.Controls.Add(this.Retry);
            this.Controls.Add(this.ErrorBox);
            this.Controls.Add(this.Exit);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Error";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Super CAL: Error";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.RichTextBox ErrorBox;
        private System.Windows.Forms.Button Retry;
    }
}