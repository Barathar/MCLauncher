﻿using MCLauncher.Configuration;
using MCLauncher.Data;
using MCLauncher.Utility;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Security.Cryptography;
using System.Xml.Linq;
using System.Xml.XPath;

namespace MCLauncher.Reader
{
    public class StyleReader
    {
        public Style Read(XDocument document)
        {
            XElement style = document.XPathSelectElement("root/launcher/style");
            return ReadStyle(style);
        }

        private Style ReadStyle(XElement style)
        {
            Style result = new Style();

            result.LauncherTitle = ReadTitle(style);
            result.LauncherVersion = ReadVersion(style);
            result.LauncherWidth = ReadWidth(style);
            result.LauncherHeight = ReadHeight(style);
            result.FontColor = ReadFontColor(style);

            XElement images = style.XPathSelectElement("images");

            result.LauncherBackgroundImage = ReadImage(images, "background") ?? result.LauncherBackgroundImage;
            result.LauncherOverlayImage = ReadImage(style, "overlay") ?? result.LauncherOverlayImage;
            result.ServerOnlineImage = ReadImage(images, "serverOnline") ?? result.ServerOnlineImage;
            result.ServerOfflineImage = ReadImage(images, "serverOffline") ?? result.ServerOfflineImage;
            result.ServerPlayButtonImage = ReadImage(images, "buttonPlay") ?? result.ServerPlayButtonImage;
            result.ServerInstallButtonImage = ReadImage(images, "buttonInstall") ?? result.ServerInstallButtonImage;
            result.ServerUninstallButtonImage = ReadImage(images, "buttonUninstall") ?? result.ServerUninstallButtonImage;
            result.ServerUpdateButtonImage = ReadImage(images, "buttonUpdate") ?? result.ServerUpdateButtonImage;
            result.SettingsButtonImage = ReadImage(images, "buttonSettings") ?? result.SettingsButtonImage;
            result.RefreshButtonImage = ReadImage(images, "buttonRefresh") ?? result.RefreshButtonImage;
            result.ServerPatchNotesButtonImage = ReadImage(images, "buttonPatchnotes") ?? result.ServerPatchNotesButtonImage;

            return result;
        }

        private string ReadTitle(XElement style)
        {
            return style.XPathSelectElement("name").Value;
        }
        private string ReadVersion(XElement style)
        {
            return style.XPathSelectElement("version").Value;
        }
        private int ReadWidth(XElement style)
        {
            return Convert.ToInt32(style.XPathSelectElement("width").Value);

        }
        private int ReadHeight(XElement style)
        {
            return Convert.ToInt32(style.XPathSelectElement("height").Value);

        }
        private Color ReadFontColor(XElement style)
        {
            string colorString = style.XPathSelectElement("fontColor").Value;
            return ColorTranslator.FromHtml(colorString);
        }
        private Image ReadImage(XElement images, string itemName)
        {
            try
            {
                string filename = Path.Combine(Paths.CurrentDirectory, images.XPathSelectElement(itemName + "/relPath").Value.Replace(@"/", "\\"));
                if (File.Exists(filename))
                {
                    string hash = images.XPathSelectElement(itemName + "/hash").Value;
                    string localHash = MD5Hash.FromFile(filename);
                    if (hash == localHash)
                        return Image.FromFile(filename);
                }

                Uri imageUri = new Uri(images.XPathSelectElement(itemName + "/url").Value);
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