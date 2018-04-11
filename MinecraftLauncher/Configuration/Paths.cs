using System;
using System.IO;
using System.Reflection;

namespace MCLauncher.Configuration
{
    public static class Paths
    {
        public static string CurrentDirectory
        {
            get
            {
                return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            }
        }
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
        public static string SettingsFile
        {
            get
            {
                return Path.Combine(LauncherFilesDirectory, "settings.xml");
            }
        }
        public static string DefaultLauncherFile
        {
            get
            {
                return Path.Combine(Paths.CurrentDirectory, "MinecraftLauncher.exe");
            }
        }

        public static void Print()
        {
            foreach (var prop in typeof(Paths).GetProperties())
            {
                Console.WriteLine("{0}: {1}", prop.Name, prop.GetValue(typeof(Paths), null));
            }
        }
    }
}
