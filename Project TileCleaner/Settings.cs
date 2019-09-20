/**
 * ## Project TileCleaner ##
 * Settings.cs
 * Part of the project-assignment in DA204A.
 * Written by Alexander Andrén 2019-05-08.  
 */

namespace Project_TileCleaner
{
    /// <summary>
    /// Struct Settings holds the definitions for each difficuty level, 
    /// found in enum Difficulty.cs. 
    /// </summary>
    public struct Settings
    {
        private Difficulty setDifficulty;
        private byte rows;
        private byte columns;
        private byte mines;

        /// <summary>
        /// Constructor. Sets the values of rows, columns and mines based on the Difficulty setting. 
        /// If the difficulty setting is unknown the default setting is Easy. 
        /// </summary>
        /// <param name="choice">(enum Setting)</param>
        public Settings(Difficulty choice)
        {
            this.setDifficulty = choice;

            switch (choice)
            {
                case Difficulty.Easy:
                    this.rows = 8;
                    this.columns = 8;
                    this.mines = 10;
                    break;
                case Difficulty.Intermediate:
                    this.rows = 16;
                    this.columns = 16;
                    this.mines = 40;
                    break;
                case Difficulty.Hard:
                    this.rows = 16;
                    this.columns = 24;
                    this.mines = 66;
                    break;
                default:
                    // This is the fallback if enum Difficulty.cs holds other values than
                    // this struct has values for. The settings are made Easy. 
                    this.setDifficulty = Difficulty.Easy;
                    this.rows = 8;
                    this.columns = 8;
                    this.mines = 10;
                    break;
            }
        }
        
        // Properties - all readonly. 
        public Difficulty SetDifficulty { get => setDifficulty; }
        public byte Rows { get => rows; }
        public byte Columns { get => columns; }
        public byte Mines { get => mines; }
        // Properties end. 
    }
}
