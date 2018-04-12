using MCLauncher.Data;
using MCLauncher.Utility;
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
            XElement images = style.XPathSelectElement("images");

            Style result = new Style
            {
                LauncherTitle = XElementExtender.ReadString(style, "name"),
                LauncherVersion = XElementExtender.ReadString(style, "version"),
                LauncherWidth = XElementExtender.ReadInteger(style, "width"),
                LauncherHeight = XElementExtender.ReadInteger(style, "height"),
                FontColor = XElementExtender.ReadColor(style, "fontColor"),
                DialogBackgroundColor = XElementExtender.ReadColor(style, "dialogBackgroundColor"),
                DialogFontColor = XElementExtender.ReadColor(style, "dialogFontColor"),
                LauncherBackgroundImage = XElementExtender.ReadImage(images, "background") ?? Properties.Resources.filenotfound,
                LauncherOverlayImage = XElementExtender.ReadImage(images, "overlay") ?? Properties.Resources.filenotfound,
                ServerOnlineImage = XElementExtender.ReadImage(images, "serverOnline") ?? Properties.Resources.filenotfound,
                ServerOfflineImage = XElementExtender.ReadImage(images, "serverOffline") ?? Properties.Resources.filenotfound,
                ServerPlayButtonImage = XElementExtender.ReadImage(images, "buttonPlay") ?? Properties.Resources.filenotfound,
                ServerInstallButtonImage = XElementExtender.ReadImage(images, "buttonInstall") ?? Properties.Resources.filenotfound,
                ServerUninstallButtonImage = XElementExtender.ReadImage(images, "buttonUninstall") ?? Properties.Resources.filenotfound,
                ServerUpdateButtonImage = XElementExtender.ReadImage(images, "buttonUpdate") ?? Properties.Resources.filenotfound,
                SettingsButtonImage = XElementExtender.ReadImage(images, "buttonSettings") ?? Properties.Resources.filenotfound,
                RefreshButtonImage = XElementExtender.ReadImage(images, "buttonRefresh") ?? Properties.Resources.filenotfound,
                ServerPatchNotesButtonImage = XElementExtender.ReadImage(images, "buttonPatchnotes") ?? Properties.Resources.filenotfound
            };            

            OutputConsole.PrintVerbose(result, 3);
            return result;
        }
    }
}