using MCLauncher.Configuration;
using MCLauncher.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace MCLauncher.Utility
{
    public class SkipPropertyAttribute : Attribute
    {
    }


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
            if (!textBox.Visible || !textBox.Enabled)
                return;

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
            if (VerboseAvailable(level))
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
            if (VerboseAvailable(level))
            {
                Print(type);
            }
        }
        public static void Print(Type type)
        {
            Console.WriteLine($"[{type.Name}]");

            foreach (var prop in GetValidProperties(type))
            {
                Console.WriteLine("{0}: {1}", prop.Name, prop.GetValue(type, null));
            }
        }
        public static void PrintVerbose(object obj, int level)
        {
            if (VerboseAvailable(level))
            {
                Print(obj);
            }
        }
        public static void Print(object obj)
        {
            Type type = obj.GetType();
            Console.WriteLine($"[{type.Name}]");

            foreach (var prop in GetValidProperties(type))
            {
                Console.WriteLine("{0}: {1}", prop.Name, prop.GetValue(obj, null));
            }
        }
        public static void PrintVerbose(Exception e, int level)
        {
            PrintVerbose(e, string.Empty, level);
        }
        public static void PrintVerbose(Exception e, string message, int level)
        {
            if (VerboseAvailable(level))
            {
                OutputConsole.Print("################### EXCEPTION ##############");
                if (message != null)
                {
                    OutputConsole.Print(message);
                }
                OutputConsole.Print(e);
                OutputConsole.Print("############################################");
            }
        }

        private static PropertyInfo[] GetValidProperties(Type type)
        {
            return type.GetProperties().Where(pi => pi.GetCustomAttributes(typeof(SkipPropertyAttribute), true).Length == 0).ToArray();
        }
        private static bool VerboseAvailable(int level)
        {
            return Settings.Default.DebugVerbose && level <= Settings.Default.VerboseLevel;
        }
    }
}
