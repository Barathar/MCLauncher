using MCLauncher.Configuration;
using MCLauncher.Data;
using MCLauncher.Reader;
using MCLauncher.UI;
using System;
using System.Net;
using System.Windows.Forms;
using System.Xml.Linq;

namespace MinecraftLauncher.UI
{
    public partial class Mainform : Form
    {
        public Mainform()
        {
            InitializeComponent();
        }

        private void OnLoad(object sender, EventArgs e)
        {
            DownloadLauncher();
        }
        private void OnDownloadUpdaterInfoCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error != null)
                return;

            XDocument document = XDocument.Parse(e.Result, LoadOptions.None);

            Launcher launcher = new LauncherReader().Read(document);

            UpdateControls(launcher);
        }
        private void OnRefreshButtonClicked(object sender, EventArgs e)
        {
            if (IsAnyServerBusy())
                return;

            DownloadLauncher();
        }     
        private void OnSettingsButtonClicked(object sender, EventArgs e)
        {
            SettingsDialog dlg = new SettingsDialog(Settings.Default.ServerIp, Settings.Default.Resolution, Settings.Default.RAM);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.ServerIp = dlg.ServerIp;
                Settings.Default.Resolution = dlg.Resolution;
                Settings.Default.RAM = dlg.RAM;
                Settings.Default.Save();
            }                
        }

        private void DownloadLauncher()
        {
            using (var client = new WebClient())
            {
                client.DownloadStringCompleted += OnDownloadUpdaterInfoCompleted;
                client.DownloadStringAsync(new Uri(Settings.Default.ServerIp));
            }
        }
        private void UpdateControls(Launcher launcher)
        {
            UpdateTitle(launcher.Style);
            UpdateServerList(launcher);
            UpdateDialogAppearance(launcher.Style);
            UpdateDialogSize(launcher.Style);
        }
        private void UpdateTitle(Style style)
        {
            Text = $"{style.LauncherTitle} {style.LauncherVersion}";
        }
        private void UpdateServerList(Launcher launcher)
        {
            serverPanel.Controls.Clear();
            foreach (var server in launcher.Server)
            {
                serverPanel.Controls.Add(new ServerControl(server, launcher.Style, launcher.DefaultLauncherProfiles, launcher.LauncherProfilesPath, launcher.LauncherFile));
            }
        }
        private void UpdateDialogAppearance(Style style)
        {
            BackgroundImage = style.LauncherBackgroundImage;
            overlay.Image = style.LauncherOverlayImage;
            serverPanel.BackgroundImage = style.LauncherOverlayImage;
            refreshButton.Image = style.RefreshButtonImage;
            settingsButton.Image = style.SettingsButtonImage;
        }
        private void UpdateDialogSize(Style style)
        {
            Width = style.LauncherWidth;
            Height = style.LauncherHeight;
            serverPanel.Width = style.ServerWidth;
            overlay.Width = style.ServerWidth + 20;
        }

        private bool IsAnyServerBusy()
        {
            foreach (ServerControl control in serverPanel.Controls)
            {
                if (control.IsBusy)
                    return true;
            }

            return false;
        }
    }
}
