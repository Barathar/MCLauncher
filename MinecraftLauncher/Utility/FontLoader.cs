using MCLauncher.Configuration;
using System.Drawing.Text;
using System.IO;

namespace MCLauncher.Utility
{
    public static class FontLoader
    {
        private static string minecraftFontFile = Path.Combine(Paths.LauncherFilesDirectory, "Minecraft.ttf");
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
            if (!File.Exists(minecraftFontFile))
                File.WriteAllBytes(minecraftFontFile, Properties.Resources.Minecraft);

            PrivateFontCollection pfc = new PrivateFontCollection();
            pfc.AddFontFile(minecraftFontFile);

            minecraftFont = pfc;
        }
    }
}
