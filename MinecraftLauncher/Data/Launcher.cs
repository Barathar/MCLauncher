using MCLauncher.Configuration;
using MCLauncher.Utility;
using System;
using System.Collections.Generic;

namespace MCLauncher.Data
{
    public class Launcher
    {        
        public Uri DefaultProfiles { get; set; }
        public string ProfilesPath { get; set; }
        public string Executable { get; set; } = Paths.DefaultLauncherExecutable;
        [SkipProperty]
        public List<Server> Server { get; set; }
        [SkipProperty]
        public Style Style { get; set; }
    }
}