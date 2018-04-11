using System;
using System.Drawing;
using System.IO;
using System.Net;

namespace MCLauncher.Utility
{
    public class Downloader
    {
        public static void Download(Uri uri, string target)
        {
            try
            {
                using (var client = new WebClient())
                {
                    string path = Path.GetDirectoryName(target);

                    if (!Directory.Exists(path))
                        Directory.CreateDirectory(path);

                    client.DownloadFile(uri, target);
                }
            }
            catch (WebException e)
            {
                Console.WriteLine($"Cannot download file '{uri}.'\n{e}");
            }
        }
        public static Image DownloadImage(Uri uri)
        {
            try
            {
                Image result = null;
                using (var client = new WebClient())
                {
                    Stream stream = client.OpenRead(uri);
                    result = new Bitmap(stream);
                    stream.Flush();
                    stream.Close();
                }
                return result;
            }
            catch (WebException e)
            {
                Console.WriteLine($"Cannot download file '{uri}.'\n{e}");
                return Properties.Resources.filenotfound;
            }

        }
        public static string DownloadText(Uri uri)
        {
            string result = string.Empty;
            using (var client = new WebClient())
            {
                try
                {
                    Stream stream = client.OpenRead(uri);
                    StreamReader reader = new StreamReader(stream);
                    result = reader.ReadToEnd();

                    reader.Close();
                    stream.Flush();
                    stream.Close();
                }
                catch (WebException e)
                {
                    Console.WriteLine($"Cannot download file '{uri}.'\n{e}");
                    return string.Empty;
                }
            }

            return result;
        }
    }
}
