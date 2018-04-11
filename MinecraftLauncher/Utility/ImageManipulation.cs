using System.Drawing;
using System.Drawing.Imaging;

namespace MCLauncher.Utility
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
    }
}
