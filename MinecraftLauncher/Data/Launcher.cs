using MCLauncher.Configuration;
using System;
using System.Collections.Generic;
using System.IO;

namespace MCLauncher.Data
{
    public class Launcher
    {        
        public List<Server> Server { get; set; }
        public Style Style { get; set; }        

        public Uri DefaultLauncherProfiles { get; set; }
        public string LauncherProfilesPath { get; set; }
        public string LauncherFile { get; set; } = Path.Combine(Paths.CurrentDirectory, "MinecraftLauncher.exe");
    }
}