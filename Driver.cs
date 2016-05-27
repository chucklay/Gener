using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generalized_Backup_Tool
{
    class Driver
    {

        static List<Game> games;
        static Defaults defaults;

        static void Main()
        {

            // Load defaults.
            defaults = new Defaults();

            // Load list of games.
            if (System.IO.File.Exists(@"Games.bin"))
            {
                using (System.IO.Stream stream = System.IO.File.Open("games.bin", System.IO.FileMode.Open))
                {
                    var bFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    games = (List<Game>)bFormatter.Deserialize(stream);
                }
            }

            //Kick off a new thread to start backing up games.
            System.Threading.Thread backupThread = new System.Threading.Thread(new System.Threading.ThreadStart(backUpGames));
            backupThread.Start();

            // Main program loop:

            while (true)
            {
                System.Console.Clear();
                System.Console.Write("Select an option: \n");
                System.Console.Write("1) Add a game\n");
                System.Console.Write("2) View or edit games \n");
                System.Console.Write("3) Edit settings \n");
                System.Console.Write("4) Exit\n");
                
                int input = int.Parse(System.Console.ReadLine());


                switch (input)
                {
                    case 1:
                        addGame();
                        break;
                    case 2:
                        displayGames();
                        break;
                    case 3:
                        showSettings();
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                    default:
                        System.Console.Write("Unrecognized entry\n\n");
                        break;
                }
            }
        }

        /**
         * Back up games in a background thread.
         */
        public static void backUpGames()
        {
            string cName = System.Environment.MachineName;
            System.Diagnostics.Process[] processList;
            bool found = false;
            int i;
            int currentSlot;
            List<string> pNameList = new List<string>();

            while (true)
            {
                processList = System.Diagnostics.Process.GetProcesses(cName);

                // Get the names of all running processes.
                for (i = 0; i < processList.Count(); i++)
                {
                    pNameList.Add(processList.ElementAt(i).ProcessName);
                }

                for (i = 0; i < games.Count; i++)
                {
                    if (pNameList.Contains(games.ElementAt(i).processName))
                    {
                        found = true;
                        break;
                    }
                }
                if (found)
                {
                    //Game at [i] is running!
                    currentSlot = games.ElementAt(i).currentSlot;
                    string backupPath = defaults.getBackupPath() + "\\" + games.ElementAt(i).gameName + "\\" + currentSlot;
                    List<string> bFiles = games.ElementAt(i).fileNames;
                    string currentFileName = bFiles + "_" + currentSlot;

                    for (int k = 0; k < bFiles.Count; k++)
                    {
                        //Back up each file.
                        string sPath = System.IO.Path.Combine(games.ElementAt(i).savePath, bFiles.ElementAt(k));
                        string dPath = System.IO.Path.Combine(backupPath, bFiles.ElementAt(k));

                        if (!System.IO.Directory.Exists(backupPath))
                        {
                            // Create the directory.
                            System.IO.Directory.CreateDirectory(backupPath);
                        }

                        // Copy the files.
                        System.IO.File.Copy(sPath, dPath, true);
                    }

                    System.Console.WriteLine("Save files backed up to slot " + currentSlot);

                    currentSlot++;
                    games.ElementAt(i).currentSlot = currentSlot;
                    using (System.IO.Stream stream = System.IO.File.Open("games.bin", System.IO.FileMode.Create))
                    {
                        System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bin = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                        bin.Serialize(stream, games);
                    }
                    System.Threading.Thread.Sleep(new TimeSpan(0, defaults.getSaveInterval(), 0));
                    continue;
                }
                else
                {
                    System.Console.WriteLine("No running games detected. Retrying in 3 minutes.");
                    System.Threading.Thread.Sleep(new TimeSpan(0, 3, 0));
                }
            }

            return;
        }

        /**
         * Show settings, and allow the user to edit them.
         */
        public static void showSettings()
        {
            int selection = -1;
            while (selection != 5)
            {
                System.Console.Clear();
                System.Console.WriteLine("Current settings:");
                System.Console.WriteLine("1) Steam path: " + defaults.getSteamPath());
                System.Console.WriteLine("2) Backup path: " + defaults.getBackupPath());
                System.Console.WriteLine("3) Number of saves: " + defaults.getNumSaves());
                System.Console.WriteLine("4) Save interval: " + defaults.getSaveInterval() + " minutes");
                System.Console.WriteLine("5) Main menu");
                System.Console.Write("Select a setting to change:\n>");
                selection = int.Parse(System.Console.ReadLine());

                switch (selection)
                {
                    case 1:
                        System.Console.Write("Enter a new steam path:\n>");
                        defaults.setSteamPath(System.Console.ReadLine());
                        break;
                    case 2:
                        System.Console.Write("Enter a new backup path:\n>");
                        defaults.setBackupPath(System.Console.ReadLine());
                        break;
                    case 3:
                        System.Console.Write("How many save slots would you like\n>");
                        defaults.setNumSaves(int.Parse(System.Console.ReadLine()));
                        break;
                    case 4:
                        System.Console.Write("How many minutes between saves\n>");
                        defaults.setBackupInterval(int.Parse(System.Console.ReadLine()));
                        break;
                    case 5:
                        break;
                    default:
                        System.Console.WriteLine("Entry not recognized.");
                        break;
                }
            }
        }

        /**
         * Display all game objects, and allow a user to edit the information.
         */
        public static void displayGames()
        {
            System.Console.Clear();
            System.Console.WriteLine("Which game would you like to view or edit:");
            for(int i = 0; i < games.Count(); i++)
            {
                System.Console.WriteLine((i + 1) + ") " + games.ElementAt(i).gameName);
            }

            // Select game.
            int selection = int.Parse(System.Console.ReadLine()) - 1;
            Game selectedGame = games.ElementAt(selection);

            int selection2 = -1;

            while (selection2 != 5)
            {
                //Display options to user.
                System.Console.Clear();
                System.Console.WriteLine("What would you like to edit:");
                System.Console.WriteLine("1) Game name: \t\t" + selectedGame.gameName);
                System.Console.WriteLine("2) Save path: \t\t" + selectedGame.savePath);
                System.Console.WriteLine("3) Process name:\t" + selectedGame.processName);
                System.Console.WriteLine("4) Savefile names:\t");

                List<string> saveFiles = selectedGame.fileNames;

                for (int i = 0; i < saveFiles.Count(); i++)
                {
                    System.Console.WriteLine("\t" + saveFiles.ElementAt(i));
                }

                System.Console.WriteLine("5) Main menu (finalize changes)");

                selection2 = int.Parse(System.Console.ReadLine());

                switch (selection2)
                {
                    case 1:
                        //Change the game's display name.
                        System.Console.WriteLine("Enter the new name for the game:");
                        string newName = System.Console.ReadLine();
                        selectedGame.gameName = newName;
                        games[selection] = selectedGame;
                        break;
                    case 2:
                        //Change the game's savefile directory.
                        System.Console.WriteLine("Enter the new save path:");
                        string newPath = System.Console.ReadLine();
                        selectedGame.savePath = newPath;
                        games[selection] = selectedGame;
                        break;
                    case 3:
                        //Change the game's process name.
                        System.Console.WriteLine("Enter the name of the game's process:");
                        string newProc = @System.Console.ReadLine();
                        selectedGame.processName = newProc;
                        games[selection] = selectedGame;
                        break;
                    case 4:
                        //Get list of files to back up.
                        System.Console.WriteLine("Enter the savefile names to backup (-1 to exit):");
                        string entry = "";
                        List<string> fileList = new List<string>();
                        while (true)
                        {
                            entry = System.Console.ReadLine();
                            if (entry.CompareTo("-1") == 0)
                            {
                                break;
                            }
                            fileList.Add(entry);
                        }
                        selectedGame.fileNames = fileList;
                        games[selection] = selectedGame;
                        break;
                    case 5:
                        //Save changes to disk and exit.
                        using (System.IO.Stream stream = System.IO.File.Open("games.bin", System.IO.FileMode.Create))
                        {
                            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bin = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                            bin.Serialize(stream, games);
                        }
                        break;
                    default:
                        System.Console.WriteLine("Entry not recognized.");
                        break;
                }
            }
        }
        /**
         * Adds a game to the game list, and writes it out to file. 
         */
        public static void addGame()
        {

            // Get all of the required information.

            System.Console.Clear();

            bool validName = false;
            string dispName = "";
            while (!validName)
            {
                System.Console.Write("Enter the display name of the game:\n>");
                dispName = System.Console.ReadLine();
                if (dispName.Any(System.IO.Path.GetInvalidPathChars().Contains)){
                    // The game name contains characters that cannot be used
                    // in a directory path. Game names are automatically used
                    // as the name of the folder where backups are stored.
                    System.Console.WriteLine("Error: Game name contains invalid directory characters.");
                }
                else
                {
                    validName = true;
                }
            }

            bool validPath = false;
            string gamePath = "";
            while (!validPath)
            {
                System.Console.Write("Enter the path to the game's save directory:\n>");
                gamePath = System.Console.ReadLine();
                validPath = System.IO.Directory.Exists(gamePath);
                if (!validPath)
                {
                    // Once GUI has been implemented, this error should not
                    // be encountered.
                    System.Console.WriteLine("Error: this path does not exist.");
                }
            }

            System.Console.Write("Enter the name of the game's process:\n>");
            string processName = System.Console.ReadLine();

            System.Console.Write("Enter the names of the save files to back up (-1 to finish):\n>");
            List<string> fileNames = new List<string>();
            while (true)
            {
                string input = System.Console.ReadLine();
                if(input.CompareTo("-1") == 0)
                {
                    break;
                }
                else
                {
                    fileNames.Add(input);
                    System.Console.Write("File added\n");
                }
            }

            if(games == null)
            {
                games = new List<Game>();
            }

            // Create the game object, and add it to the list.
            games.Add(new Game(dispName, gamePath, processName, fileNames, 0));

            // Serialize and save.
            using (System.IO.Stream stream = System.IO.File.Open("games.bin", System.IO.FileMode.Create))
            {
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bin = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                bin.Serialize(stream, games);
            }

            System.Console.Write("Game added.\n");
            
            return;
        }
    }
}
