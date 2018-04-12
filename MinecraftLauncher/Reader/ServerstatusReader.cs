using MCLauncher.Data;
using MCLauncher.Utility;
using System.Xml.Linq;
using System.Xml.XPath;

namespace MCLauncher.Reader
{
    public class ServerstatusReader
    {        
        public Serverstatus Read(XDocument document)
        {
            XElement root = document.XPathSelectElement("root");

            Serverstatus result = new Serverstatus
            {
                Online = XElementExtender.ReadBoolean(root, "online"),
                MessageOfTheDay = XElementExtender.ReadString(root, "motd"),
                MaxPlayers = XElementExtender.ReadInteger(root, "playerMax"),
                CurrentPlayers = XElementExtender.ReadInteger(root, "playerOnline"),
                Players = new PlayerReader().Read(document)
            };

            OutputConsole.PrintVerbose(result, 2);
            return result;
        }     
    }
}