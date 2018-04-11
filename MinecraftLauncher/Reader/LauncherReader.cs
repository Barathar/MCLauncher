using MCLauncher.Configuration;
using MCLauncher.Data;
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
            result.Server = new ServerReader().Read(document);
            result.Style = new StyleReader().Read(document);

            //TODO put in custom class
            result.LauncherFile = Path.Combine(Paths.CurrentDirectory, document.XPathSelectElement("root/launcher/launcherExecutable/relPath").Value);
            result.DefaultLauncherProfiles = new Uri(document.XPathSelectElement("root/launcher/launcherProfilesJson/url").Value);
            result.LauncherProfilesPath = document.XPathSelectElement("root/launcher/launcherProfilesJson/relPath").Value;

            return result;
        }
    }
}
