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
        }

        private void addGameButton_Click(object sender, EventArgs e)
        {
            AddGame add = new AddGame();
            add.Show();
        }

        private void refreshGamesList()
        {
            for (int i = 0; i < Program.gameList.Count; i++)
            {
                // TODO Allow the user to set an image for each game.
                // Right now, this is just a placeholder image.
                imgList.Images.Add(Image.FromStream(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("Generalized_Backup_Tool.questionmark.png")));
            }

            this.GameList.LargeImageList = imgList;
            this.GameList.SmallImageList = imgList;

            GameList.Items.Clear();

            for (int i = 0; i < Program.gameList.Count; i++)
            {
                this.GameList.Items.Add(new ListViewItem { ImageIndex = i, Text = Program.gameList.ElementAt(i).gameName });
            }
        }
    }
}
