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

            Serverstatus result = new Serverstatus();

            result.Online = XElementExtender.ReadBoolean(root, "online");
            result.MessageOfTheDay = XElementExtender.ReadString(root, "motd");
            result.MaxPlayers = XElementExtender.ReadInteger(root, "playerMax");
            result.CurrentPlayers = XElementExtender.ReadInteger(root, "playerOnline");
            result.Players = new PlayerReader().Read(document);

            return result;
        }     
    }
}