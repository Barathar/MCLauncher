using MCLauncher.Configuration;
using MCLauncher.Reader;
using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.XPath;

namespace MCLauncher.Utility
{
    public static class StartupCheck
    {
        public static void CheckForValidExecutablePath()
        {
            if (Paths.CurrentDirectory.Any(x => Char.IsWhiteSpace(x)))
            {
                MessageBox.Show($"Executable path with whitespaces is not allowed! ({Paths.CurrentDirectory}).");
                return;
            }
        }

        public static void CheckForNewVersion(XDocument document)
        {
            XElement launcherVersion = document.XPathSelectElement("root/launcher/launcherVersion");
            string hash = XElementExtender.ReadString(launcherVersion, "hash");

            string filename = Process.GetCurrentProcess().MainModule.FileName;
            string compareHash = MD5Hash.FromFile(filename);
            if (hash == compareHash)
                return;

            if (MessageBox.Show("There is a new version of this software available. Do you want to download the latest version?", "New Version", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {
                Uri uri = XElementExtender.ReadUri(launcherVersion, "url");
                Process.Start(uri.ToString());
            }
        }
    }
}
