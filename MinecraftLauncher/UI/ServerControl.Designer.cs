namespace MCLauncher.UI
{
    partial class ServerControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button = new System.Windows.Forms.PictureBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.serverStatus = new System.Windows.Forms.PictureBox();
            this.versionLabel = new System.Windows.Forms.Label();
            this.ipLabel = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.uninstallButton = new System.Windows.Forms.PictureBox();
            this.patchNotesButton = new System.Windows.Forms.PictureBox();
            this.downloadThread = new System.ComponentModel.BackgroundWorker();
            this.motdLabel = new System.Windows.Forms.Label();
            this.playersLabel = new System.Windows.Forms.Label();
            this.playersFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.button)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.serverStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uninstallButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.patchNotesButton)).BeginInit();
            this.SuspendLayout();
            // 
            // button
            // 
            this.button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button.BackColor = System.Drawing.Color.Transparent;
            this.button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button.Location = new System.Drawing.Point(295, 100);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(160, 36);
            this.button.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.button.TabIndex = 0;
            this.button.TabStop = false;
            this.button.Click += new System.EventHandler(this.OnButtonClicked);
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Verdana", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.Location = new System.Drawing.Point(3, 63);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(230, 42);
            this.nameLabel.TabIndex = 1;
            this.nameLabel.Text = "nameLabel";
            // 
            // serverStatus
            // 
            this.serverStatus.BackColor = System.Drawing.Color.Transparent;
            this.serverStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.serverStatus.Location = new System.Drawing.Point(10, 15);
            this.serverStatus.Name = "serverStatus";
            this.serverStatus.Size = new System.Drawing.Size(40, 40);
            this.serverStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.serverStatus.TabIndex = 2;
            this.serverStatus.TabStop = false;
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.versionLabel.Location = new System.Drawing.Point(7, 110);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(100, 18);
            this.versionLabel.TabIndex = 3;
            this.versionLabel.Text = "versionLabel";
            // 
            // ipLabel
            // 
            this.ipLabel.AutoSize = true;
            this.ipLabel.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ipLabel.Location = new System.Drawing.Point(7, 128);
            this.ipLabel.Name = "ipLabel";
            this.ipLabel.Size = new System.Drawing.Size(58, 18);
            this.ipLabel.TabIndex = 4;
            this.ipLabel.Text = "ipLabel";
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.BackColor = System.Drawing.Color.Black;
            this.progressBar.ForeColor = System.Drawing.Color.Black;
            this.progressBar.Location = new System.Drawing.Point(295, 136);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(160, 3);
            this.progressBar.Step = 1;
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 5;
            // 
            // uninstallButton
            // 
            this.uninstallButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.uninstallButton.BackColor = System.Drawing.Color.Transparent;
            this.uninstallButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.uninstallButton.Location = new System.Drawing.Point(455, 100);
            this.uninstallButton.Name = "uninstallButton";
            this.uninstallButton.Size = new System.Drawing.Size(18, 18);
            this.uninstallButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.uninstallButton.TabIndex = 6;
            this.uninstallButton.TabStop = false;
            this.uninstallButton.Click += new System.EventHandler(this.OnUninstallButtonClicked);
            // 
            // patchNotesButton
            // 
            this.patchNotesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.patchNotesButton.BackColor = System.Drawing.Color.Transparent;
            this.patchNotesButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.patchNotesButton.Location = new System.Drawing.Point(455, 117);
            this.patchNotesButton.Name = "patchNotesButton";
            this.patchNotesButton.Size = new System.Drawing.Size(18, 18);
            this.patchNotesButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.patchNotesButton.TabIndex = 7;
            this.patchNotesButton.TabStop = false;
            this.patchNotesButton.Click += new System.EventHandler(this.OnPatchNotesButtonClicked);
            // 
            // downloadThread
            // 
            this.downloadThread.WorkerReportsProgress = true;
            this.downloadThread.DoWork += new System.ComponentModel.DoWorkEventHandler(this.OnDoWork);
            this.downloadThread.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.OnProgressChanged);
            this.downloadThread.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.OnWorkerCompleted);
            // 
            // motdLabel
            // 
            this.motdLabel.AutoEllipsis = true;
            this.motdLabel.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.motdLabel.Location = new System.Drawing.Point(56, 15);
            this.motdLabel.Name = "motdLabel";
            this.motdLabel.Size = new System.Drawing.Size(417, 40);
            this.motdLabel.TabIndex = 8;
            this.motdLabel.Text = "motdLabel";
            // 
            // playersLabel
            // 
            this.playersLabel.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playersLabel.Location = new System.Drawing.Point(373, 70);
            this.playersLabel.Name = "playersLabel";
            this.playersLabel.Size = new System.Drawing.Size(100, 18);
            this.playersLabel.TabIndex = 9;
            this.playersLabel.Text = "playersLabel";
            this.playersLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // playersFlowLayoutPanel
            // 
            this.playersFlowLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.playersFlowLayoutPanel.Location = new System.Drawing.Point(153, 38);
            this.playersFlowLayoutPanel.Name = "playersFlowLayoutPanel";
            this.playersFlowLayoutPanel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.playersFlowLayoutPanel.Size = new System.Drawing.Size(320, 23);
            this.playersFlowLayoutPanel.TabIndex = 10;
            // 
            // ServerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.playersFlowLayoutPanel);
            this.Controls.Add(this.playersLabel);
            this.Controls.Add(this.motdLabel);
            this.Controls.Add(this.patchNotesButton);
            this.Controls.Add(this.uninstallButton);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.ipLabel);
            this.Controls.Add(this.versionLabel);
            this.Controls.Add(this.serverStatus);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.button);
            this.DoubleBuffered = true;
            this.Name = "ServerControl";
            this.Size = new System.Drawing.Size(495, 150);
            this.Load += new System.EventHandler(this.OnLoad);
            ((System.ComponentModel.ISupportInitialize)(this.button)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.serverStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uninstallButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.patchNotesButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox button;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.PictureBox serverStatus;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.Label ipLabel;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.PictureBox uninstallButton;
        private System.Windows.Forms.PictureBox patchNotesButton;
        private System.ComponentModel.BackgroundWorker downloadThread;
        private System.Windows.Forms.Label motdLabel;
        private System.Windows.Forms.Label playersLabel;
        private System.Windows.Forms.FlowLayoutPanel playersFlowLayoutPanel;
    }
}
