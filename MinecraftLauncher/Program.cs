using MCLauncher.Configuration;
using MCLauncher.Data;
using MCLauncher.Reader;
using MinecraftLauncher.UI;
using System;
using System.Net;
using System.Windows.Forms;
using System.Xml.Linq;

namespace MinecraftLauncher
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (!Startup.HasValidExecutablePath())
                return;

            Startup.MakeSureConfigurationDirectoryExists();
            DownloadLauncherFromWeb();

            Application.Run();
        }

        private static void OnDownloadLauncherCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                Application.Exit();
                return;
            }

            XDocument document = XDocument.Parse(e.Result, LoadOptions.None);
            Startup.CheckForNewVersion(document);
            Launcher launcher = new LauncherReader().Read(document);
            new Mainform(launcher.Style).ShowDialog();
            Application.Exit();
        }

        private static void DownloadLauncherFromWeb()
        {
            using (var client = new WebClient())
            {
                client.DownloadStringCompleted += OnDownloadLauncherCompleted;
                client.DownloadStringAsync(new Uri(Settings.Default.ServerIp));
            }
        }
    }
}
