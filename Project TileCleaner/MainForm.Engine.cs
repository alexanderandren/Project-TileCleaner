/**
 * ## Project TileCleaner ##
 * MainForm.Engine.cs
 * Part of the project-assignment in DA204A.
 * Written by Alexander Andrén 2019-05-08.  
 * 
 * This partial MainForm class holds the methods to play the board, 
 * as well as some controls of Graphics (updating Button looks when clicked).
 * 
 * It is unknown to me if it is bad practice to create another partial class of a Form, 
 * however the functionality seems correct. 
 */

using System;
using System.Drawing;
using System.Windows.Forms;

namespace Project_TileCleaner
{
    partial class MainForm
    {
        /// <summary>
        /// Method called when tile is clicked. 
        /// MouseUp is used since other do not recognice the right click button. 
        /// Knowledge of how-to found at:
        /// https://stackoverflow.com/questions/19448346/how-to-get-a-right-click-mouse-event-changing-eventargs-to-mouseeventargs-cause
        /// and
        /// https://stackoverflow.com/questions/8201286/get-cursor-position-with-respect-to-the-control-c-sharp
        /// </summary>
        /// <param name="sender">The button clicked.</param>
        /// <param name="e">MouseEventArgs</param>
        private void Tile_Click(object sender, MouseEventArgs e)
        {
            // Gets the x and y coordinates of the mouseup event in relation to the button clicked. 
            int x = e.Location.X;
            int y = e.Location.Y;
            // If the mouseUp event happens outside the button, no code executes. 
            if (!(x > 30 || x < 0 || y > 30 || y < 0))
            {
                switch (e.Button)
                {
                    case MouseButtons.Left:
                        SweepTile((Tile)sender);
                        break;
                    case MouseButtons.Right:
                        FlagTile((Tile) sender);
                        break;
                    default:
                        break;
                }
                UpdateFlagCounter();
                CheckBoardSolved();
            }
        }

        /// <summary>
        /// Checks and opens the content of a tile. Calls different methods depending of content. 
        /// </summary>
        /// <param name="tile">Tile-object to be opened.</param>
        private void SweepTile(Tile tile)
        {
            if(!tile.IsOpen)
            {
                ClearFlag(tile);
                if (tile.HasMine)
                {
                    CurrBoard.Exploded = true;
                }
                else
                {
                    tile.IsOpen = true;
                    CurrBoard.ClearedTiles += 1;
                    tile.BackColor = Color.Sienna;
                    tile.Text = tile.ToString();
                    if (tile.MinesBeside == 0)
                        ShowNeighbourTiles(tile);
                }
            }
        }

        /// <summary>
        /// Flags or unflags the tile if it is not already opened. 
        /// Also updates the flag-counters in CurrBoard. 
        /// </summary>
        /// <param name="tile">(Tile-object)</param>
        private void FlagTile(Tile tile)
        {
            if (!tile.IsOpen)
            {
                if (tile.HasFlag)
                {
                    ClearFlag(tile);                   
                }
                else
                {
                    tile.HasFlag = true;
                    tile.BackColor = Color.Yellow;
                    CurrBoard.TotalFlags += 1;
                    if (!tile.HasMine)
                        CurrBoard.WrongFlags += 1;
                }
                tile.Text = tile.ToString();
            }
        }

        /// <summary>
        /// Clears any flag from a tile, and updates the counters in CurrBoard. 
        /// </summary>
        /// <param name="tile">(Tile-object)</param>
        private void ClearFlag(Tile tile)
        {
            if (tile.HasFlag)
            {
                CurrBoard.TotalFlags -= 1;
                if (!tile.HasMine)
                    CurrBoard.WrongFlags -= 1;
                tile.HasFlag = false;
                tile.BackColor = Color.ForestGreen;
            }
        }

        /// <summary>
        /// Shows the location of all tiles with mines on the board by 
        /// changing their background color. 
        /// Also removes all the event listeners from the tiles. 
        /// </summary>
        /// <param name="victorious">(bool) True if game is won. </param>
        private void ShowAllMines(bool victorious)
        {
            for (byte i = 0; i < this.CurrBoard.BS.Rows; i++)
            {
                for (byte j = 0; j < this.CurrBoard.BS.Columns; j++)
                {
                    Tile tile = CurrBoard.Tiles[i, j];
                    tile.MouseUp -= new MouseEventHandler(Tile_Click);
                    if (tile.HasMine)
                    {
                        if (victorious)
                            tile.BackColor = Color.Yellow;
                        else
                            tile.BackColor = Color.Red;
                        tile.IsOpen = true;
                        tile.Text = tile.ToString();
                    }
                }
            }
        }

        /// <summary>
        /// Calls method to display all mines, and method to show greeting or collect name for leaderboard. 
        /// </summary>
        /// <param name="victorious">(bool) true if game was won, false otherwise. </param>
        private void GameOver(bool victorious)
        {
            ShowAllMines(victorious);
            string msg, title, button;
            bool sweepFits = false;

            if (victorious)
            {
                sweepFits = CheckSweepResult();
                if (sweepFits)
                {
                    title = "Victory!";
                    msg = "You did very well! \nEnter your name to join \nthe leaderboard:";
                    button = "Yey!";
                }
                else
                {
                    title = "Victory... ish!";
                    msg = "Close, but no cigarr... \nYou survived, but not as \nmuch nas everyone else.";
                    button = "Do better";
                }    
            }
            else
            {
                msg = "Oups, that must have hurt. \nHope you have insurance. \nBetter luck next time...";
                title = "Game Over";
                button = "Retry";
            }
            EvaluatePerformance(title, msg, button, sweepFits);
        }

        /// <summary>
        /// Shows the neighbouring tiles of a tile with no mine nor neighbouring. 
        /// </summary>
        /// <param name="tile">Tile-object.</param>
        private void ShowNeighbourTiles(Tile tile)
        {
            int[] indexOfTile = FindIndex(tile);

            int neighbourRow, neighbourCol;

            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    neighbourRow = indexOfTile[0] + i;
                    neighbourCol = indexOfTile[1] + j;

                    if (neighbourRow >= 0
                        &&
                        neighbourRow < CurrBoard.Tiles.GetLength(0)
                        &&
                        neighbourCol >= 0
                        &&
                        neighbourCol < CurrBoard.Tiles.GetLength(1))
                    {
                        Tile neighbour = CurrBoard.Tiles[neighbourRow, neighbourCol];
                        SweepTile(neighbour);
                    }
                }
            }
        }

        /// <summary>
        /// Returns the index in the board-matrix of a tile. 
        /// </summary>
        /// <param name="tile">(Tile-object) Clicked tile. </param>
        /// <returns></returns>
        private int[] FindIndex(Tile tile)
        {
            int[] indexOfTile = new int[2];
            for (int i = 0; i < this.CurrBoard.BS.Rows; i++)
            {
                for (int j = 0; j < this.CurrBoard.BS.Columns; j++)
                {
                    if (tile == CurrBoard.Tiles[i, j])
                    {
                        indexOfTile[0] = i;
                        indexOfTile[1] = j;
                        return indexOfTile;
                    }
                }
            }
            // Only to allow compilation, never reached. 
            return indexOfTile;
        }

        /// <summary>
        /// Checks if the game is over through calls to CurrBoard.
        /// Calls method GameOver to display results of game. 
        /// </summary>
        private void CheckBoardSolved()
        {
            if(CurrBoard.CheckSolved() || CurrBoard.Exploded)
            {
                timer.Enabled = false;
                bool victorious = !CurrBoard.Exploded && CurrBoard.CheckSolved();
                GameOver(victorious);
            }
        }

        /// <summary>
        /// Checks if the results of the sweep fits the leaderboards through calls to SwpMngr.
        /// </summary>
        /// <returns>sweepFits (bool). </returns>
        private bool CheckSweepResult()
        {
            int time = Int32.Parse(lblTimer.Text);
            bool sweepFits = SwpMngr.TestNewSweep(time, CurrBoard.BS.SetDifficulty);
            return sweepFits;
        }

        /// <summary>
        /// Opens a EvalForm with a greeting for winning or losing, and the possibility to enter a name if 
        /// qualified for leaderboard. 
        /// Starts a new game if user choses "retry" or "do better".
        /// </summary>
        /// <param name="title">string.</param>
        /// <param name="msg">string.</param>
        /// <param name="button">string.</param>
        /// <param name="sweepFits">bool.</param>
        private void EvaluatePerformance(string title, string msg, string button, bool sweepFits)
        {
            EvalForm resultForm = new EvalForm(title, msg, button, sweepFits);
            DialogResult results = resultForm.ShowDialog();
            if(sweepFits && results != DialogResult.Cancel)
            {
                string name = resultForm.GetName();
                if(!String.IsNullOrEmpty(name))
                {
                    int time = Int32.Parse(lblTimer.Text);
                    Difficulty diff = CurrBoard.BS.SetDifficulty;
                    bool saveSuccess = SwpMngr.AddNewSweep(name, time, diff);
                    if (!saveSuccess)
                        MessageBox.Show(SwpMngr.ErrorMsg, "File save error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (results == DialogResult.Retry)
            {
                StartNewGame();
            }
        }
    }
}
