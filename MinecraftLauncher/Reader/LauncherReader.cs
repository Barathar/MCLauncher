using MCLauncher.Data;
using MCLauncher.Utility;
using System.Xml.Linq;

namespace MCLauncher.Reader
{
    public class LauncherReader
    {
        public Launcher Read(XDocument document)
        {            
            Launcher result = new Launcher
            {
                Server = new ServerReader().Read(document),
                Style = new StyleReader().Read(document),
                FileInfos = new FileInfosReader().Read(document)
            };

            OutputConsole.PrintVerbose(result, 1);
            return result;
        }
    }
}
