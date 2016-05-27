using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generalized_Backup_Tool
{
    class Defaults
    {

        private string steamPath;               // Path to steam folder, will be used later to auto-detect games.
        private string backupPath;              // Path to folder where backups will be stored. Will be created if it does not exist.
        private int numSaves;                   // Number of rotating save slots to use 
        private int saveInterval;               // Time between backups, in minutes.

        public Defaults()
        {
            steamPath = Properties.Settings.Default.SteamPath;
            backupPath = Properties.Settings.Default.BackupPath;
            numSaves = Properties.Settings.Default.NumSaves;
            saveInterval = Properties.Settings.Default.SaveInterval;
        }

        public string getSteamPath()
        {
            return steamPath;
        }

        public string getBackupPath()
        {
            return backupPath;
        }

        public int getNumSaves()
        {
            return numSaves;
        }

        public int getSaveInterval()
        {
            return saveInterval;
        }

        public bool setSteamPath(string newPath)
        {
            if (System.IO.Directory.Exists(newPath))
            {
                steamPath = newPath;
                Properties.Settings.Default.SteamPath = steamPath;
                Properties.Settings.Default.Save();
                return true;
            }
            else
            {
                return false;
            }
        }

        public void setBackupPath(string newPath)
        {
            backupPath = newPath;
            Properties.Settings.Default.BackupPath = backupPath;
            Properties.Settings.Default.Save();
        }

        public void setNumSaves(int newNum)
        {
            numSaves = newNum;
            Properties.Settings.Default.NumSaves = numSaves;
            Properties.Settings.Default.Save();
        }

        public void setBackupInterval(int newNum)
        {
            saveInterval = newNum;
            Properties.Settings.Default.SaveInterval = saveInterval;
            Properties.Settings.Default.Save();
        }

    }
}
