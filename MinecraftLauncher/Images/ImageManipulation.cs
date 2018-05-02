using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace MCLauncher.Images
{
    public static class ImageManipulation
    {
        public static Bitmap CreateGrayScaledImage(Bitmap original)
        {
            Bitmap result = new Bitmap(original.Width, original.Height);

            ColorMatrix colorMatrix = new ColorMatrix(new float[][]
                {
                new float[] {.3f, .3f, .3f, 0, 0},
                new float[] {.59f, .59f, .59f, 0, 0},
                new float[] {.11f, .11f, .11f, 0, 0},
                new float[] {0, 0, 0, 1, 0},
                new float[] {0, 0, 0, 0, 1}
                });

            ImageAttributes attributes = new ImageAttributes();
            attributes.SetColorMatrix(colorMatrix);

            Graphics graphics = Graphics.FromImage(result);
            graphics.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height), 0, 0, original.Width, original.Height, GraphicsUnit.Pixel, attributes);
            graphics.Dispose();

            return result;
        }
        public static Bitmap CreateLightedImage(Bitmap original, int value)
        {
            Bitmap result = new Bitmap(original);
            for (int y = 0; (y <= (result.Height - 1)); y++)
            {
                for (int x = 0; (x <= (result.Width - 1)); x++)
                {
                    Color current = result.GetPixel(x, y);
                    current = Color.FromArgb(255, (Math.Min(255, current.R + value)), (Math.Min(255, current.G + value)), (Math.Min(255, current.B + value)));
                    result.SetPixel(x, y, current);
                }
            }
            return result;
        }
        public static Bitmap CreateInvertedImage(Bitmap original)
        {
            Bitmap result = new Bitmap(original);
            for (int y = 0; (y <= (result.Height - 1)); y++)
            {
                for (int x = 0; (x <= (result.Width - 1)); x++)
                {
                    Color inv = result.GetPixel(x, y);
                    inv = Color.FromArgb(255, (255 - inv.R), (255 - inv.G), (255 - inv.B));
                    result.SetPixel(x, y, inv);
                }
            }
            return result;
        }
        public static Color GetAverageColor(Bitmap bmp)
        {

            //Used for tally
            int r = 0;
            int g = 0;
            int b = 0;

            int total = 0;

            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color clr = bmp.GetPixel(x, y);

                    r += clr.R;
                    g += clr.G;
                    b += clr.B;

                    total++;
                }
            }

            //Calculate average
            r /= total;
            g /= total;
            b /= total;

            return Color.FromArgb(r, g, b);
        }
    }
}
