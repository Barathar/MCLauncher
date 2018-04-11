using System.Drawing;

namespace MCLauncher.Data
{
    public class Style
    {
        public string LauncherTitle { get; set; } = "MCLauncher";
        public string LauncherVersion { get; set; } = "1.0.0";
        public int LauncherWidth { get; set; } = 800;
        public int LauncherHeight { get; set; } = 600;
        public Image LauncherBackgroundImage { get; set; } = Properties.Resources.connectionlost;
        public Image LauncherOverlayImage { get; set; } = Properties.Resources.overlay;
        public Image RefreshButtonImage { get; set; } = Properties.Resources.refresh;
        public Image SettingsButtonImage { get; set; } = Properties.Resources.uninstall;

        public int ServerWidth { get; set; } = 500;
        public int ServerHeight { get; set; } = 150;
        public Image ServerOnlineImage { get; set; } = Properties.Resources.serveravailable;
        public Image ServerOfflineImage { get; set; } = Properties.Resources.serverunavailable;
        public Image ServerPlayButtonImage { get; set; } = Properties.Resources.play;
        public Image ServerInstallButtonImage { get; set; } = Properties.Resources.download;
        public Image ServerUninstallButtonImage { get; set; } = Properties.Resources.download;
        public Image ServerUpdateButtonImage { get; set; } = Properties.Resources.update;
        public Image ServerPatchNotesButtonImage { get; set; } = Properties.Resources.changes;

        public Color FontColor { get; set; } = Color.Black;
        public Color DialogBackgroundColor { get; set; } = Color.Green;
        public Color DialogFontColor { get; set; } = Color.White;
    }
}
