using MCLauncher.Configuration;
using MinecraftLauncher.UI;
using System;
using System.Linq;
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

            if (Paths.CurrentDirectory.Any(x => Char.IsWhiteSpace(x)))
            {
                MessageBox.Show($"Executable path with whitespaces is not allowed! ({Paths.CurrentDirectory}).");
                return;
            }

            Application.Run(new Mainform());
        }
    }
}
