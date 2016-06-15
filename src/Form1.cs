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
    public partial class Form1 : Form
    {
        ImageList imgList = new ImageList();
        public Form1()
        {
            InitializeComponent();
            refreshGamesList();
        }

        private void GameList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //TODO Change the game details here.
            ListView.SelectedIndexCollection items = this.GameList.SelectedIndices;
            foreach(int idex in items)
            {
                setMainPannel(Program.gameList.ElementAt(idex));
            }
        }

        private void addGameButton_Click(object sender, EventArgs e)
        {
            AddGame add = new AddGame();
            add.Show();
        }

        private void setMainPannel(Game game)
        {
            System.Console.WriteLine("Selected game: " + game.gameName);

            string fileNames = "";
            if (game.fileNames != null)
            {
                fileNames = game.fileNames.ElementAt(0);
                for(int i = 1; i < game.fileNames.Count; i++)
                {
                    fileNames = fileNames + ", " + game.fileNames.ElementAt(i);
                }
            }

            this.GameLabel.Text = game.gameName;
            this.gameNameTextBox.Text = game.gameName;
            this.savePathTextBox.Text = game.savePath;
            this.saveFilesTextBox.Text = fileNames;
            this.processNameTextBox.Text = game.processName;

            this.GameLabel.Visible = true;
            this.gameNameChangeLabel.Visible = true;
            this.gameNameTextBox.Visible = true;
            this.savePathLabel.Visible = true;
            this.savePathTextBox.Visible = true;
            this.pathBrowseButton.Visible = true;
            this.saveFilesLabel.Visible = true;
            this.saveFilesTextBox.Visible = true;
            this.processNameLabel.Visible = true;
            this.processNameTextBox.Visible = true;
            this.saveChangesButton.Enabled = true;
        }

        private void refreshGamesList()
        {
            for (int i = 0; i < Program.gameList.Count; i++)
            {
                // TODO Allow the user to set an image for each game.
                // Right now, this is just a placeholder image.
                imgList.Images.Add(Image.FromStream(System.Reflection.Assembly.GetExecutingAssembly()
                    .GetManifestResourceStream("Generalized_Backup_Tool.res.questionmark.png")));
            }

            imgList.ImageSize = new Size(50, 50);

            this.GameList.LargeImageList = imgList;
            this.GameList.SmallImageList = imgList;

            GameList.Items.Clear();

            for (int i = 0; i < Program.gameList.Count; i++)
            {
                this.GameList.Items.Add(new ListViewItem { ImageIndex = i, Text = 
                    Program.gameList.ElementAt(i).gameName });
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (validateInput())
            {
                saveChanges();
                Program.writeGameList();
                MessageBox.Show("Game updated!", "Success!", MessageBoxButtons.OK);
            }
        }

        private void saveChanges()
        {
            ListView.SelectedIndexCollection items = this.GameList.SelectedIndices;
            int gameIndex = 0;
            foreach (int i in items)
            {
                gameIndex = i;
            }
            Program.gameList.ElementAt(gameIndex).gameName = this.gameNameTextBox.Text;
            Program.gameList.ElementAt(gameIndex).savePath = this.savePathTextBox.Text;
            if (this.saveFilesTextBox.Text.Equals(""))
            {
                Program.gameList.ElementAt(gameIndex).fileNames = null;
            }
            else
            {
                string fullList = this.saveFilesTextBox.Text;
                string[] split = fullList.Split(',');
                for(int i = 0; i < split.Length; i++)
                {
                    split[i].Trim();
                }
                Program.gameList.ElementAt(gameIndex).fileNames = new List<string>(split);
            }
            Program.gameList.ElementAt(gameIndex).processName = this.processNameTextBox.Text;
        }

        private bool validateInput()
        {
            // First, check game name for any invalid characters:
            string name = this.gameNameTextBox.Text;
            foreach(char invalChar in System.IO.Path.GetInvalidPathChars())
            {
                if (name.Contains(invalChar))
                {
                    // Name contains an invalid character!
                    this.gameNameTextBox.Text = "Game name cannot be used as directory!";
                    this.gameNameTextBox.BackColor = Color.Red;
                    return false;
                }
            }
            // Check Make sure all files are actually in the directory.
            string fileString = this.saveFilesTextBox.Text;
            // The user may want to back up all files in the directory.
            System.Console.WriteLine("File text: \"" + this.saveFilesTextBox.Text + "\"");
            if (!fileString.Equals(""))
            {
                string[] files = fileString.Split(',');
                foreach(string fileName in files)
                {
                    //Make sure there are no invalid characters.
                    foreach(char invalChar in System.IO.Path.GetInvalidFileNameChars())
                    {
                        if (fileName.Contains(invalChar))
                        {
                            this.saveFilesTextBox.Text = "Files contain an invalid character!";
                            this.saveFilesTextBox.BackColor = Color.Red;
                            return false;
                        }
                    }
                    // Check to make sure each file exists.
                    if(!System.IO.File.Exists(System.IO.Path.Combine(this.savePathTextBox.Text, fileName)))
                    {
                        this.saveFilesTextBox.Text = "One or more files do not exist!";
                        this.saveFilesTextBox.BackColor = Color.Red;
                        return false;
                    }
                }
            }
            // Delete the ".exe" from the process name, if it exists.
            string pathName = this.processNameTextBox.Text;
            if (pathName.EndsWith(".exe"))
            {
                string[] pathNameSplit = pathName.Split('.');
                pathName = pathNameSplit[0];
                for(int i = 1; i < pathNameSplit.Length-1; i++)
                {
                    pathName = pathName + "." + pathNameSplit[i];
                }
                this.processNameTextBox.Text = pathName;
            }
            return true;
        }

        private void pathBrowseButton_Click(object sender, EventArgs e)
        {
            // Open a FolderBrowserDialog to get to the game's save path.
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();

            if (result == DialogResult.OK)
            {
                this.savePathTextBox.Text = fbd.SelectedPath;
            }
        }
    }
}
