using System.Collections.Generic;

namespace MCLauncher.Data
{
    public class Serverstatus
    {
        public bool Online { get; set; }
        public string MessageOfTheDay { get; set; }
        public int MaxPlayers { get; set; }
        public int CurrentPlayers { get; set; }
        public List<Player> Players { get; set; }
    }
}
