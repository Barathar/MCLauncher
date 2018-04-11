using MCLauncher.Configuration;
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

            Mainform form = new Mainform();
            Settings.Default.Load();
            Paths.Print();
            Application.Run(form);
        }
    }
}
