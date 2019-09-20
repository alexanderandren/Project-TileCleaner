/**
 * ## Project TileCleaner ##
 * SweepList.cs
 * Part of the project-assignment in DA204A.
 * Written by Alexander Andrén 2019-05-10.  
 */

using System;

namespace Project_TileCleaner
{
    /// <summary>
    /// The struct SweepList describes a list of Sweeps. 
    /// </summary>
    public struct SweepList
    {
        private Sweep[] swpList;

        /// <summary>
        /// Constructor. Sets the length of the SweepList. 
        /// </summary>
        /// <param name="listLength">(integer) Length of the array swpList.</param>
        public SweepList(int listLength)
        {
            swpList = new Sweep[listLength];
        }

        // Properties. 
        public Sweep[] SwpList { get => swpList; set => swpList = value; }
        // End properties. 

        /// <summary>
        /// Returns the entries in the leaderboard as a string-array. 
        /// </summary>
        /// <returns>swpListAsStrings (string[])</returns>
        public string[] GetSweepList()
        {
            string[] swpListAsStrings = new string[SwpList.Length];
            for (int i = 0; i < SwpList.Length; i++)
                swpListAsStrings[i] = SwpList[i].ToString();
            return swpListAsStrings;
        }

        /// <summary>
        /// Checks if latest sweep fits this leaderboard. 
        /// </summary>
        /// <param name="time">Integer. </param>
        /// <returns>sweepFits (bool) true if it qualifies. </returns>
        public bool CheckIfSweepQualifies(int time)
        {
            bool sweepFits = false;

            if (String.IsNullOrEmpty(SwpList[SwpList.Length - 1].Name) || SwpList[SwpList.Length - 1].Time > time)
                sweepFits = true;
            return sweepFits;
        }

        /// <summary>
        /// Fits the latest sweep into the SwpList.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="time"></param>
        public void PlaceLatestSweep(string name, int time)
        {
            int beatIndex = FindBeatIndex(time);

            Sweep newSweep = new Sweep(name, time);

            for (int i = SwpList.Length - 1; i > beatIndex; i--)
            {
                SwpList[i] = SwpList[i - 1];
            }
            SwpList[beatIndex] = newSweep;
        }

        /// <summary>
        /// Finds and returns the index of the entry in SwpList that the latest result has beaten.
        /// </summary>
        /// <param name="time">integer. </param>
        /// <returns>beatIndex (integer). </returns>
        private int FindBeatIndex(int time)
        {
            int beatIndex;
            for (beatIndex = 0; beatIndex < SwpList.Length; beatIndex++)
            {
                if (String.IsNullOrEmpty(SwpList[beatIndex].Name) || SwpList[beatIndex].Time > time)
                    break;
            }
            return beatIndex;
        }
    }
}
