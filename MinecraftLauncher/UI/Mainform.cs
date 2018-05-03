﻿using MCLauncher.Configuration;
using MCLauncher.Data;
using MCLauncher.Externals;
using MCLauncher.Images;
using MCLauncher.Reader;
using MCLauncher.UI;
using MCLauncher.Utility;
using System;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using System.Xml.Linq;

namespace MinecraftLauncher.UI
{
    public partial class Mainform : Form
    {
        private Image currentSettingsButtonImage;
        private Image currentRefreshButtonImage;

        private SettingsDialog settingsDialog;

        public Mainform(Style style)
        {
            InitializeComponent();
            InitializeImages();

            Console.SetOut(new OutputConsole(this, consoleTextBox));
            OutputConsole.Print(typeof(Paths));

            AssemblyLoader.Load();
            Settings.Default.Load();

            UpdateControls(style);
        }

        private void InitializeImages()
        {
            BackgroundImage = MCLauncher.Properties.Resources._default;
            overlay.Image = MCLauncher.Properties.Resources._default;
            serverPanel.BackgroundImage = MCLauncher.Properties.Resources._default;
            refreshButton.Image = MCLauncher.Properties.Resources._default;
            settingsButton.Image = MCLauncher.Properties.Resources._default;
        }

        private void OnLoad(object sender, EventArgs e)
        {
            DownloadLauncherFromWeb();
        }
        private void OnClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.DialogLocation = Location;
            Settings.Default.Save();
        }
        private void OnSettingsButtonClicked(object sender, EventArgs e)
        {
            ShowSettingsDialog();
        }
        private void OnRefreshButtonClicked(object sender, EventArgs e)
        {
            RefreshServerlist();
        }
        private void OnMouseHover(object sender, EventArgs e)
        {
            (sender as PictureBox).Image = ImageManipulation.CreateLightedImage((sender as PictureBox).Image as Bitmap, 50);
        }
        private void OnMouseLeave(object sender, EventArgs e)
        {
            refreshButton.Image = currentRefreshButtonImage;
            settingsButton.Image = currentSettingsButtonImage;
        }
        private void OnDownloadLauncherCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error != null)
            { 
                return;
            }

            XDocument document = XDocument.Parse(e.Result, LoadOptions.None);
            Launcher launcher = new LauncherReader().Read(document);
            UpdateServerList(launcher);
        }

        // Settingsbutton
        private void ShowSettingsDialog()
        {
            if (IsAnyServerBusy())
                return;

            settingsDialog.ServerIp = Settings.Default.ServerIp;
            settingsDialog.Resolution = Settings.Default.Resolution;
            settingsDialog.RAM = Settings.Default.RAM;
            settingsDialog.Debug = Settings.Default.ShowDebugConsole;
            settingsDialog.DebugVerbose = Settings.Default.DebugVerbose;
            settingsDialog.VerboseLevel = Settings.Default.VerboseLevel;

            if (settingsDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.ServerIp = settingsDialog.ServerIp;
                Settings.Default.Resolution = settingsDialog.Resolution;
                Settings.Default.RAM = settingsDialog.RAM;
                Settings.Default.ShowDebugConsole = settingsDialog.Debug;
                Settings.Default.DebugVerbose = settingsDialog.DebugVerbose;
                Settings.Default.VerboseLevel = settingsDialog.VerboseLevel;
                Settings.Default.Save();

                consoleTextBox.Visible = Settings.Default.ShowDebugConsole;
            }
        }

        // Refreshbutton
        private void RefreshServerlist()
        {
            if (IsAnyServerBusy())
                return;

            DownloadLauncherFromWeb();
        }
        private bool IsAnyServerBusy()
        {
            foreach (ServerControl control in serverPanel.Controls)
            {
                if (control.IsBusy())
                    return true;
            }

            return false;
        }

        // UI update
        private void UpdateServerList(Launcher launcher)
        {
            for (int index = serverPanel.Controls.Count - 1; index >= 0; index--)
            {
                if (launcher.Server.Any(e => e.Version == serverPanel.Controls[index].Name))
                {
                    (serverPanel.Controls[index] as ServerControl).UpdatePatchFileInfo();
                    continue;
                }

                serverPanel.Controls.Remove(serverPanel.Controls[index]);
            }

            foreach (var server in launcher.Server)
            {
                Control[] current = serverPanel.Controls.Find(server.Version, false);
                if (current.Length <= 0)
                {
                    ServerControl control = new ServerControl(server, launcher.Style, launcher.FileInfos);
                    control.Name = server.Version;
                    serverPanel.Controls.Add(control);
                }
            }
        }
        private void UpdateControls(Style style)
        {
            UpdateTitle(style);
            UpdateDialogAppearance(style);
            UpdateDialogSize(style);
            UpdateSettingsDialog(style);
        }
        private void UpdateTitle(Style style)
        {
            Text = $"{style.LauncherTitle} {style.LauncherVersion}";
        }
        private void UpdateDialogAppearance(Style style)
        {
            if (!MD5Hash.IsEqual(BackgroundImage, style.LauncherBackgroundImage))
                BackgroundImage = style.LauncherBackgroundImage;

            if (!MD5Hash.IsEqual(overlay.Image, style.LauncherOverlayImage))
                overlay.Image = style.LauncherOverlayImage;

            if (!MD5Hash.IsEqual(serverPanel.BackgroundImage, style.LauncherOverlayImage))
                serverPanel.BackgroundImage = style.LauncherOverlayImage;

            if (!MD5Hash.IsEqual(refreshButton.Image, style.RefreshButtonImage))
            {
                refreshButton.Image = style.RefreshButtonImage;
                currentRefreshButtonImage = style.RefreshButtonImage;
            }

            if (!MD5Hash.IsEqual(settingsButton.Image, style.SettingsButtonImage))
            {
                settingsButton.Image = style.SettingsButtonImage;
                currentSettingsButtonImage = style.SettingsButtonImage;
            }

            consoleTextBox.BackColor = style.DialogBackgroundColor;
            consoleTextBox.ForeColor = style.DialogFontColor;
            consoleTextBox.Visible = Settings.Default.ShowDebugConsole;
        }
        private void UpdateDialogSize(Style style)
        {
            Width = style.LauncherWidth;
            Height = style.LauncherHeight;
            serverPanel.Width = style.ServerWidth;
            overlay.Width = style.ServerWidth + 20;

            if (HasValidSavedWindowPosition())
                Location = Settings.Default.DialogLocation;
            else
                CenterToScreen();
        }

        private bool HasValidSavedWindowPosition()
        {
            Rectangle currentScreen = Screen.FromControl(this).Bounds;

            if (Settings.Default.DialogLocation.X < 0)
                return false;
            if (Settings.Default.DialogLocation.X >= currentScreen.Width - Size.Width)
                return false;
            if (Settings.Default.DialogLocation.Y < 0)
                return false;
            if (Settings.Default.DialogLocation.Y >= currentScreen.Height - Size.Height)
                return false;

            return true;
        }
        private void UpdateSettingsDialog(Style style)
        {
            settingsDialog = new SettingsDialog(style);
        }

        private void DownloadLauncherFromWeb()
        {
            using (var client = new WebClient())
            {
                client.DownloadStringCompleted += OnDownloadLauncherCompleted;
                client.DownloadStringAsync(new Uri(Settings.Default.ServerIp));
            }
        }
    }
}
