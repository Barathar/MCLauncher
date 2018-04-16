using MCLauncher.Data;
using MCLauncher.Images;
using MCLauncher.Utility;
using System.Collections.Generic;
using System.Drawing;
using System.Xml.Linq;
using System.Xml.XPath;

namespace MCLauncher.Reader
{
    public class ServerReader
    {
        public List<Server> Read(XDocument document)
        {
            XElement versions = document.XPathSelectElement("root/versions");           

            List<Server> result = new List<Server>();
            foreach (var server in versions.XPathSelectElements("item"))
            {
                result.Add(ReadServer(server));
            }

            return result;
        }

        private Server ReadServer(XElement server)
        {
            XElement images = server.XPathSelectElement("style/images");
            XElement launcherProfile = server.XPathSelectElement("launcherProfile");
            XElement resourcepacks = server.XPathSelectElement("options/resourcepacks");

            Server result = new Server
            {
                Name = XElementExtender.ReadString(server, "name"),
                Version = XElementExtender.ReadString(server, "version"),
                Ip = XElementExtender.ReadString(server, "server/url"),
                State = XElementExtender.ReadString(server, "state"),
                StatusUri = XElementExtender.ReadUri(server, "status"),
                PatchNotesUri = XElementExtender.ReadUri(server, "patchnotesUrl"),
                PatchFilesUri = XElementExtender.ReadUri(server, "patchUrl"),
                Image = XElementExtender.ReadImage(images, "background") ?? Properties.Resources.filenotfound,                
                LauncherProfileData = ReadLauncherProfileData(launcherProfile),
                Resourcepacks = ReadResourcepacks(resourcepacks)
            };

            result.GrayScaledImage = ImageManipulation.CreateGrayScaledImage(result.Image as Bitmap);

            OutputConsole.PrintVerbose(result, 1);
            return result;
        }
        private LauncherProfileData ReadLauncherProfileData(XElement launcherProfile)
        {
            LauncherProfileData result = new LauncherProfileData
            {
                Name = XElementExtender.ReadString(launcherProfile, "name"),
                Type = XElementExtender.ReadString(launcherProfile, "type"),
                Icon = XElementExtender.ReadString(launcherProfile, "icon"),
                LastVersionId = XElementExtender.ReadString(launcherProfile, "lastVersionId"),
                JavaArgs = XElementExtender.ReadString(launcherProfile, "javaArgs"),
                GameDirectory = XElementExtender.ReadString(launcherProfile, "gameDir")
            };

            OutputConsole.PrintVerbose(result, 1);
            return result;
        }
        private List<string> ReadResourcepacks(XElement resourcepacks)
        {
            List<string> result = new List<string>();
            foreach (var item in resourcepacks.XPathSelectElements("item"))
            {
                result.Add(item.Value);
            }

            return result;
        }
    }
}