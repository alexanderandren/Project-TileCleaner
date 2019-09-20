/**
 * ## Project TileCleaner ##
 * Sweep.cs
 * Part of the project-assignment in DA204A.
 * Written by Alexander Andrén 2019-05-09.  
 */
namespace Project_TileCleaner
{
    /// <summary>
    /// Struct Sweep describes an entry into a scoreboard, with name and elapsed time. 
    /// </summary>
    public struct Sweep
    {
        private string name;
        private int time;

        /// <summary>
        /// Constructor. 
        /// </summary>
        /// <param name="newName">String</param>
        /// <param name="newTime">Int</param>
        public Sweep(string newName, int newTime)
        {
            this.name = newName;
            this.time = newTime;
        }

        // Properties.
        public string Name { get => name; set => name = value; }
        public int Time { get => time; set => time = value; }
        // Properties end.

        /// <summary>
        /// Returns a string representation of the Sweep object. 
        /// If the name is null or empty, returns the string Empty.
        /// </summary>
        /// <returns>string (15 characters long)</returns>
        public override string ToString()
        {
            string tempName = this.Name;
            if (string.IsNullOrEmpty(tempName))
                return "---- Empty ----";
            else if(tempName.Length > 10)
                tempName = tempName.Substring(0, 9) + ".";
            return string.Format("{0,-10} {1,4}", tempName, this.Time);
        }
    }
}
