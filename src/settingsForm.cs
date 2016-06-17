using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Generalized_Backup_Tool.src
{
    public partial class SettingsForm : Form
    {
        Defaults defaults;
        public SettingsForm()
        {
            InitializeComponent();
            defaults = new Defaults();
            this.saveSlotsTextBox.Text = defaults.getNumSaves().ToString();
            this.saveIntervalTextBox.Text = defaults.getSaveInterval().ToString();
            this.backupFolderTextBox.Text = defaults.getBackupPath();
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();

            if (result == DialogResult.OK)
            {
                this.backupFolderTextBox.Text = fbd.SelectedPath;
            }
        }

        private bool validateSettings()
        {
            try {
                if (int.Parse(this.saveSlotsTextBox.Text) > 50 || int.Parse(this.saveSlotsTextBox.Text) < 1)
                {
                    this.saveSlotsTextBox.BackColor = Color.Red;
                    return false;
                }
            }
            catch(Exception e)
            {
                this.saveSlotsTextBox.BackColor = Color.Red;
                return false;
            }

            try
            {
                if (int.Parse(this.saveIntervalTextBox.Text) < 1)
                {
                    this.saveIntervalTextBox.BackColor = Color.Red;
                    return false;
                }
            }
            catch (Exception e)
            {
                this.saveIntervalTextBox.BackColor = Color.Red;
                return false;
            }
            return true;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (validateSettings())
            {
                defaults.setNumSaves(int.Parse(this.saveSlotsTextBox.Text));
                defaults.setBackupInterval(int.Parse(this.saveIntervalTextBox.Text));
                defaults.setBackupPath(this.backupFolderTextBox.Text);
                this.Close();
            }
        }
    }
}
