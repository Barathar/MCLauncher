using MCLauncher.Web;
using System;
using System.Collections.Generic;
using System.IO;

namespace MCLauncher.Update
{
    public class OptionsPatcher
    {
        private Uri defaultOptions = null;

        public OptionsPatcher(Uri defaultOptions)
        {
            this.defaultOptions = defaultOptions;
        }

        public void Patch(string filename, Dictionary<string, string> options)
        {
            if (!File.Exists(filename))
                Downloader.Download(defaultOptions, filename);

            Dictionary<string, string> optionsOnDisc = ReadOptions(filename);
            UpdateResourcepacks(ref optionsOnDisc, options);
            WriteOptions(options, filename);
        }

        private void UpdateResourcepacks(ref Dictionary<string, string> optionsOnDisc, Dictionary<string, string> options)
        {
            foreach (var key in options.Keys)
            {
                optionsOnDisc[$"{key}"] = options[key];
            }
        }
        private Dictionary<string, string> ReadOptions(string filename)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            foreach (var line in File.ReadAllLines(filename))
            {
                string[] keyValuePair = line.Split(':');

                result.Add(keyValuePair[0], keyValuePair[1]);
            }

            return result;
        }
        private void WriteOptions(Dictionary<string, string> options, string filename)
        {
            List<string> lines = new List<string>();
            foreach (var key in options.Keys)
            {
                lines.Add($"{key}:{options[key]}");
            }

            File.WriteAllLines(filename, lines);
        }
    }
}
