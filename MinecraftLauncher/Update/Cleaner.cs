using MCLauncher.Configuration;
using MCLauncher.Data;
using MCLauncher.Utility;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MCLauncher.Update
{
    public class Cleaner
    {
        public List<CleanupDirectory> CleanupDirectories { get; set; } = new List<CleanupDirectory>();
        public List<PatchFile> PatchFiles { get; set; } = new List<PatchFile>();

        public void Clean()
        {
            foreach (var directory in CleanupDirectories)
            {
                string fullDirectoryName = Path.Combine(Paths.ExecutingDirectory, directory.LocalDirectory);
                if (!Directory.Exists(fullDirectoryName))
                    continue;

                if (!IsValidSubDirectory(fullDirectoryName))
                    continue;

                foreach (string file in Directory.GetFiles(fullDirectoryName, "*.*", SearchOption.AllDirectories))
                {
                    string relativePath = file.Replace(@"\", "/");
                    if (PatchFiles.Any(e => relativePath.Contains(e.LocalDirectory)))
                        continue;

                    OutputConsole.Print($"[Cleaning] {file}");
                    File.Delete(file);
                }
            }
            OutputConsole.Print($"[Cleaning done]");            
        }

        private bool IsValidSubDirectory(string filename)
        {
            DirectoryInfo currentDir = new DirectoryInfo(filename);
            DirectoryInfo compareDir = new DirectoryInfo(Paths.ExecutingDirectory);

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
