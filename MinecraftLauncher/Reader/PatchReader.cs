using MCLauncher.Configuration;
using MCLauncher.Data;
using MCLauncher.Utility;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using System.Xml.XPath;

namespace MCLauncher.Reader
{
    public class PatchReader
    {
        public List<PatchFile> ReadPatchFiles(XDocument document)
        {
            XElement files = document.XPathSelectElement("root/files");

            List<PatchFile> result = new List<PatchFile>();
            foreach (var item in files.XPathSelectElements("item"))
            {
                result.Add(ReadPatchFile(item));
            }

            return result;
        }
        public List<CleanupDirectory> ReadCleanupDirectories(XDocument document)
        {
            XElement cleanupList = document.XPathSelectElement("root/cleanupDirectoryList");

            List<CleanupDirectory> result = new List<CleanupDirectory>();
            foreach (var item in cleanupList.XPathSelectElements("item"))
            {
                result.Add(ReadCleanupDirectory(item));
            }

            return result;
        }

        private PatchFile ReadPatchFile(XElement item)
        {
            PatchFile result = new PatchFile
            {
                Filename = XElementExtender.ReadName(item),
                DownloadUri = XElementExtender.ReadUri(item),
                LocalDirectory = XElementExtender.ReadPath(item),
                Hash = XElementExtender.ReadHash(item)
            };

            OutputConsole.PrintVerbose(result, 5);
            return result;
        }
        private CleanupDirectory ReadCleanupDirectory(XElement item)
        {
            CleanupDirectory result = new CleanupDirectory
            {
                LocalDirectory = XElementExtender.ReadPath(item);
            };

            OutputConsole.PrintVerbose(result, 5);
            return result;
        }
    }
}
