using MCLauncher.Configuration;
using System;
using System.Collections.Generic;

namespace MCLauncher.Data
{
    public class Launcher
    {        
        public List<Server> Server { get; set; }
        public Style Style { get; set; }

        //TODO put in custom class
        public Uri DefaultLauncherProfiles { get; set; }
        public string LauncherProfilesPath { get; set; }
        public string LauncherFile { get; set; } = Paths.DefaultLauncherFile;
    }
}