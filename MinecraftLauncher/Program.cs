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
            
            //Console.SetOut(writer);
            Settings.Default.Load();
            Application.Run(new Mainform());
        }
    }
}
