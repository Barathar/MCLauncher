using MCLauncher.Utility;
using System.Collections.Generic;

namespace MCLauncher.Data
{
    public class Serverstatus
    {
        public bool Online { get; set; }
        public string MessageOfTheDay { get; set; }
        public string GameMode { get; set; }
        public int MaxPlayers { get; set; }
        public int CurrentPlayers { get; set; }
        [SkipProperty]
        public List<Player> Players { get; set; }
    }
}
