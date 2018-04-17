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
                if (!Directory.Exists(directory.LocalDirectory))
                    continue;

                if (!IsValidSubDirectory(directory.LocalDirectory))
                    continue;

                foreach (string file in Directory.GetFiles(directory.LocalDirectory, "*.*", SearchOption.AllDirectories))
                {                    
                    if (PatchFiles.Any(e => file.Contains(e.LocalDirectory)))
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
