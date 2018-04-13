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
            XElement launcher = document.XPathSelectElement("root/launcher");

            Launcher result = new Launcher
            {
                Executable = Path.Combine(Paths.CurrentDirectory, XElementExtender.ReadString(launcher, "launcherExecutable/relPath")),
                DefaultProfiles = XElementExtender.ReadUri(launcher, "launcherProfilesJson/url"),
                ProfilesPath = Path.Combine(Paths.CurrentDirectory, XElementExtender.ReadString(launcher, "launcherProfilesJson/relPath")),
                Server = new ServerReader().Read(document),
                Style = new StyleReader().Read(document)
            };

            OutputConsole.PrintVerbose(result, 1);
            return result;
        }
    }
}
