using MCLauncher.Data;
using MCLauncher.Fonts;
using MCLauncher.Utility;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MCLauncher.UI
{
    public partial class PatchNotes : Form
    {
        public PatchNotes(Style style, Uri uri)
        {
            InitializeComponent();

            BackColor = style.DialogBackgroundColor;

            button1.Font = new Font(FontLoader.MinecraftFont.Families[0], button1.Font.Size);

            textBox1.Font = new Font(FontLoader.MinecraftFont.Families[0], textBox1.Font.Size);
            textBox1.BackColor = style.DialogBackgroundColor;
            textBox1.ForeColor = style.DialogFontColor;
            textBox1.Text = Downloader.DownloadText(uri);
        }
    }
}
