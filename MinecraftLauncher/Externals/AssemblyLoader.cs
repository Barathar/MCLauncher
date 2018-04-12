using MCLauncher.Configuration;
using System;
using System.Drawing.Text;
using System.IO;

namespace MCLauncher.Externals
{
    public static class AssemblyLoader
    {        
        public static void Load()
        {
            Console.WriteLine($"[Loading assembly] {Paths.JsonAssembly}");

            if (!AssemblyExists())
                CreateAssemblyOnDisc();
        }

        private static bool AssemblyExists()
        {
            return File.Exists(Paths.JsonAssembly);
        }
        private static void CreateAssemblyOnDisc()
        {
            File.WriteAllBytes(Paths.JsonAssembly, Properties.Resources.Newtonsoft_Json);
        }
    }
}
