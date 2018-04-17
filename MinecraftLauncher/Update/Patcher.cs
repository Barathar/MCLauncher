using MCLauncher.Configuration;
using MCLauncher.Data;
using MCLauncher.Utility;
using MCLauncher.Web;
using System.Collections.Generic;
using System.IO;

namespace MCLauncher.Update
{
    public class Patcher
    {
        public delegate void UpdateProgressDelegate(int progressPercentage);
        public event UpdateProgressDelegate UpdateProgress;

        public List<PatchFile> PatchFiles { get; set; } = new List<PatchFile>();

        public bool UpdateNeeded { get { return GetUpdateableFiles().Count > 0; } }

        public void Patch()
        {
            List<PatchFile> updateableFiles = GetUpdateableFiles();

            int index = 1;
            foreach (var file in updateableFiles)
            {
                UpdateProgress?.Invoke((100 * index / updateableFiles.Count));
                OutputConsole.Print($"[Updating] [{index}/{updateableFiles.Count}] {file.LocalDirectory}");
                Downloader.Download(file.DownloadUri, Path.Combine(Paths.ExecutingDirectory, file.LocalDirectory));
                index++;
            }
            OutputConsole.Print($"[Updating done]");
        }

        private List<PatchFile> GetUpdateableFiles()
        {
            List<PatchFile> result = new List<PatchFile>();
            foreach (var file in PatchFiles)
            {
                string localFilename = Path.Combine(Paths.ExecutingDirectory, file.LocalDirectory);
                if (File.Exists(localFilename))
                {
                    string hash = MD5Hash.FromFile(localFilename);
                    if (hash == file.Hash)
                        continue;
                }

                if (!IsValidSubDirectory(localFilename))
                    continue;

                result.Add(file);
            }

            return result;
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
