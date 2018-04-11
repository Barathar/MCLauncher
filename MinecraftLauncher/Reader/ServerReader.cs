using MCLauncher.Configuration;
using MCLauncher.Data;
using MCLauncher.Utility;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
            result.Name = ReadString(server, "name");
            result.Version = ReadString(server, "version");
            result.Ip = ReadString(server, "server/url");
            result.State = ReadString(server , "state");
            result.StatusUri = ReadUri(server, "status");
            result.PatchNotesUri = ReadUri(server, "patchnotesUrl");
            result.PatchFilesUri = ReadUri(server, "patchUrl");

            XElement launcherProfile = server.XPathSelectElement("launcherProfile"); 
            result.LauncherProfileData = ReadLauncherProfileData(launcherProfile);

            XElement images = server.XPathSelectElement("style/images");
            result.Image = ReadImage(images, "background") ?? result.Image;
            result.GrayScaledImage = ImageManipulation.CreateGrayScaledImage(result.Image as Bitmap);

            return result;
        }
        private LauncherProfileData ReadLauncherProfileData(XElement launcherProfile)
        {
            LauncherProfileData result = new LauncherProfileData();
            result.Name = ReadString(launcherProfile, "name");
            result.Type = ReadString(launcherProfile, "type");
            result.Icon = ReadString(launcherProfile, "icon");
            result.LastVersionId = ReadString(launcherProfile, "lastVersionId");
            result.JavaArgs = ReadString(launcherProfile, "gameDir");
            result.GameDirectory = ReadString(launcherProfile, "javaArgs");

            return result;
        }

        private string ReadString(XElement server, string itemName)
        {
            return server.XPathSelectElement(itemName).Value;
        }
        private Uri ReadUri(XElement item, string itemName)
        {
            return new Uri(item.XPathSelectElement(itemName).Value);
        }
        private Image ReadImage(XElement images, string itemName)
        {
            try
            {
                string filename = Path.Combine(Paths.CurrentDirectory, images.XPathSelectElement($"{itemName}/relPath").Value.Replace(@"/", "\\"));
                if (File.Exists(filename))
                {
                    string hash = images.XPathSelectElement($"{itemName}/hash").Value;
                    string localHash = MD5Hash.FromFile(filename);
                    if (hash == localHash)
                        return Image.FromFile(filename);
                }

                Uri imageUri = new Uri(images.XPathSelectElement($"{itemName}/url").Value);
                Downloader.Download(imageUri, filename);

                return Image.FromFile(filename);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}