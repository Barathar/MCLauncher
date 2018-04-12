using MCLauncher.Configuration;
using MCLauncher.Data;
using MCLauncher.Utility;
using System;
using System.IO;
using System.Xml.Linq;
using System.Xml.XPath;

namespace MCLauncher.Reader
{
    public class LauncherReader
    {
        public Launcher Read(XDocument document)
        {
            Launcher result = new Launcher
            {
                Executable = Path.Combine(Paths.CurrentDirectory, document.XPathSelectElement("root/launcher/launcherExecutable/relPath").Value),
                DefaultProfiles = new Uri(document.XPathSelectElement("root/launcher/launcherProfilesJson/url").Value),
                ProfilesPath = document.XPathSelectElement("root/launcher/launcherProfilesJson/relPath").Value,
                Server = new ServerReader().Read(document),
                Style = new StyleReader().Read(document)
            };

            OutputConsole.PrintVerbose(result, 1);
            return result;
        }
    }
}
