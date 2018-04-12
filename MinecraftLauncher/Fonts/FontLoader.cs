using MCLauncher.Configuration;
using System;
using System.Drawing.Text;
using System.IO;

namespace MCLauncher.Fonts
{
    public static class FontLoader
    {
        private static PrivateFontCollection minecraftFont = null;

        public static PrivateFontCollection MinecraftFont
        {
            get
            {
                if (minecraftFont == null)
                    Load();

                return minecraftFont;
            }
        }

        private static void Load()
        {
            Console.WriteLine($"[Loading font] {Paths.MinecraftFont}");

            if (!FontExists())
                CreateFontOnDisc();

            LoadFont();
        }

        private static bool FontExists()
        {
            return File.Exists(Paths.MinecraftFont);
        }
        private static void CreateFontOnDisc()
        {
            File.WriteAllBytes(Paths.MinecraftFont, Properties.Resources.Minecraft);
        }
        private static void LoadFont()
        {
            PrivateFontCollection pfc = new PrivateFontCollection();
            pfc.AddFontFile(Paths.MinecraftFont);

            minecraftFont = pfc;
        }
    }
}
