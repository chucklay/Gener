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

        static void Main()
        {

            // Load defaults.
            Defaults defaults = new Defaults();

            // Load list of games.
            if (System.IO.File.Exists(@"Games.bin"))
            {
                using (System.IO.Stream stream = System.IO.File.Open("games.bin", System.IO.FileMode.Open))
                {
                    var bFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    games = (List<Game>)bFormatter.Deserialize(stream);
                }
            }

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
                        //showSettings();
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
            // TODO add sanity checking.

            System.Console.Clear();

            System.Console.Write("Enter the display name of the game:\n");
            string dispName = System.Console.ReadLine();

            System.Console.Write("Enter the path to the game's save directory:\n");
            string gamePath = System.Console.ReadLine();

            System.Console.Write("Enter the name of the game's process:\n");
            string processName = System.Console.ReadLine();

            System.Console.Write("Enter the names of the save files to back up (-1 to finish):\n");
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
            games.Add(new Game(dispName, gamePath, processName, fileNames));

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
