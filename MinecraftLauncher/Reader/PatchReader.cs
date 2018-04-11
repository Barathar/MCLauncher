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

            result.Filename = ReadFilename(item);
            result.DownloadUri = ReadDownloadUri(item);
            result.LocalDirectory = ReadLocalDirectory(item);
            result.Hash = ReadHash(item);

            return result;
        }
        private string ReadFilename(XElement item)
        {
            return item.XPathSelectElement("name").Value;
        }
        private Uri ReadDownloadUri(XElement item)
        {
            return new Uri(item.XPathSelectElement("url").Value);
        }
        private string ReadLocalDirectory(XElement item)
        {
            return item.XPathSelectElement("relPath").Value;
        }
        private string ReadHash(XElement item)
        {
            return item.XPathSelectElement("hash").Value;
        }

        private CleanupDirectory ReadCleanupDirectory(XElement item)
        {
            CleanupDirectory result = new CleanupDirectory();

            result.LocalDirectory = item.Value;

            return result;
        }
    }
}
