using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Generalized_Backup_Tool
{
    static class Program
    {
        public static List<Game> gameList = new List<Game>();
        static Defaults defaults = new Defaults();
        public static System.Threading.Thread backupThread;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Setup();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        /// <summary>
        /// Sets up any variables and kick off background thread.
        /// </summary>
        static void Setup()
        {
            // Import the list of games, if present.
            if (System.IO.File.Exists(@"Games.bin"))
            {
                using(System.IO.Stream stream = System.IO.File.Open(@"games.bin", System.IO.FileMode.Open))
                {
                    var bFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    gameList = (List<Game>)bFormatter.Deserialize(stream);
                }
            }
            else
            {
                // If no game list is present, create a
                // new blank instance.
                gameList = new List<Game>();
            }

            // Start a background thread to do the
            // actual backing up.
            backupThread = new System.Threading.Thread(new System.Threading.ThreadStart(backUpGames));
            backupThread.Start();
        }

        /// <summary>
        /// Backup games in a seperate thread.
        /// TODO: Make sure that this thread can be closed by the user.
        /// </summary>
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
                try {
                    // TODO reload the game list to make sure new
                    // games are added.
                    processList = System.Diagnostics.Process.GetProcesses(cName);

                    // Get the names of all running processes.
                    for (i = 0; i < processList.Count(); i++)
                    {
                        pNameList.Add(processList.ElementAt(i).ProcessName);
                    }

                    for (i = 0; i < gameList.Count; i++)
                    {
                        if (pNameList.Contains(gameList.ElementAt(i).processName))
                        {
                            found = true;
                            break;
                        }
                    }
                    if (found)
                    {
                        //Game at [i] is running!
                        currentSlot = gameList.ElementAt(i).currentSlot;
                        string backupPath = defaults.getBackupPath() + "\\" + gameList.ElementAt(i).gameName + "\\" + currentSlot;
                        List<string> bFiles = gameList.ElementAt(i).fileNames;
                        string currentFileName = bFiles + "_" + currentSlot;

                        if (bFiles == null)
                        {
                            // Back up all files, as none were specified.
                            Console.WriteLine("Backing up all files in directory...");
                            try {

                                if (!System.IO.Directory.Exists(backupPath))
                                {
                                    // Create the directory.
                                    System.IO.Directory.CreateDirectory(backupPath);
                                }
                                foreach (var file in System.IO.Directory.GetFiles(gameList.ElementAt(i).savePath))
                                {
                                    System.IO.File.Copy(file, System.IO.Path.Combine(backupPath, System.IO.Path.GetFileName(file)), true);
                                    Console.WriteLine("Copying " + System.IO.Path.GetFileName(file));
                                    // Note that subdirectories are not backed up. This will be an option in the future.
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Error backing up games!");
                            }
                        }
                        else {
                            for (int k = 0; k < bFiles.Count; k++)
                            {
                                //Back up each file.
                                try
                                {
                                    string sPath = System.IO.Path.Combine(gameList.ElementAt(i).savePath, bFiles.ElementAt(k));
                                    string dPath = System.IO.Path.Combine(backupPath, bFiles.ElementAt(k));

                                    if (!System.IO.Directory.Exists(backupPath))
                                    {
                                        // Create the directory.
                                        System.IO.Directory.CreateDirectory(backupPath);
                                    }

                                    // Copy the files.
                                    System.IO.File.Copy(sPath, dPath, true);
                                }
                                catch (Exception e)
                                {
                                    System.Console.WriteLine("Error backing up game. Please check all paths & file permissions.");
                                }
                            }
                        }

                        System.Console.WriteLine("Save files backed up to slot " + currentSlot);

                        currentSlot++;
                        gameList.ElementAt(i).currentSlot = currentSlot;
                        using (System.IO.Stream stream = System.IO.File.Open("games.bin", System.IO.FileMode.Create))
                        {
                            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bin = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                            bin.Serialize(stream, gameList);
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
                catch(System.Threading.ThreadInterruptedException e)
                {
                    Console.WriteLine("Exiting backup thread...");
                }
            }
        }

        public static void writeGameList()
        {
            // Serialize and save.
            using (System.IO.Stream stream = System.IO.File.Open("games.bin", System.IO.FileMode.Create))
            {
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bin = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                bin.Serialize(stream, gameList);
            }

            System.Console.Write("Game added.\n");

            return;
        }
    }
}
