using MCLauncher.Data;
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
            foreach (var server in versions.Descendants("item"))
            {
                result.Add(ReadServer(server));
            }

            return result;
        }

        private Server ReadServer(XElement server)
        {
            Server result = new Server();
            result.Name = XElementExtender.ReadString(server, "name");
            result.Version = XElementExtender.ReadString(server, "version");
            result.Ip = XElementExtender.ReadString(server, "server/url");
            result.State = XElementExtender.ReadString(server, "state");
            result.StatusUri = XElementExtender.ReadUri(server, "status");
            result.PatchNotesUri = XElementExtender.ReadUri(server, "patchnotesUrl");
            result.PatchFilesUri = XElementExtender.ReadUri(server, "patchUrl");

            XElement launcherProfile = server.XPathSelectElement("launcherProfile");
            result.LauncherProfileData = ReadLauncherProfileData(launcherProfile);

            XElement images = server.XPathSelectElement("style/images");
            result.Image = XElementExtender.ReadImage(images, "background") ?? result.Image;
            result.GrayScaledImage = ImageManipulation.CreateGrayScaledImage(result.Image as Bitmap);

            return result;
        }
        private LauncherProfileData ReadLauncherProfileData(XElement launcherProfile)
        {
            LauncherProfileData result = new LauncherProfileData();
            result.Name = XElementExtender.ReadString(launcherProfile, "name");
            result.Type = XElementExtender.ReadString(launcherProfile, "type");
            result.Icon = XElementExtender.ReadString(launcherProfile, "icon");
            result.LastVersionId = XElementExtender.ReadString(launcherProfile, "lastVersionId");
            result.JavaArgs = XElementExtender.ReadString(launcherProfile, "javaArgs");
            result.GameDirectory = XElementExtender.ReadString(launcherProfile, "gameDir");

            return result;
        }
    }
}