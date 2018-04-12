using MCLauncher.Configuration;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace MCLauncher.Utility
{
    public class OutputConsole : TextWriter
    {        
        Form form = null;
        TextBox textBox = null;

        public OutputConsole(Form form, TextBox output)
        {
            this.form = form;
            textBox = output;
        }

        public override void Write(char value)
        {
            base.Write(value);
            if (form.InvokeRequired)
            {
                form.Invoke(new Action<string>(Write), new object[] { value.ToString() });
                return;
            }
            textBox.AppendText(value.ToString());
        }
        public override Encoding Encoding
        {
            get { return System.Text.Encoding.UTF8; }
        }

        public static void PrintVerbose(string message, int level)
        {
            if (Settings.Default.DebugVerbose && level <= Settings.Default.VerboseLevel)
            {
                Print(message);
            }
        }
        public static void Print(string message)
        {
            Console.WriteLine(message);
        }
        public static void PrintVerbose(Type type, int level)
        {
            if (Settings.Default.DebugVerbose && level <= Settings.Default.VerboseLevel)
            {
                Print(type);
            }
        }
        public static void Print(Type type)
        {
            Console.WriteLine($"[{type.Name}]");

            foreach (var prop in type.GetProperties())
            {
                Console.WriteLine("{0}: {1}", prop.Name, prop.GetValue(type, null));
            }
        }
        public static void PrintVerbose(object obj, int level)
        {
            if (Settings.Default.DebugVerbose && level <= Settings.Default.VerboseLevel)
            {
                Print(obj);
            }
        }
        public static void Print(object obj)
        {
            Type type = obj.GetType();
            Console.WriteLine($"[{type.Name}]");

            foreach (var prop in type.GetProperties())
            {
                Console.WriteLine("{0}: {1}", prop.Name, prop.GetValue(obj, null));
            }
        }
    }
}
