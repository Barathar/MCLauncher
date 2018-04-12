using MCLauncher.Utility;
using System.Drawing;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace MCLauncher.Configuration
{
    public class Settings
    {
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
        public bool DebugVerbose { get; set; } = true;
        public int VerboseLevel { get; set; } = 1;

        public void Load()
        {
            if (!File.Exists(Paths.SettingsFile))
                return;

            XmlSerializer serializer = new XmlSerializer(typeof(Settings));

            FileStream stream = new FileStream(Paths.SettingsFile, FileMode.Open);
            XmlReader reader = XmlReader.Create(stream);
            instance = (Settings)serializer.Deserialize(reader);

            reader.Close();
            stream.Close();

            OutputConsole.Print(instance);
            OutputConsole.Print("[Settings loaded]");
        }
        public void Save()
        {
            if (instance == null)
                return;

            XmlSerializer serializer = new XmlSerializer(typeof(Settings));

            FileStream stream = new FileStream(Paths.SettingsFile, FileMode.Create);
            XmlWriter writer = new XmlTextWriter(stream, Encoding.Unicode);
            serializer.Serialize(writer, instance);
            writer.Close();
            stream.Close();

            OutputConsole.Print(instance);
            OutputConsole.Print("[Settings saved]");
        }
    }
}
