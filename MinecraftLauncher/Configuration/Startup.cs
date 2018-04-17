using MCLauncher.Reader;
using MCLauncher.Utility;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.XPath;

namespace MCLauncher.Configuration
{
    public static class Startup
    {
        public static bool HasValidExecutablePath()
        {
            if (Paths.ExecutingDirectory.Any(x => Char.IsWhiteSpace(x)))
            {
                MessageBox.Show($"Executable path with whitespaces is not allowed! ({Paths.ExecutingDirectory}).", "Invalid executable path", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }

            return true;
        }
        public static void MakeSureConfigurationDirectoryExists()
        {
            if (!Directory.Exists(Paths.ConfigurationsDirectory))
                Directory.CreateDirectory(Paths.ConfigurationsDirectory);
        }
        public static void CheckForNewVersion(XDocument document)
        {
            XElement launcherVersion = document.XPathSelectElement("root/launcher/launcherExecutable");
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
