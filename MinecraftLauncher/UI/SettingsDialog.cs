using MCLauncher.Configuration;
using MCLauncher.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCLauncher.UI
{
    public partial class SettingsDialog : Form
    {
        public string ServerIp
        {
            get
            {
                return serverIpTextBox.Text;
            }

            private set
            {
                serverIpTextBox.Text = value;
            }
        }
        public Size Resolution
        {
            get
            {
                return (Size)resolutionComboBox.SelectedItem;
            }
            set
            {
                resolutionComboBox.SelectedItem = value;
            }
        }
        public int RAM
        {
            get
            {
                return (int)ramNumericUpDown.Value;
            }
            private set
            {
                ramNumericUpDown.Value = value;
            }
        }

        public SettingsDialog(string serverIp, Size resolution, int ram)
        {
            InitializeComponent();

            saveButton.Font = new Font(FontLoader.MinecraftFont.Families[0], saveButton.Font.Size);
            cancelButton.Font = new Font(FontLoader.MinecraftFont.Families[0], cancelButton.Font.Size); 

            label1.Font = new Font(FontLoader.MinecraftFont.Families[0], label1.Font.Size);
            label2.Font = new Font(FontLoader.MinecraftFont.Families[0], label2.Font.Size);
            label3.Font = new Font(FontLoader.MinecraftFont.Families[0], label3.Font.Size);

            serverIpTextBox.Font = new Font(FontLoader.MinecraftFont.Families[0], serverIpTextBox.Font.Size);
            resolutionComboBox.Font = new Font(FontLoader.MinecraftFont.Families[0], resolutionComboBox.Font.Size);
            ramNumericUpDown.Font = new Font(FontLoader.MinecraftFont.Families[0], ramNumericUpDown.Font.Size);

            resolutionComboBox.Items.Add(new Size(800, 600));
            resolutionComboBox.Items.Add(new Size(1280, 1024));

            ServerIp = serverIp;
            Resolution = resolution;
            RAM = ram;
        }
    }
}
