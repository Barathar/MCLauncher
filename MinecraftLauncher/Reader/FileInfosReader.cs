using MCLauncher.Configuration;
using MCLauncher.Data;
using MCLauncher.Utility;
using System.IO;
using System.Xml.Linq;
using System.Xml.XPath;

namespace MCLauncher.Reader
{
    public class FileInfosReader
    {
        public FileInfos Read(XDocument document)
        {
            XElement launcher = document.XPathSelectElement("root/launcher");

            FileInfos result = new FileInfos()
            {
                Executable = Path.Combine(Paths.CurrentDirectory, XElementExtender.ReadString(launcher, "launcherExecutable/relPath")),
                DefaultProfiles = XElementExtender.ReadUri(launcher, "launcherProfilesJson/url"),
                ProfilesPath = Path.Combine(Paths.CurrentDirectory, XElementExtender.ReadString(launcher, "launcherProfilesJson/relPath")),
                DefaultOptions = XElementExtender.ReadUri(launcher, "OptionsTxt/url"),
                OptionsPath = XElementExtender.ReadString(launcher, "OptionsTxt/relPath"),
            };

            OutputConsole.PrintVerbose(result, 1);
            return result;
        }
    }
}