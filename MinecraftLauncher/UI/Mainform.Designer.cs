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
            this.consoleTextBox = new System.Windows.Forms.TextBox();
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
            this.overlay.Location = new System.Drawing.Point(61, -2);
            this.overlay.Margin = new System.Windows.Forms.Padding(4);
            this.overlay.Name = "overlay";
            this.overlay.Size = new System.Drawing.Size(128, 697);
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
            this.serverPanel.Location = new System.Drawing.Point(72, 46);
            this.serverPanel.Margin = new System.Windows.Forms.Padding(4);
            this.serverPanel.Name = "serverPanel";
            this.serverPanel.Size = new System.Drawing.Size(108, 599);
            this.serverPanel.TabIndex = 2;
            // 
            // refreshButton
            // 
            this.refreshButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.refreshButton.BackColor = System.Drawing.Color.Transparent;
            this.refreshButton.Location = new System.Drawing.Point(925, 631);
            this.refreshButton.Margin = new System.Windows.Forms.Padding(4);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(48, 44);
            this.refreshButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.refreshButton.TabIndex = 3;
            this.refreshButton.TabStop = false;
            this.refreshButton.Click += new System.EventHandler(this.OnRefreshButtonClicked);
            this.refreshButton.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            this.refreshButton.MouseHover += new System.EventHandler(this.OnMouseHover);
            // 
            // settingsButton
            // 
            this.settingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.settingsButton.BackColor = System.Drawing.Color.Transparent;
            this.settingsButton.Location = new System.Drawing.Point(981, 631);
            this.settingsButton.Margin = new System.Windows.Forms.Padding(4);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(48, 44);
            this.settingsButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.settingsButton.TabIndex = 4;
            this.settingsButton.TabStop = false;
            this.settingsButton.Click += new System.EventHandler(this.OnSettingsButtonClicked);
            this.settingsButton.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            this.settingsButton.MouseHover += new System.EventHandler(this.OnMouseHover);
            // 
            // consoleTextBox
            // 
            this.consoleTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.consoleTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.consoleTextBox.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.consoleTextBox.Location = new System.Drawing.Point(197, 15);
            this.consoleTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.consoleTextBox.Multiline = true;
            this.consoleTextBox.Name = "consoleTextBox";
            this.consoleTextBox.ReadOnly = true;
            this.consoleTextBox.Size = new System.Drawing.Size(832, 609);
            this.consoleTextBox.TabIndex = 5;
            // 
            // Mainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1045, 690);
            this.Controls.Add(this.consoleTextBox);
            this.Controls.Add(this.settingsButton);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.serverPanel);
            this.Controls.Add(this.overlay);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Mainform";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MinecraftLauncher";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClosing);
            this.Load += new System.EventHandler(this.OnLoad);
            ((System.ComponentModel.ISupportInitialize)(this.overlay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.refreshButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.settingsButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox overlay;
        private System.Windows.Forms.FlowLayoutPanel serverPanel;
        private System.Windows.Forms.PictureBox refreshButton;
        private System.Windows.Forms.PictureBox settingsButton;
        private System.Windows.Forms.TextBox consoleTextBox;
    }
}

