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
    }
}
