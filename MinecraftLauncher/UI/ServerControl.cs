using MCLauncher.Configuration;
using MCLauncher.Data;
using MCLauncher.Fonts;
using MCLauncher.Images;
using MCLauncher.Reader;
using MCLauncher.Update;
using MCLauncher.Utility;
using MCLauncher.Web;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using System.Xml.Linq;

namespace MCLauncher.UI
{
    public partial class ServerControl : UserControl
    {
        private Server server = null;
        private Style style = null;
        private FileInfos fileInfos = null;

        private Patcher patcher = new Patcher();
        private Cleaner cleaner = new Cleaner();
        private Timer statusUpdateTimer = new Timer();

        public ServerControl(Server server, Style style, FileInfos fileInfos)
        {
            this.server = server;
            this.style = style;
            this.fileInfos = fileInfos;

            Visible = false;

            InitializeComponent();
            InitializeSize();
            InitializeTimer();
            RegisterEvents();
            DownloadPatchFileInfo();
            DownloadServerstatus();
        }

        public bool InstallationDirectoryExists()
        {
            string installDir = GetInstallationDirectory();
            return Directory.Exists(installDir);
        }
        public bool IsBusy()
        {
            return downloadThread.IsBusy;
        }

        private void OnTimerTick(Object sender, EventArgs eventArgs)
        {
            DownloadServerstatus();
        }
        private void OnDoWork(object sender, DoWorkEventArgs e)
        {
            HandleMainButtonClick();
        }
        private void OnWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            UpdateControls();
            EnableTimer(true);
        }
        private void OnProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }
        private void OnPatcherUpdateProgress(int progressPercentage)
        {
            downloadThread.ReportProgress(progressPercentage);
        }
        private void OnDownloadPatchFileInfoCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error != null)
                return;

            XDocument document = XDocument.Parse(e.Result, LoadOptions.None);
            UpdatePatchFiles(document);
            UpdateControls();
        }
        private void OnDownloadServerstatusCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error != null)
                return;

            XDocument document = XDocument.Parse(e.Result, LoadOptions.None);
            Serverstatus status = new ServerstatusReader().Read(document);
            UpdateStatusControls(status);
        }
        private void OnButtonClicked(object sender, EventArgs e)
        {
            if (downloadThread.IsBusy)
                return;

            EnableTimer(false);
            uninstallButton.Enabled = false;
            downloadThread.RunWorkerAsync();
        }
        private void OnUninstallButtonClicked(object sender, EventArgs e)
        {
            UninstallFiles();
        }
        private void OnPatchNotesButtonClicked(object sender, EventArgs e)
        {
            ShowPatchNotes();
        }

        private void InitializeSize()
        {
            Width = style.ServerWidth;
            Height = style.ServerHeight;
        }
        private void InitializeTimer()
        {
            statusUpdateTimer.Tick += new EventHandler(OnTimerTick);
            statusUpdateTimer.Interval = server.StatusPollingInterval;
            EnableTimer(true);
        }
        private void RegisterEvents()
        {
            patcher.UpdateProgress += OnPatcherUpdateProgress;
        }

        private void DownloadPatchFileInfo()
        {
            using (var client = new WebClient())
            {
                client.DownloadStringCompleted += OnDownloadPatchFileInfoCompleted;
                client.DownloadStringAsync(server.PatchFilesUri);
            }
        }
        private void DownloadServerstatus()
        {
            using (var client = new WebClient())
            {
                client.DownloadStringCompleted += OnDownloadServerstatusCompleted;
                client.DownloadStringAsync(server.StatusUri);
            }
        }
        private void UpdatePatchFiles(XDocument document)
        {
            PatchReader reader = new PatchReader();

            List<PatchFile> patchFiles = reader.ReadPatchFiles(document);
            List<CleanupDirectory> cleanupDirectories = reader.ReadCleanupDirectories(document);

            patcher.PatchFiles = patchFiles;
            cleaner.PatchFiles = patchFiles;
            cleaner.CleanupDirectories = cleanupDirectories;
        }

        private void UpdateStatusControls(Serverstatus status)
        {
            serverStatus.Image = status.Online ? style.ServerOnlineImage : style.ServerOfflineImage;

            motdLabel.Visible = status.Online;
            motdLabel.Font = new Font(FontLoader.MinecraftFont.Families[0], motdLabel.Font.Size);
            motdLabel.ForeColor = style.FontColor;
            motdLabel.Text = status.MessageOfTheDay;

            playersLabel.Visible = status.Online;
            playersLabel.Font = new Font(FontLoader.MinecraftFont.Families[0], playersLabel.Font.Size);
            playersLabel.ForeColor = style.FontColor;
            playersLabel.Text = $"{status.CurrentPlayers}/{status.MaxPlayers}";

            UpdatePlayerList(status.Players);
        }
        private void UpdatePlayerList(List<Player> players)
        {
            for (int index = playersFlowLayoutPanel.Controls.Count - 1; index >= 0; index--)
            {
                if (players.Any(e => e.Name == playersFlowLayoutPanel.Controls[index].Name))
                    continue;

                playersFlowLayoutPanel.Controls.Remove(playersFlowLayoutPanel.Controls[index]);
            }

            foreach (var player in players)
            {
                Control[] current = playersFlowLayoutPanel.Controls.Find(player.Name, false);
                if (current.Length <= 0)
                {
                    PictureBox playerBox = new PictureBox();
                    playerBox.BackColor = Color.Transparent;
                    playerBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    playerBox.Width = 20;
                    playerBox.Height = 20;
                    playerBox.Name = player.Name;
                    playerBox.Image = player.Image;
                    playersFlowLayoutPanel.Controls.Add(playerBox);

                    new ToolTip().SetToolTip(playerBox, player.Name);
                }
            }
        }

        private void UpdateControls()
        {
            BackgroundImage = InstallationDirectoryExists() ? server.Image : server.GrayScaledImage;

            nameLabel.Font = new Font(FontLoader.MinecraftFont.Families[0], nameLabel.Font.Size);
            nameLabel.ForeColor = style.FontColor;
            nameLabel.Text = server.Name;

            versionLabel.Font = new Font(FontLoader.MinecraftFont.Families[0], versionLabel.Font.Size);
            versionLabel.ForeColor = style.FontColor;
            versionLabel.Text = $"{server.Version} ({server.State})";

            ipLabel.Font = new Font(FontLoader.MinecraftFont.Families[0], ipLabel.Font.Size);
            ipLabel.ForeColor = style.FontColor;
            ipLabel.Text = server.Ip;

            progressBar.Value = 0;
            progressBar.Visible = !InstallationDirectoryExists() || patcher.UpdateNeeded;

            button.Image = GetButtonImage();

            uninstallButton.Image = InstallationDirectoryExists() ? style.ServerUninstallButtonImage : style.ServerUninstallButtonGrayScaledImage;
            uninstallButton.Enabled = InstallationDirectoryExists();

            patchNotesButton.Image = style.ServerPatchNotesButtonImage;

            Visible = true;
        }
        private Image GetButtonImage()
        {
            if (!InstallationDirectoryExists())
                return style.ServerInstallButtonImage;

            if (patcher.UpdateNeeded)
                return style.ServerUpdateButtonImage;

            return style.ServerPlayButtonImage;
        }

        private void HandleMainButtonClick()
        {
            if (patcher.UpdateNeeded)
            {
                PatchFiles();
                CleanFiles();
            }
            else
            {
                PatchMinecraftLauncher();
                PatchLauncherProfile();
                PatchOptions();
                CopyServersFile();
                LaunchMinecraft();
            }
        }
        private void PatchFiles()
        {
            patcher.Patch();
        }
        private void CleanFiles()
        {
            cleaner.Clean();
        }
        private void PatchMinecraftLauncher()
        {
            if (!File.Exists(fileInfos.MinecraftLauncherFilename))
                Downloader.Download(fileInfos.DefaultMinecraftLauncherFile, fileInfos.MinecraftLauncherFilename);

            OutputConsole.Print($"[Patching] {fileInfos.MinecraftLauncherFilename}");
        }
        private void PatchLauncherProfile()
        {
            LauncherProfilePatcher patcher = new LauncherProfilePatcher(fileInfos.DefaultLauncherProfilesFile);
            patcher.Patch(fileInfos.LauncherProfilesFilename, server.LauncherProfileData);

            OutputConsole.Print($"[Patching] {fileInfos.LauncherProfilesFilename}");
        }
        private void PatchOptions()
        {
            OptionsPatcher patcher = new OptionsPatcher(fileInfos.DefaultOptionsFile);
            string filename = Path.Combine(GetInstallationDirectory(), fileInfos.OptionsFilename);
            patcher.Patch(filename, server.Options);

            OutputConsole.Print($"[Patching] {filename}");
        }
        private void CopyServersFile()
        {
            if (File.Exists(Paths.ServersFile))
            {
                File.Delete(Paths.ServersFile);
                OutputConsole.Print($"[Deleting] {Paths.ServersFile}");
            }

            string sourceFile = Path.Combine(Paths.ExecutingDirectory, server.Version, "Servers.dat");
            if (File.Exists(sourceFile))
            {
                File.Copy(sourceFile, Paths.ServersFile);
                OutputConsole.Print($"[Copying] {sourceFile}");
            }
        }
        private void LaunchMinecraft()
        {
            if (!File.Exists(fileInfos.MinecraftLauncherFilename))
                return;

            string parameters = $"--workDir {Paths.MinecraftDirectory}";
            Process.Start(fileInfos.MinecraftLauncherFilename, parameters);
            OutputConsole.Print($"[Running] {fileInfos.MinecraftLauncherFilename}'\n with parameters '{parameters}'");
        }
        private void UninstallFiles()
        {
            EnableTimer(false);
            ConfirmDialog dlg = new ConfirmDialog(style, $"Uninstall '{server.Name} ({server.Version})'?");
            if (dlg.ShowDialog() == DialogResult.OK)
                new Uninstaller().Uninstall(GetInstallationDirectory());

            UpdateControls();
            EnableTimer(true);
        }
        private void ShowPatchNotes()
        {
            EnableTimer(false);
            PatchNotes dlg = new PatchNotes(style, server.PatchNotesUri);
            dlg.ShowDialog();
            EnableTimer(true);
        }

        private string GetInstallationDirectory()
        {
            return Path.Combine(Paths.ExecutingDirectory, server.Version);
        }
        private void EnableTimer(bool enable)
        {
            if (enable && !statusUpdateTimer.Enabled)
                statusUpdateTimer.Start();
            else
                statusUpdateTimer.Stop();
        }
    }
}
