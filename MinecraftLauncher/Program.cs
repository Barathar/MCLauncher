using MCLauncher.Utility;
using MinecraftLauncher.UI;
using System;
using System.Windows.Forms;

namespace MinecraftLauncher
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            StartupCheck.CheckForValidExecutablePath();

            Application.Run(new Mainform());
        }
    }
}
