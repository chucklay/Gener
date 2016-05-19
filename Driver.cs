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
                        //displayGames();
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
         * Adds a game to the game list, and writes it out to file. 
         */
        public static void addGame()
        {
            System.Console.Write("Enter the display name of the game:\n");
            string dispName = System.Console.ReadLine();

            System.Console.Write("Enter the path to the game's save directory:\n");
            string gamePath = System.Console.ReadLine();

            System.Console.Write("Is this path within steam's directory?\n1) Yes\n2) No\n");
            int inp = int.Parse(System.Console.ReadLine());
            bool steamPath;

            switch (inp)
            {
                case 1:
                    steamPath = true;
                    break;
                default:
                    steamPath = false;
                    break;
            }

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

            games.Add(new Game(dispName, gamePath, processName, fileNames, steamPath));
            System.Console.Write("Game added.\n");
            
            return;
        }
    }
}
