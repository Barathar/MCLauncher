﻿using System;
using System.Drawing;

namespace MCLauncher.Data
{
    public class Server
    {
        public int StatusPollingInterval { get; set; } = 10_000;
        public string Name { get; set; }
        public string Version { get; set; }
        public string Ip { get; set; }
        public string State { get; set; }
        public Uri StatusUri { get; set; }
        public Uri PatchNotesUri { get; set; }
        public Uri PatchFilesUri { get; set; }
        public LauncherProfileData LauncherProfileData { get; set; }
        public Image Image { get; set; } = Properties.Resources.filenotfound;
        public Image GrayScaledImage { get; set; } = Properties.Resources.filenotfound;
    }
}
