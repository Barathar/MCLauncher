using System;
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
    }
}
