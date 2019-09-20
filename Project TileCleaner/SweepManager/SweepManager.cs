/**
 * ## Project TileCleaner ##
 * SweepManager.cs
 * Part of the project-assignment in DA204A.
 * Written by Alexander Andrén 2019-05-09.  
 */

using System;
using System.IO;

namespace Project_TileCleaner
{
    /// <summary>
    /// Class SweepManager describes a manager for lists of highscores. 
    /// It holds and SweepList[] array as a field, with the length of the number of difficulties available. 
    /// It also holds filepath of file where leaderboards are stored.
    /// Lastly it ha a string holding an errormsg if anything goes wrong reading or saving to the file. 
    /// It has methods to read and write leaderbords to/from a file, and calls methods of contained SweepLists to 
    /// add new results. 
    /// </summary>
    class SweepManager
    {
        private SweepList[] leaderboards;
        private int nrOfSweepsPerList = 5;
        private string fileName = "MinKraftLeaderboards.txt";
        private string errorMsg;

        // Properties.
        public SweepList[] Leaderboards { get => leaderboards; set => leaderboards = value; }
        public int NrOfSweepsPerList { get => nrOfSweepsPerList; }
        public string FileName { get => fileName; }
        public string ErrorMsg { get => errorMsg; set => errorMsg = value; }

        // Properties end. 

        /// <summary>
        /// Constructor. Creates the SweepList-array leaderboards to the length of the number of difficulty levels. 
        /// Sets the number of displayed sweeps in each leaderboard to the variable int nrOfSweepsPerList defined below. 
        /// Last calls method to read from file and update the leaderboards. 
        /// </summary>
        public SweepManager()
        {
            // Leaderboards gets the same number of SweepLists as there are difficulty levels defined. 
            Leaderboards = new SweepList[Enum.GetNames(typeof(Difficulty)).Length];

            for (int i = 0; i < Leaderboards.Length; i++)
                Leaderboards[i] = new SweepList(NrOfSweepsPerList);
    }

        /// <summary>
        /// Checks if latest sweep fits the leaderboard matching the difficulty. 
        /// </summary>
        /// <param name="time">Integer. </param>
        /// <param name="diff">Difficulty. Setting of current board. </param>
        public bool TestNewSweep(int time, Difficulty diff)
        {
            bool sweepFits = GetCurrentList(diff).CheckIfSweepQualifies(time);
            return sweepFits;
        }

        /// <summary>
        /// Returns the proper SweepList based on difficulty setting. 
        /// </summary>
        /// <param name="diff">Difficulty. Setting of current board. </param>
        /// <returns>(SweepList) matching the index of the difficulty. </returns>
        private SweepList GetCurrentList(Difficulty diff)
        {
            return Leaderboards[(int)diff];
        }

        /// <summary>
        /// Adds a new entry to the current leaderboard. Saves the leaderboards. 
        /// If unsuccessful save, returns false. 
        /// </summary>
        /// <param name="name">string. </param>
        /// <param name="time">integer. </param>
        /// <param name="diff">Difficulty. </param>
        /// <return>successfulSave (true if successful, false otherwise).</return>
        public bool AddNewSweep(string name, int time, Difficulty diff)
        {
            SweepList currList = GetCurrentList(diff);

            currList.PlaceLatestSweep(name, time);

            bool successfulSave = SaveLeaderboards();

            return successfulSave;
        }

        /// <summary>
        /// Creates a string matrix which can be displayed through a ScoreForm. 
        /// </summary>
        /// <returns>total (string[,])</returns>
        public string[,] GetAllBoards()
        {
            string[,] allBoards = new string[Leaderboards.Length, NrOfSweepsPerList];

            for (int i = 0; i < Leaderboards.Length; i++)
            {
                string[] currStringList = GetCurrentList((Difficulty)i).GetSweepList();
                for (int j = 0; j < NrOfSweepsPerList; j++)
                    allBoards[i, j] = currStringList[j];
            }
            return allBoards;
        }

        /// <summary>
        /// Attempts to save current leaderboards to a file. 
        /// </summary>
        /// <returns>true if successful save, false otherwise. </returns>
        private bool SaveLeaderboards()
        {
            // Saving the list is done by first saving all values of each sweep to a stringArray. 
            // Leaderboards.Length = number of SweepLists. 
            // NrOfSweepsPerList = same.
            // 2 = Two entries per Sweep, name and time. 
            string[] stringsToSave = new string[Leaderboards.Length * NrOfSweepsPerList * 2];
            // Counter keeps track of which position in stringsToSave to write to. 
            int counter = 0;
            foreach(SweepList currList in Leaderboards)
            {
                for (int i = 0; i < NrOfSweepsPerList; i++)
                {
                    stringsToSave[counter] = currList.SwpList[i].Name;
                    counter++;
                    stringsToSave[counter] = currList.SwpList[i].Time.ToString();
                    counter++;
                } 
            }
            try
            {
                File.WriteAllLines(this.FileName, stringsToSave);
            }
            catch (UnauthorizedAccessException)
            {
                this.ErrorMsg = "Could not save results to " + this.FileName + "\nThe file might be read-only.";
                return false;
            }
            return true;
        }

        /// <summary>
        /// Attempts to load the content of a file to the leaderbords. 
        /// If unsuccessful, creates an errormessage as a field of the class. 
        /// </summary>
        public bool ReadLeaderboardsFile()
        {
            bool fileLoadSuccess = true;

            string[] stringsRead;
            // First, check the file exists. 
            if (File.Exists(this.FileName))
                stringsRead = File.ReadAllLines(this.FileName);
            else
            {
                fileLoadSuccess = false;
                this.ErrorMsg = "Could not find the file " + this.FileName + "\nA new file will be created on successful sweep.";
                return fileLoadSuccess;
            }

            int expectedLength = Leaderboards.Length * NrOfSweepsPerList * 2;
            if (stringsRead.Length != expectedLength)
            {
                fileLoadSuccess = false;
                this.ErrorMsg = "Discrepency of filelength and expected length in " + this.FileName + "\nContents will be overwritten on successful sweep";
                return fileLoadSuccess;
            }

            fileLoadSuccess = LoadToLeaderboards(stringsRead);

            return fileLoadSuccess;
        }

        /// <summary>
        /// Loads the content of the read file to the Leaderboards Sweep objects. 
        /// </summary>
        /// <param name="input">(string[]) holding all values read from file. </param>
        /// <returns>(bool) true if operation was successful, false otherwise.</returns>
        private bool LoadToLeaderboards(string[] input)
        {
            // Counter keeps track of which value to read.
            int counter = 0;
            // CurrentTime holds the current value of read time. 
            int currentTime;
            foreach (SweepList currList in Leaderboards)
            {
                for (int i = 0; i < NrOfSweepsPerList; i++)
                {
                    currList.SwpList[i].Name = input[counter];
                    counter++;
                    if (Int32.TryParse(input[counter], out currentTime))
                    {
                        currList.SwpList[i].Time = currentTime;
                        counter++;
                    }
                    else
                    {
                        this.ErrorMsg = "File corrupt, could not read times correctly. " + this.FileName + "\nContents will be overwritten on successful sweep";
                        return false;
                    }
                }
            }
            return true;
        }
    }
}

