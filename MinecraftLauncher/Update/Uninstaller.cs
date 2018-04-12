using MCLauncher.Configuration;
using MCLauncher.Utility;
using System.IO;

namespace MCLauncher.Update
{
    public class Uninstaller
    {
        public void Uninstall(string directory)
        {
            if (!Directory.Exists(directory))
                return;

            if (!IsValidSubDirectory(directory))
                return;
            
            OutputConsole.Print($"[Uninstalling] {directory}");
            Directory.Delete(directory, true);
        }

        private bool IsValidSubDirectory(string filename)
        {
            DirectoryInfo currentDir = new DirectoryInfo(filename);
            DirectoryInfo compareDir = new DirectoryInfo(Paths.CurrentDirectory);

            while (currentDir.Parent != null)
            {
                if (currentDir.Parent.FullName == compareDir.FullName)
                {
                    return true;
                }
                else currentDir = currentDir.Parent;
            }

            return false;
        }
    }
}
