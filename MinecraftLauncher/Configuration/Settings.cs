using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace MCLauncher.Configuration
{
    public class Settings
    {
        public readonly string settingsFile = Path.Combine(Paths.LauncherFilesDirectory, "settings.xml");
        private static Settings instance = null;            

        public static Settings Default
        {
            get
            {
                if (instance == null)
                    instance = new Settings();

                return instance;
            }
        }

        public string ServerIp { get; set; } = "http://www.wirock.de/mclauncher/versions.xml";
        public Size Resolution { get; set; } = new Size(800, 600);
        public int RAM { get; set; } = 4;
        public bool ShowDebugConsole { get; set; } = false;

        public void Load()
        {
            if (!File.Exists(settingsFile))
                return;

            XmlSerializer serializer = new XmlSerializer(typeof(Settings));

            FileStream stream = new FileStream(settingsFile, FileMode.Open);
            XmlReader reader = XmlReader.Create(stream);
            instance = (Settings)serializer.Deserialize(reader);            

            reader.Close();
            stream.Close();

            Console.WriteLine("Settings loaded.");
            Console.WriteLine($"{nameof(ServerIp)}: {instance.ServerIp}.");
            Console.WriteLine($"{nameof(Resolution)}: {instance.Resolution.Width} x {instance.Resolution.Height}.");
            Console.WriteLine($"{nameof(RAM)}: {instance.RAM}.");
        }
        public void Save()
        {
            if (instance == null)
                return;            

            XmlSerializer serializer = new XmlSerializer(typeof(Settings));

            FileStream stream = new FileStream(settingsFile, FileMode.Create);
            XmlWriter writer = new XmlTextWriter(stream, Encoding.Unicode);
            serializer.Serialize(writer, instance);
            writer.Close();
            stream.Close();

            Console.WriteLine("Settings saved.");
            Console.WriteLine($"{nameof(ServerIp)}: {instance.ServerIp}.");
            Console.WriteLine($"{nameof(Resolution)}: {instance.Resolution.Width} x {instance.Resolution.Height}.");
            Console.WriteLine($"{nameof(RAM)}: {instance.RAM}.");
        }
    }
}
