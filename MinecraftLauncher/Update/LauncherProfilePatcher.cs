using MCLauncher.Configuration;
using MCLauncher.Data;
using MCLauncher.Utility;
using MCLauncher.Web;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace MCLauncher.Update
{
    public class LauncherProfilePatcher
    {
        private Uri defaultLauncherProfile = null;

        public LauncherProfilePatcher(Uri defaultLauncherProfile)
        {
            this.defaultLauncherProfile = defaultLauncherProfile;
        }

        public void Patch(string filename, LauncherProfileData data)
        {            
            if (!File.Exists(filename))
                Downloader.Download(defaultLauncherProfile, filename);

            UpdateLauncherProfile(filename, data);
        }

        private void UpdateLauncherProfile(string filename, LauncherProfileData data)
        {
            JObject json = ReadProfile(filename);

            UpdateProfile(ref json, data);

            WriteProfile(json, filename);

            OutputConsole.Print($"[Updated] {filename}.");
        }
        private JObject ReadProfile(string filename)
        {
            string content = File.ReadAllText(filename);
            return JObject.Parse(content);
        }
        private void WriteProfile(JObject json, string filename)
        {
            File.WriteAllText(filename, json.ToString());
        }
        private void UpdateProfile(ref JObject json, LauncherProfileData data)
        {
            json["profiles"] = new JObject(CreateForgeProfile(data));
        }
        private JProperty CreateForgeProfile(LauncherProfileData data)
        {
            return new JProperty("forge", new JObject(
                CreateName(data),
                CreateType(data),
                CreateCreated(data),
                CreateLastUsed(data),
                CreateIcon(data),
                CreateLastVersionId(data),
                CreateGameDirectory(data),
                CreateResolution(),
                CreateJavaArgs(data)
                ));
        }
        private JProperty CreateName(LauncherProfileData data)
        {
            return new JProperty("name", data.Name);
        }
        private JProperty CreateType(LauncherProfileData data)
        {
            return new JProperty("type", data.Type);
        }
        private JProperty CreateCreated(LauncherProfileData data)
        {
            return new JProperty("created", data.Created);
        }
        private JProperty CreateLastUsed(LauncherProfileData data)
        {
            return new JProperty("lastUsed", data.LastUsed);
        }
        private JProperty CreateIcon(LauncherProfileData data)
        {
            return new JProperty("icon", data.Icon);
        }
        private JProperty CreateLastVersionId(LauncherProfileData data)
        {
            return new JProperty("lastVersionId", data.LastVersionId);
        }
        private JProperty CreateGameDirectory(LauncherProfileData data)
        {
            return new JProperty("gameDir", Path.Combine(Paths.CurrentDirectory, data.GameDirectory));
        }
        private JProperty CreateResolution()
        {
            return new JProperty("resolution", new JObject(
                new JProperty("width", Settings.Default.Resolution.Width),
                new JProperty("height", Settings.Default.Resolution.Height)
                ));
        }
        private JProperty CreateJavaArgs(LauncherProfileData data)
        {
            Regex rgx = new Regex("-Xmx\\d+G");
            return new JProperty("javaArgs", rgx.Replace(data.JavaArgs, $"-Xmx{Settings.Default.RAM}G"));
        }
    }
}
