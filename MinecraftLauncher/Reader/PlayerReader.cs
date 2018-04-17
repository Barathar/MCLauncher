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
            foreach (var player in players.XPathSelectElements("item"))
            {
                result.Add(ReadPlayer(player));
            }

            return result;
        }

        private Player ReadPlayer(XElement player)
        {
            Player result = new Player
            {
                Name = XElementExtender.ReadName(player),
                Image = XElementExtender.ReadImage(player)
            };

            OutputConsole.PrintVerbose(result, 2);
            return result;
        }
    }
}