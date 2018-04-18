using MCLauncher.Data;
using MCLauncher.Utility;
using System.Xml.Linq;
using System.Xml.XPath;

namespace MCLauncher.Reader
{
    public class FileInfosReader
    {
        public FileInfos Read(XDocument document)
        {            
            XElement launcherProfilesJson = document.XPathSelectElement("root/launcher/launcherProfilesJson");
            XElement optionsTxt = document.XPathSelectElement("root/launcher/optionsTxt");
            XElement minecraftExecutable = document.XPathSelectElement("root/launcher/minecraftExecutable");

            FileInfos result = new FileInfos()
            { 
                DefaultLauncherProfilesFile = XElementExtender.ReadUri(launcherProfilesJson),
                LauncherProfilesFilename = XElementExtender.ReadPath(launcherProfilesJson),
                DefaultOptionsFile = XElementExtender.ReadUri(optionsTxt),
                OptionsFilename = XElementExtender.ReadRelativePath(optionsTxt),
                DefaultMinecraftLauncherFile = XElementExtender.ReadUri(minecraftExecutable),
                MinecraftLauncherFilename = XElementExtender.ReadPath(minecraftExecutable),
                MinecraftLauncherHash = XElementExtender.ReadHash(minecraftExecutable)
            };

            OutputConsole.PrintVerbose(result, 1);
            return result;
        }
    }
}