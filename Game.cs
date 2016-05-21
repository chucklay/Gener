using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generalized_Backup_Tool
{
    [Serializable]
    class Game
    {
        public string gameName;             // The game's displayed name.
        public string savePath;             // Game's save path (or relative path within steam dir)
        public string processName;          // Process name, to detect if the game is running.
        public List<string> fileNames;      // List of save file names. Enables backups of multiple save files.

        public Game(string name, string path, string proName, List<string> sNames)
        {
            gameName = name;
            savePath = path;
            processName = proName;
            fileNames = sNames;
        }
    }
}
