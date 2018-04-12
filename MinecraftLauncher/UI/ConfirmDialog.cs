using MCLauncher.Data;
using MCLauncher.Fonts;
using System.Drawing;
using System.Windows.Forms;

namespace MCLauncher.UI
{
    public partial class ConfirmDialog : Form
    {
        public ConfirmDialog(Style style, string displayText)
        {
            InitializeComponent();

            BackColor = style.DialogBackgroundColor;

            button1.Font = new Font(FontLoader.MinecraftFont.Families[0], button1.Font.Size);
            button2.Font = new Font(FontLoader.MinecraftFont.Families[0], button2.Font.Size);

            textLabel.Font = new Font(FontLoader.MinecraftFont.Families[0], textLabel.Font.Size);
            textLabel.BackColor = style.DialogBackgroundColor;
            textLabel.ForeColor = style.DialogFontColor;
            textLabel.Text = displayText;
        }
    }
}
