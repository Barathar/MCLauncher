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
                DefaultLauncherProfilesFile = XElementExtender.ReadUri(launcher, "launcherProfilesJson/url"),
                LauncherProfilesFilename = Path.Combine(Paths.CurrentDirectory, XElementExtender.ReadString(launcher, "launcherProfilesJson/relPath")),
                DefaultOptionsFile = XElementExtender.ReadUri(launcher, "optionsTxt/url"),
                OptionsFilename = XElementExtender.ReadString(launcher, "optionsTxt/relPath"),
                DefaultMinecraftLauncherFile = XElementExtender.ReadUri(launcher, "minecraftExecutable/url"),
                MinecraftLauncherFilename = Path.Combine(Paths.CurrentDirectory, XElementExtender.ReadString(launcher, "minecraftExecutable/relPath"))
            };

            OutputConsole.PrintVerbose(result, 1);
            return result;
        }
    }
}