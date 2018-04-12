using MCLauncher.Data;
using MCLauncher.Utility;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Xml.XPath;

namespace MCLauncher.Reader
{
    public class PlayerReader
    {
        public List<Player> Read(XDocument document)
        {
            XElement players = document.XPathSelectElement("root/players");

            List<Player> result = new List<Player>();
            foreach (var player in players.Descendants("item"))
            {
                result.Add(ReadPlayer(player));
            }

            return result;
        }

        private Player ReadPlayer(XElement player)
        {
            Player result = new Player();
            result.Name = XElementExtender.ReadString(player, "name");
            result.Image = XElementExtender.ReadImage(player, "image");

            return result;
        }
    }
}