using MCLauncher.Configuration;
using MCLauncher.Utility;
using MCLauncher.Web;
using System;
using System.Drawing;
using System.IO;
using System.Xml.Linq;
using System.Xml.XPath;

namespace MCLauncher.Reader
{
    public class XElementExtender
    {
        public static string ReadString(XElement item, string itemName)
        {
            return item.XPathSelectElement(itemName).Value;
        }
        public static Uri ReadUri(XElement item, string itemName)
        {
            return new Uri(item.XPathSelectElement(itemName).Value);
        }
        public static Image ReadImage(XElement item, string itemName)
        {
            try
            {                
                string relativePath = item.XPathSelectElement($"{itemName}/relPath").Value;
                string filename = Path.Combine(Paths.CurrentDirectory, relativePath.Replace(@"/", "\\"));
                if (File.Exists(filename))
                {
                    string hash = item.XPathSelectElement($"{itemName}/hash").Value;
                    string localHash = MD5Hash.FromFile(filename);
                    if (hash == localHash)
                        return Image.FromFile(filename);
                }

                Uri imageUri = new Uri(item.XPathSelectElement($"{itemName}/url").Value);
                Downloader.Download(imageUri, filename);

                return Image.FromFile(filename);
            }
            catch (Exception e)
            {                
                OutputConsole.PrintVerbose(e, $"Unable to load image '{itemName}'.", 1);                
                return null;
            }
        }
        public static bool ReadBoolean(XElement item, string itemName)
        {
            return Convert.ToBoolean(item.XPathSelectElement(itemName).Value);
        }
        public static int ReadInteger(XElement item, string itemName)
        {
            return Convert.ToInt32(item.XPathSelectElement(itemName).Value);
        }
        public static Color ReadColor(XElement item, string itemName)
        {
            string colorString = item.XPathSelectElement(itemName).Value;
            return ColorTranslator.FromHtml(colorString);
        }
    }
}
