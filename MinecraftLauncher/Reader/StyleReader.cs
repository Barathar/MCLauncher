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
            Style result = new Style();

            result.LauncherTitle = XElementExtender.ReadString(style, "name");
            result.LauncherVersion = XElementExtender.ReadString(style, "version");
            result.LauncherWidth = XElementExtender.ReadInteger(style, "width");
            result.LauncherHeight = XElementExtender.ReadInteger(style, "height");
            result.FontColor = XElementExtender.ReadColor(style, "fontColor");
            result.DialogBackgroundColor = XElementExtender.ReadColor(style, "dialogBackgroundColor");
            result.DialogFontColor = XElementExtender.ReadColor(style, "dialogFontColor");

            XElement images = style.XPathSelectElement("images");

            result.LauncherBackgroundImage = XElementExtender.ReadImage(images, "background") ?? result.LauncherBackgroundImage;
            result.LauncherOverlayImage = XElementExtender.ReadImage(style, "overlay") ?? result.LauncherOverlayImage;
            result.ServerOnlineImage = XElementExtender.ReadImage(images, "serverOnline") ?? result.ServerOnlineImage;
            result.ServerOfflineImage = XElementExtender.ReadImage(images, "serverOffline") ?? result.ServerOfflineImage;
            result.ServerPlayButtonImage = XElementExtender.ReadImage(images, "buttonPlay") ?? result.ServerPlayButtonImage;
            result.ServerInstallButtonImage = XElementExtender.ReadImage(images, "buttonInstall") ?? result.ServerInstallButtonImage;
            result.ServerUninstallButtonImage = XElementExtender.ReadImage(images, "buttonUninstall") ?? result.ServerUninstallButtonImage;
            result.ServerUpdateButtonImage = XElementExtender.ReadImage(images, "buttonUpdate") ?? result.ServerUpdateButtonImage;
            result.SettingsButtonImage = XElementExtender.ReadImage(images, "buttonSettings") ?? result.SettingsButtonImage;
            result.RefreshButtonImage = XElementExtender.ReadImage(images, "buttonRefresh") ?? result.RefreshButtonImage;
            result.ServerPatchNotesButtonImage = XElementExtender.ReadImage(images, "buttonPatchnotes") ?? result.ServerPatchNotesButtonImage;

            return result;
        }        
    }
}