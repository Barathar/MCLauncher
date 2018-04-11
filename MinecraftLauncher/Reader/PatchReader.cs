using MCLauncher.Data;
using System;
using System.Collections.Generic;
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
            foreach (var item in files.Descendants("item"))
            {
                result.Add(ReadPatchFile(item));
            }

            return result;
        }
        public List<CleanupDirectory> ReadCleanupDirectories(XDocument document)
        {
            List<CleanupDirectory> result = new List<CleanupDirectory>();

            XElement cleanupList = document.XPathSelectElement("root/cleanupDirectoryList");
            foreach (var item in cleanupList.Descendants("item"))
            {
                result.Add(ReadCleanupDirectory(item));
            }

            return result;
        }

        private PatchFile ReadPatchFile(XElement item)
        {
            PatchFile result = new PatchFile();

            result.Filename = ReadString(item, "name");
            result.DownloadUri = ReadUri(item, "url");
            result.LocalDirectory = ReadString(item, "relPath");
            result.Hash = ReadString(item, "hash");

            return result;
        }
        private CleanupDirectory ReadCleanupDirectory(XElement item)
        {
            CleanupDirectory result = new CleanupDirectory();

            result.LocalDirectory = item.Value;

            return result;
        }

        private string ReadString(XElement item, string itemName)
        {
            return item.XPathSelectElement(itemName).Value;
        }
        private Uri ReadUri(XElement item, string itemName)
        {
            return new Uri(item.XPathSelectElement(itemName).Value);
        }
    }
}
