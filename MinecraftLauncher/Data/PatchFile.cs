using System;

namespace MCLauncher.Data
{
    public class PatchFile
    {
        public string Filename { get; set; }
        public string LocalDirectory { get; set; }
        public Uri DownloadUri { get; set; }
        public string Hash { get; set; }        
    }
}