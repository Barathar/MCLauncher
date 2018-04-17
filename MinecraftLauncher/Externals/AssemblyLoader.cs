using MCLauncher.Configuration;
using System;
using System.IO;

namespace MCLauncher.Externals
{
    public static class AssemblyLoader
    {        
        public static void Load()
        {
            Console.WriteLine($"[Loading assembly] {Paths.JsonAssemblyFile}");

            if (!AssemblyExists())
                CreateAssemblyOnDisc();
        }

        private static bool AssemblyExists()
        {
            return File.Exists(Paths.JsonAssemblyFile);
        }
        private static void CreateAssemblyOnDisc()
        {
            File.WriteAllBytes(Paths.JsonAssemblyFile, Properties.Resources.Newtonsoft_Json);
        }
    }
}
