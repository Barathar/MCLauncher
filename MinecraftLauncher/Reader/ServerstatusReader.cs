using MCLauncher.Data;
using System;
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

            result.Online = ReadOnline(root);
            result.MessageOfTheDay = ReadMessageOfTheDay(root);
            result.MaxPlayers = ReadMaxPlayer(root);
            result.CurrentPlayers = ReadCurrentPlayers(root);

            return result;
        }

        private bool ReadOnline(XElement root)
        {
            return Convert.ToBoolean(root.XPathSelectElement("online").Value);
        }
        private string ReadMessageOfTheDay(XElement root)
        {
            return root.XPathSelectElement("motd").Value;
        }
        private int ReadMaxPlayer(XElement root)
        {
            return Convert.ToInt32(root.XPathSelectElement("playerMax").Value);
        }
        private int ReadCurrentPlayers(XElement root)
        {
            return Convert.ToInt32(root.XPathSelectElement("playerOnline").Value);
        }        
    }
}