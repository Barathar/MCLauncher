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
            Launcher result = new Launcher();
            result.Executable = Path.Combine(Paths.CurrentDirectory, document.XPathSelectElement("root/launcher/launcherExecutable/relPath").Value);
            result.DefaultProfiles = new Uri(document.XPathSelectElement("root/launcher/launcherProfilesJson/url").Value);
            result.ProfilesPath = document.XPathSelectElement("root/launcher/launcherProfilesJson/relPath").Value;
            result.Server = new ServerReader().Read(document);
            result.Style = new StyleReader().Read(document);

            OutputConsole.PrintVerbose(result, 1);
            return result;
        }
    }
}
