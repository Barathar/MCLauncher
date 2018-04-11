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
    }
}
