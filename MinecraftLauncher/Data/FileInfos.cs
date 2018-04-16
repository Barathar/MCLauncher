using MCLauncher.Configuration;
using System;

namespace MCLauncher.Data
{
    public class FileInfos
    {
        public Uri DefaultProfiles { get; set; }
        public string ProfilesPath { get; set; }
        public string Executable { get; set; } = Paths.DefaultLauncherExecutable;
        public Uri DefaultOptions { get; set; }
        public string OptionsPath { get; set; }
    }
}
