using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Generalized_Backup_Tool
{
    public partial class AddGame : Form
    {
        List<string> files = new List<string>();
        public AddGame()
        {
            InitializeComponent();
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            // Open a FolderBrowserDialog to get to the game's save path.
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();

            if(result == DialogResult.OK)
            {
                this.savePathTextBox.Text = fbd.SelectedPath;
            }
        }

        private void registerGameButton_Click(object sender, EventArgs e)
        {
            // Initialize variables:
            string name, proName, path = "";
            List<string> files;

            // Get the easy ones first:
            name = this.GameNameTextBox.Text;
            proName = this.processNameTextBox.Text;
            path = this.savePathTextBox.Text;

            // And now for the files:
            string unsortedNames = this.saveFilesTextBox.Text;
            // List SHOULD be comma-seperated.
            string[] fileArray = unsortedNames.Split(',');
            files = new List<string>(fileArray);
            
            // Create the game, and add it to the list.
            Game newGame = new Game(name, path, proName, files, 0);
            Program.gameList.Add(newGame);

            Program.writeGameList();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
