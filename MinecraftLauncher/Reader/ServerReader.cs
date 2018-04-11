using MCLauncher.Configuration;
using MCLauncher.Data;
using MCLauncher.Utility;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
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

            result.Name = ReadName(server);
            result.Version = ReadVersion(server);
            result.Ip = ReadIp(server);
            result.State = ReadState(server);
            result.StatusUri = ReadStatusUri(server);
            result.PatchNotesUri = ReadPatchnotesUri(server);
            result.PatchFilesUri = ReadPatchUri(server);

            XElement launcherProfile = server.XPathSelectElement("launcherProfile"); 
            result.LauncherProfileData = ReadLauncherProfileData(launcherProfile);

            XElement images = server.XPathSelectElement("style/images");
            result.Image = ReadImage(images) ?? result.Image;
            result.GrayScaledImage = ImageManipulation.CreateGrayScaledImage(result.Image as Bitmap);

            return result;
        }

        private string ReadName(XElement server)
        {
            return server.XPathSelectElement("name").Value;
        }
        private string ReadVersion(XElement server)
        {
            return server.XPathSelectElement("version").Value;
        }
        private string ReadIp(XElement server)
        {
            return server.XPathSelectElement("server/url").Value;
        }
        private string ReadState(XElement server)
        {
            return server.XPathSelectElement("state").Value;
        }
        private Uri ReadStatusUri(XElement server)
        {
            return new Uri(server.XPathSelectElement("status").Value);
        }
        private Uri ReadPatchnotesUri(XElement server)
        {
            return new Uri(server.XPathSelectElement("patchnotesUrl").Value);
        }
        private Uri ReadPatchUri(XElement server)
        {
            return new Uri(server.XPathSelectElement("patchUrl").Value);
        }
        private LauncherProfileData ReadLauncherProfileData(XElement launcherProfile)
        {
            LauncherProfileData result = new LauncherProfileData();
            result.Name = ReadLauncherName(launcherProfile);
            result.Type = ReadLauncherType(launcherProfile);
            result.Icon = ReadLauncherIcon(launcherProfile);
            result.LastVersionId = ReadLauncherVersionId(launcherProfile);
            result.JavaArgs = ReadLauncherJavaArgs(launcherProfile);
            result.GameDirectory = ReadLauncherGameDir(launcherProfile);
            return result;
        }
        private string ReadLauncherName(XElement launcherProfile)
        {
            return launcherProfile.XPathSelectElement("name").Value;
        }
        private string ReadLauncherType(XElement launcherProfile)
        {
            return launcherProfile.XPathSelectElement("type").Value;
        }
        private string ReadLauncherIcon(XElement launcherProfile)
        {
            return launcherProfile.XPathSelectElement("icon").Value;
        }
        private string ReadLauncherVersionId(XElement launcherProfile)
        {
            return launcherProfile.XPathSelectElement("lastVersionId").Value;
        }
        private string ReadLauncherGameDir(XElement launcherProfile)
        {
            return launcherProfile.XPathSelectElement("gameDir").Value;
        }
        private string ReadLauncherJavaArgs(XElement launcherProfile)
        {
            return launcherProfile.XPathSelectElement("javaArgs").Value;
        }

        private Image ReadImage(XElement images)
        {
            try
            {
                string filename = Path.Combine(Paths.CurrentDirectory, images.XPathSelectElement("background/relPath").Value.Replace(@"/", "\\"));
                if (File.Exists(filename))
                {
                    string hash = images.XPathSelectElement("background/hash").Value;
                    string localHash = MD5Hash.FromFile(filename);
                    if (hash == localHash)
                        return Image.FromFile(filename);
                }

                Uri imageUri = new Uri(images.XPathSelectElement("background/url").Value);
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