using MCLauncher.Configuration;
using System;
using System.IO;

namespace MCLauncher.Data
{
    public class FileInfos
    {
        // launcher_profiles.json
        public Uri DefaultLauncherProfilesFile { get; set; }
        public string LauncherProfilesFilename { get; set; }

        // options.txt
        public Uri DefaultOptionsFile { get; set; }
        public string OptionsFilename { get; set; }

        // minecraftLauncher.exe
        public Uri DefaultMinecraftLauncherFile { get; set; }
        public string MinecraftLauncherFilename { get; set; }
    }
}
