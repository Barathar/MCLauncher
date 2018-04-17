using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace MCLauncher.Configuration
{
    public static class Paths
    {
        public static string ExecutingDirectory { get { return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location); } }
        public static string ConfigurationsDirectory { get { return Path.Combine(ExecutingDirectory, "config"); } }
        public static string MinecraftDirectory { get { return Path.Combine(ExecutingDirectory, ".minecraft"); } }
        public static string ServersFile { get { return Path.Combine(MinecraftDirectory, "Servers.dat"); } }
        public static string SettingsFile { get { return Path.Combine(ConfigurationsDirectory, "settings.xml"); } }
        public static string MinecraftFontFile { get { return Path.Combine(ConfigurationsDirectory, "Minecraft.ttf"); } }
        public static string JsonAssemblyFile { get { return Path.Combine(ExecutingDirectory, "Newtonsoft.Json.dll"); } }
    }
}
