/**
 * ## Project TileCleaner ##
 * Tile.cs
 * Part of the project-assignment in DA204A.
 * Written by Alexander Andrén 2019-05-08.  
 * 
 * Class Tile describes one tile on the playfield. Tile inhertis the methods and properties of the Button-object,
 * making the Tile and Button the same. This enables calls to the object to update both the logical and the graphical part. 
 */

using System.Windows.Forms;

namespace Project_TileCleaner
{
    /// <summary>
    /// Class Tile describes one tile on the playfield. Tile inhertis the methods and properties of the Button-object,
    /// making the Tile and Button the same. This enables calls to the object to update both the logical and the graphical part. 
    /// Properties describing if flagged, if mine, if opened and nr och neighbouring mines.  
    /// </summary>
    class Tile : Button
    {
        private bool hasFlag;
        private bool hasMine;
        private bool isOpen;
        private byte minesBeside;

        /// <summary>
        /// Constructor. Initiates all values to false or 0. 
        /// </summary>
        public Tile()
        {
            this.HasFlag = false;
            this.HasMine = false;
            this.IsOpen = false;
            this.MinesBeside = 0;
        }

        // Properties.
        public bool HasFlag { get => hasFlag; set => hasFlag = value; }
        public bool HasMine { get => hasMine; set => hasMine = value; }
        public bool IsOpen { get => isOpen; set => isOpen = value; }
        public byte MinesBeside { get => minesBeside; set => minesBeside = value; }
        // Properties end. 

        /// <summary>
        /// Returns a string representation of the Tile. 
        /// </summary>
        /// <returns>strRepresentation (string).</returns>
        public override string ToString()
        {
            string strRepresentation = " ";
            if(this.IsOpen)
            {
                if(this.HasMine)
                    strRepresentation = "M";
                else if(this.MinesBeside > 0)
                    strRepresentation = this.MinesBeside.ToString();
            }
            else if(this.HasFlag)
                strRepresentation = "F";
            return strRepresentation;
        }
    }
}
