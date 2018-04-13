using System.IO;
using System.Reflection;

namespace MCLauncher.Configuration
{
    public static class Paths
    {
        public static string CurrentDirectory { get { return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location); } }
        public static string DefaultLauncherExecutable { get { return Path.Combine(CurrentDirectory, "MinecraftLauncher.exe"); } }
        public static string LauncherWorkingDirectory { get { return Path.Combine(CurrentDirectory, ".minecraft"); } }
        public static string ServersFile = Path.Combine(LauncherWorkingDirectory, "Servers.dat");

        public static string LauncherFilesDirectory
        {
            get
            {
                string result = Path.Combine(CurrentDirectory, "config");
                if (!Directory.Exists(result))
                    Directory.CreateDirectory(result);

                return result;
            }
        }        
        public static string SettingsFile { get { return Path.Combine(LauncherFilesDirectory, "settings.xml"); } }        
        public static string MinecraftFont { get { return Path.Combine(LauncherFilesDirectory, "Minecraft.ttf"); } }
        public static string JsonAssembly { get { return Path.Combine(CurrentDirectory, "Newtonsoft.Json.dll"); } }
    }
}
