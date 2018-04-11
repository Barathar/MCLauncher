using MCLauncher.Utility;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MCLauncher.UI
{
    public partial class PatchNotes : Form
    {
        public PatchNotes(Uri uri)
        {
            InitializeComponent();

            button1.Font = new Font(FontLoader.MinecraftFont.Families[0], button1.Font.Size);
            textBox1.Font = new Font(FontLoader.MinecraftFont.Families[0], textBox1.Font.Size);
            textBox1.Text = Downloader.DownloadText(uri);
        }
    }
}
