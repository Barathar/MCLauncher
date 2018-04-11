using MCLauncher.Utility;
using System.Drawing;
using System.Windows.Forms;

namespace MCLauncher.UI
{
    public partial class ConfirmDialog : Form
    {
        public string DisplayText
        {
            get { return textLabel.Text; }
            set { textLabel.Text = value; }
        }

        public ConfirmDialog()
        {
            InitializeComponent();
            button1.Font = new Font(FontLoader.MinecraftFont.Families[0], button1.Font.Size);
            button2.Font = new Font(FontLoader.MinecraftFont.Families[0], button2.Font.Size);
            textLabel.Font = new Font(FontLoader.MinecraftFont.Families[0], textLabel.Font.Size);
        }
    }
}
