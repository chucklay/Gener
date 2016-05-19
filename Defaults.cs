using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generalized_Backup_Tool
{
    class Defaults
    {

        private string steamPath;
        private string backupPath;
        private int numSaves;
        private int saveInterval;

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

        public void setSteamPath(string newPath)
        {
            steamPath = newPath;
            Properties.Settings.Default.SteamPath = steamPath;
            Properties.Settings.Default.Save();
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
