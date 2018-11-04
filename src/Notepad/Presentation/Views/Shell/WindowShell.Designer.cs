namespace Notepad.Presentation.Views.Shell {
    partial class WindowShell
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
            this.uxMainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.uxEditorTextBox = new System.Windows.Forms.RichTextBox();
            this.uxStatusBar = new System.Windows.Forms.StatusStrip();
            this.SuspendLayout();
            // 
            // uxMainMenuStrip
            // 
            this.uxMainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.uxMainMenuStrip.Name = "uxMainMenuStrip";
            this.uxMainMenuStrip.Size = new System.Drawing.Size(292, 24);
            this.uxMainMenuStrip.TabIndex = 0;
            this.uxMainMenuStrip.Text = "menuStrip1";
            // 
            // uxEditorTextBox
            // 
            this.uxEditorTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uxEditorTextBox.Location = new System.Drawing.Point(0, 24);
            this.uxEditorTextBox.Name = "uxEditorTextBox";
            this.uxEditorTextBox.Size = new System.Drawing.Size(292, 249);
            this.uxEditorTextBox.TabIndex = 1;
            this.uxEditorTextBox.Text = "";
            // 
            // uxStatusBar
            // 
            this.uxStatusBar.Location = new System.Drawing.Point(0, 251);
            this.uxStatusBar.Name = "uxStatusBar";
            this.uxStatusBar.Size = new System.Drawing.Size(292, 22);
            this.uxStatusBar.TabIndex = 2;
            this.uxStatusBar.Text = "statusStrip1";
            // 
            // MainShellView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.uxStatusBar);
            this.Controls.Add(this.uxEditorTextBox);
            this.Controls.Add(this.uxMainMenuStrip);
            this.MainMenuStrip = this.uxMainMenuStrip;
            this.Name = "MainShellView";
            this.Text = "Notepad";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip uxMainMenuStrip;
        private System.Windows.Forms.RichTextBox uxEditorTextBox;
        private System.Windows.Forms.StatusStrip uxStatusBar;
    }
}