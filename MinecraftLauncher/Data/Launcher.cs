using MCLauncher.Utility;
using System.Collections.Generic;

namespace MCLauncher.Data
{
    public class Launcher
    {        
        [SkipProperty]
        public List<Server> Server { get; set; }
        [SkipProperty]
        public Style Style { get; set; }
        [SkipProperty]
        public FileInfos FileInfos { get; set; }
    }
}