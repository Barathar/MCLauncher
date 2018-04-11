namespace MinecraftLauncher.UI
{
    partial class Mainform
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mainform));
            this.overlay = new System.Windows.Forms.PictureBox();
            this.serverPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.refreshButton = new System.Windows.Forms.PictureBox();
            this.settingsButton = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.overlay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.refreshButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.settingsButton)).BeginInit();
            this.SuspendLayout();
            // 
            // overlay
            // 
            this.overlay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.overlay.BackColor = System.Drawing.Color.Transparent;
            this.overlay.Location = new System.Drawing.Point(46, -2);
            this.overlay.Name = "overlay";
            this.overlay.Size = new System.Drawing.Size(96, 566);
            this.overlay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.overlay.TabIndex = 1;
            this.overlay.TabStop = false;
            // 
            // serverPanel
            // 
            this.serverPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.serverPanel.BackColor = System.Drawing.Color.Transparent;
            this.serverPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.serverPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.serverPanel.Location = new System.Drawing.Point(54, 37);
            this.serverPanel.Name = "serverPanel";
            this.serverPanel.Size = new System.Drawing.Size(81, 487);
            this.serverPanel.TabIndex = 2;
            // 
            // refreshButton
            // 
            this.refreshButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.refreshButton.BackColor = System.Drawing.Color.Transparent;
            this.refreshButton.Location = new System.Drawing.Point(694, 513);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(36, 36);
            this.refreshButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.refreshButton.TabIndex = 3;
            this.refreshButton.TabStop = false;
            this.refreshButton.Click += new System.EventHandler(this.OnRefreshButtonClicked);
            // 
            // settingsButton
            // 
            this.settingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.settingsButton.BackColor = System.Drawing.Color.Transparent;
            this.settingsButton.Location = new System.Drawing.Point(736, 513);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(36, 36);
            this.settingsButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.settingsButton.TabIndex = 4;
            this.settingsButton.TabStop = false;
            this.settingsButton.Click += new System.EventHandler(this.OnSettingsButtonClicked);
            // 
            // Mainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.settingsButton);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.serverPanel);
            this.Controls.Add(this.overlay);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Mainform";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MinecraftLauncher";
            this.Load += new System.EventHandler(this.OnLoad);
            ((System.ComponentModel.ISupportInitialize)(this.overlay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.refreshButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.settingsButton)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox overlay;
        private System.Windows.Forms.FlowLayoutPanel serverPanel;
        private System.Windows.Forms.PictureBox refreshButton;
        private System.Windows.Forms.PictureBox settingsButton;
    }
}

