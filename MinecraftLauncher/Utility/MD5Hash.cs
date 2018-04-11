using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Security.Cryptography;

namespace MCLauncher.Utility
{
    public class MD5Hash
    {
        public static string FromFile(string filename)
        {
            using (var md5 = MD5.Create())
            {
                byte[] data = File.ReadAllBytes(filename);
                byte[] hash = md5.ComputeHash(data);
                return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
            }
        }
        private static string FromImage(Image image)
        {
            byte[] bytes = null;
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, ImageFormat.Png);
                bytes = ms.ToArray();
            }

            using (var md5 = MD5.Create())
            {
                byte[] hash = md5.ComputeHash(bytes);
                return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
            }
        }
        public static bool IsEqual(Image left, Image right)
        {
            if (left == null || right == null)
                return false;

            string leftHash = FromImage(left);
            string rightHash = FromImage(right);

            return leftHash == rightHash;
        }
    }
}
