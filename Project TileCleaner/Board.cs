/**
 * ## Project TileCleaner ##
 * Board.cs
 * Part of the project-assignment in DA204A.
 * Written by Alexander Andrén 2019-05-08.  
 */

using System;

namespace Project_TileCleaner
{
    /// <summary>
    /// Class Board describes a playing board, or a matrix of tiles. 
    /// Board has six fields. One matrix array, one struct holding the values of the board (size, mines),
    /// and three integers to track the win conditions. Last one boolean exploded if a mine has been swept or not. 
    /// </summary>
    class Board
    {
        private Tile[,] tiles;
        private Settings boardSettings;
        private int totalFlags, wrongFlags, clearedTiles;
        private bool exploded = false;

        /// <summary>
        /// Constructor. Creates the matrix tiles and places mines through calls to subsequent methods. 
        /// </summary>
        /// <param name="choice">Difficulty enum, the choice made through the radiobutton in MainForm. </param>
        public Board(Difficulty choice)
        {
            // Step one: create the struct with the settings. 
            BS = new Settings(choice);
            // Step two: create the matrix.
            CreateMatrix();
            // Step three: place the mines. 
            PlaceMines();
        }

        // Properties.
        public Settings BS { get => boardSettings; set => boardSettings = value; }
        public Tile[,] Tiles { get => tiles; set => tiles = value; }
        public int TotalFlags { get => totalFlags; set => totalFlags = value; }
        public int WrongFlags { get => wrongFlags; set => wrongFlags = value; }
        public int ClearedTiles { get => clearedTiles; set => clearedTiles = value; }
        public bool Exploded { get => exploded; set => exploded = value; }

        // Properties end. 

        /// <summary>
        /// Creates the matrix based on the values in BoardSettings (BS). 
        /// ATT! Can only be called in constructor after BoardSettings (BS) has been created. 
        /// </summary>
        private void CreateMatrix()
        {
            Tiles = new Tile[BS.Rows, BS.Columns];
            for(byte i = 0; i < BS.Rows; i++)
            {
                for(byte j = 0; j < BS.Columns; j++)
                {
                    Tiles[i, j] = new Tile();
                }
            }
        }

        /// <summary>
        /// Sets the value HasMine for random Tile-objects in Tiles to true. 
        /// Also calls method to add indication of the mine to the surrounding tiles. 
        /// ATT! Can only be called in constructor after CreateMatrix has been called.  
        /// </summary>
        private void PlaceMines()
        {
            Random generator = new Random();
            byte count = 0;
            int randRow, randCol;

            while(count < BS.Mines)
            {
                randRow = generator.Next(BS.Rows);
                randCol = generator.Next(BS.Columns);

                if(!Tiles[randRow, randCol].HasMine)
                {
                    Tiles[randRow, randCol].HasMine = true;
                    AddIndicationToNeighbours(randRow, randCol);
                    count += 1;
                }
            }
        }

        /// <summary>
        /// Adds one to the Property MinesBeside of each Tile neighbouring one with a mine. 
        /// </summary>
        /// <param name="mineRow">(int) row-index of the Tile with the mine. </param>
        /// <param name="mineColumn">(int) column-index of the Tile with the mine. </param>
        private void AddIndicationToNeighbours(int mineRow, int mineColumn)
        {
            int rowIndication, columnIndication;

            for(int i = -1; i < 2; i++)
            {
                for(int j = -1; j < 2; j++)
                {
                    rowIndication = mineRow + i;
                    columnIndication = mineColumn + j;

                    if (rowIndication >= 0 
                        && 
                        rowIndication < Tiles.GetLength(0) 
                        && 
                        columnIndication >= 0 
                        && 
                        columnIndication < Tiles.GetLength(1))
                    {
                        Tiles[rowIndication, columnIndication].MinesBeside += 1;
                    }
                }
            }
        }

        /// <summary>
        /// Checks of the board is solved, ie the game is won. 
        /// </summary>
        /// <returns>solved (bool), true if game is won. </returns>
        public bool CheckSolved()
        {
            bool solved = false;

            if (TotalFlags == BS.Mines && WrongFlags == 0
                ||
                ClearedTiles == BS.Rows * BS.Columns - BS.Mines)
                solved = true;
            return solved;
        }
    }
}
