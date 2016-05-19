using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Generalized_Backup_Tool
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Attempt to load configuration

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }

    class Defaults{
        private string gamePath = "";
        private string backupPath = "";
        private int numSaves = 10;
        private int minutesBetweenSaves = 10;

        public Defaults()
        {

        }

        public string getGamePath()
        {
            return gamePath;
        }
        public string getBackupPath()
        {
            return backupPath;
        }
        public int getNumSaves()
        {
            return numSaves;
        }
        public int getMinutesBetweenSaves()
        {
            return minutesBetweenSaves;
        }

        public void setGamePath(string newPath)
        {

        }

    }
}
