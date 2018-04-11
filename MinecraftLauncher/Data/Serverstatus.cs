using MCLauncher.Utility;
using System;
using System.Drawing;

namespace MCLauncher.Data
{
    public class Serverstatus
    {
        public bool Online { get; set; }
        public string MessageOfTheDay { get; set; }
        public int MaxPlayers { get; set; }
        public int CurrentPlayers { get; set; }

        //TODO READ players
    }
}
