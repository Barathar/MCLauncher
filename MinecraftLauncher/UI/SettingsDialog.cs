﻿using MCLauncher.Data;
using MCLauncher.Fonts;
using System.Drawing;
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

            set
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
            set
            {
                ramNumericUpDown.Value = value;
            }
        }
        public bool Debug
        {
            get
            {
                return debugCheckBox.Checked;
            }
            set
            {
                debugCheckBox.Checked = value;
            }
        }
        public bool DebugVerbose
        {
            get
            {
                return verboseCheckBox.Checked;
            }
            set
            {
                verboseCheckBox.Checked = value;
            }
        }
        public int VerboseLevel
        {
            get
            {
                return (int)verboseLevelNumericUpDown.Value;
            }
            set
            {
                verboseLevelNumericUpDown.Value = value;
            }
        }

        public SettingsDialog(Style style)
        {
            InitializeComponent();

            BackColor = style.DialogBackgroundColor;

            saveButton.Font = new Font(FontLoader.MinecraftFont.Families[0], saveButton.Font.Size);
            cancelButton.Font = new Font(FontLoader.MinecraftFont.Families[0], cancelButton.Font.Size);

            label1.Font = new Font(FontLoader.MinecraftFont.Families[0], label1.Font.Size);
            label1.BackColor = style.DialogBackgroundColor;
            label1.ForeColor = style.DialogFontColor;

            label2.Font = new Font(FontLoader.MinecraftFont.Families[0], label2.Font.Size);
            label2.BackColor = style.DialogBackgroundColor;
            label2.ForeColor = style.DialogFontColor;

            label3.Font = new Font(FontLoader.MinecraftFont.Families[0], label3.Font.Size);
            label3.BackColor = style.DialogBackgroundColor;
            label3.ForeColor = style.DialogFontColor;

            label4.Font = new Font(FontLoader.MinecraftFont.Families[0], label4.Font.Size);
            label4.BackColor = style.DialogBackgroundColor;
            label4.ForeColor = style.DialogFontColor;

            label5.Font = new Font(FontLoader.MinecraftFont.Families[0], label5.Font.Size);
            label5.BackColor = style.DialogBackgroundColor;
            label5.ForeColor = style.DialogFontColor;

            label6.Font = new Font(FontLoader.MinecraftFont.Families[0], label6.Font.Size);
            label6.BackColor = style.DialogBackgroundColor;
            label6.ForeColor = style.DialogFontColor;

            serverIpTextBox.Font = new Font(FontLoader.MinecraftFont.Families[0], serverIpTextBox.Font.Size);
            serverIpTextBox.BackColor = style.DialogBackgroundColor;
            serverIpTextBox.ForeColor = style.DialogFontColor;

            resolutionComboBox.Font = new Font(FontLoader.MinecraftFont.Families[0], resolutionComboBox.Font.Size);
            resolutionComboBox.BackColor = style.DialogBackgroundColor;
            resolutionComboBox.ForeColor = style.DialogFontColor;

            ramNumericUpDown.Font = new Font(FontLoader.MinecraftFont.Families[0], ramNumericUpDown.Font.Size);
            ramNumericUpDown.BackColor = style.DialogBackgroundColor;
            ramNumericUpDown.ForeColor = style.DialogFontColor;

            debugCheckBox.BackColor = style.DialogBackgroundColor;
            debugCheckBox.ForeColor = style.DialogFontColor;

            verboseCheckBox.BackColor = style.DialogBackgroundColor;
            verboseCheckBox.ForeColor = style.DialogFontColor;

            verboseLevelNumericUpDown.Font = new Font(FontLoader.MinecraftFont.Families[0], verboseLevelNumericUpDown.Font.Size);
            verboseLevelNumericUpDown.BackColor = style.DialogBackgroundColor;
            verboseLevelNumericUpDown.ForeColor = style.DialogFontColor;

            resolutionComboBox.Items.Add(new Size(800, 600));
            resolutionComboBox.Items.Add(new Size(1280, 1024));
            resolutionComboBox.Items.Add(new Size(1600, 900));
            resolutionComboBox.Items.Add(new Size(1920, 1080));
        }

        private void OnLoad(object sender, System.EventArgs e)
        {
            UpdateDebugControls();
        }
        private void OnDebugCheckedChanged(object sender, System.EventArgs e)
        {
            UpdateDebugControls();
        }

        private void UpdateDebugControls()
        {
            label5.Enabled = debugCheckBox.Checked;
            label6.Enabled = debugCheckBox.Checked;
            verboseCheckBox.Enabled = debugCheckBox.Checked;
            verboseLevelNumericUpDown.Enabled = debugCheckBox.Checked;

            if (!debugCheckBox.Checked)
            {
                verboseCheckBox.Checked = false;
            }
        }
    }
}
