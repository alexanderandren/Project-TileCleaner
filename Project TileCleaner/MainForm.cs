/**
 * ## Project TileCleaner ##
 * MainForm.cs
 * Part of the project-assignment in DA204A.
 * Written by Alexander Andrén 2019-05-08.  
 */

using System;
using System.Drawing;
using System.Windows.Forms;

namespace Project_TileCleaner
{
    /// <summary>
    /// MainForm describes the GUI-components of the application. 
    /// It has methods to create and use board, click or flag tiles. 
    /// It has two fields, an instance of the Board-object, and one instance of SweepManager. 
    /// </summary>
    public partial class MainForm : Form
    {
        private Board currBoard;
        private SweepManager swpMngr;

        /// <summary>
        /// Constructor, initiates the CurrBoard to null. 
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            CurrBoard = null;
            SwpMngr = new SweepManager();
            TryLoadFile();            
        }

        // Properties. 
        internal Board CurrBoard { get => currBoard; set => currBoard = value; }
        internal SweepManager SwpMngr { get => swpMngr; set => swpMngr = value; }

        // Properties end. 

        /// <summary>
        /// Attempts to read stored information in leaderboardsfile. 
        /// If unsuccesful, displays errormsg. 
        /// </summary>
        private void TryLoadFile()
        {
            bool success = SwpMngr.ReadLeaderboardsFile();
            if (!success)
                MessageBox.Show(SwpMngr.ErrorMsg, "File load error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// Calls methods to start new game; 
        /// </summary>
        private void btnNewGame_Click(object sender, EventArgs e)
        {
            StartNewGame();
        }

        /// <summary>
        /// Removes old board if there is one, and creates a new one. 
        /// </summary>
        private void StartNewGame()
        {
            if (CurrBoard != null)
                DeleteCurrBoard();

            Difficulty diff = GetDifficultyLevel();
            SetWindowSize(diff);
            CreateBoardGraphics(diff);
            SetTimerAndCounter();
        }

        /// <summary>
        /// Returns the chosen difficulty setting (as checked in radiobuttons in MainForm).
        /// </summary>
        /// <returns>chosenDiff (Difficulty)</returns>
        private Difficulty GetDifficultyLevel()
        {
            Difficulty diff;
            if (rBtnEasy.Checked)
                diff = Difficulty.Easy;
            else if (rBtnIntermediate.Checked)
                diff = Difficulty.Intermediate;
            else if (rBtnHard.Checked)
                diff = Difficulty.Hard;
            else
                diff = Difficulty.Easy; // Easy setting is fallback, should changes be made and this not updated. 
            return diff;
        }

        /// <summary>
        /// Sets the window-size depending on the difficulty setting, to fit the board. 
        /// </summary>
        /// <param name="diff">(Difficulty) current setting of the radiobuttons. </param>
        private void SetWindowSize(Difficulty diff)
        {
            if (diff == Difficulty.Intermediate)
            {
                this.Width = 540;
                this.Height = 700;
            }
            else if (diff == Difficulty.Hard)
            {
                this.Width = 780;
                this.Height = 700;
            }
            else // Easy is fallback. 
            {
                this.Width = 300;
                this.Height = 460;
            }
        }

        /// <summary>
        /// Creates the graphical representation of the board. 
        /// </summary>
        /// <param name="diff">(Difficulty) setting of the radiobuttons. </param>
        private void CreateBoardGraphics(Difficulty diff)
        {
            this.CurrBoard = new Board(diff);

            for (byte i = 0; i < this.CurrBoard.BS.Rows; i++)
            {
                for (byte j = 0; j < this.CurrBoard.BS.Columns; j++)
                {
                    Tile tile = CurrBoard.Tiles[i, j];
                    // Values below control the looks of the board.
                    // 20 is padding left, 120 is padding top, to place buttons below meny and new-game button. 
                    tile.Location = new Point(20 + j * 30, 160 + i * 30);
                    tile.Height = 30; 
                    tile.Width = 30;
                    tile.FlatStyle = FlatStyle.Flat;
                    tile.BackColor = Color.ForestGreen;
                    tile.Font = new Font("OCR A Extended", 14);
                    tile.Text = tile.ToString();
                    // Method Tile_Click is part of game-"engine", thus it is placed in the partial class MainForm.Engine.cs. 
                    tile.MouseUp += new MouseEventHandler(Tile_Click);
                    Controls.Add(tile);
                }
            }
        }

        /// <summary>
        /// Deletes all the tiles in the current board, as well as the event listeners. 
        /// </summary>
        private void DeleteCurrBoard()
        {
            for (byte i = 0; i < this.CurrBoard.BS.Rows; i++)
            {
                for (byte j = 0; j < CurrBoard.BS.Columns; j++)
                {
                    CurrBoard.Tiles[i, j].MouseUp -= new MouseEventHandler(Tile_Click);
                    CurrBoard.Tiles[i, j].Dispose();
                }
            }
        }

        /// <summary>
        /// Updates the seconds in lblTimer. 
        /// </summary>
        private void timer_Tick(object sender, EventArgs e)
        {
            lblTimer.Text = String.Format("{0,3:D3}",(Int32.Parse(lblTimer.Text) + 1));
        }

        /// <summary>
        /// Resets the timer and sets the counter.
        /// Starts the timer. 
        /// </summary>
        private void SetTimerAndCounter()
        {
            lblTimer.Text = "000";
            lblCounter.Text = String.Format("{0,3:D3}", CurrBoard.BS.Mines);
            timer.Enabled = true;
        }

        /// <summary>
        /// Updates the FlagCounter with remaining flags. 
        /// </summary>
        private void UpdateFlagCounter()
        {
            lblCounter.Text = String.Format("{0,3:D3}", CurrBoard.BS.Mines - CurrBoard.TotalFlags);
        }

        /// <summary>
        /// Shows the form with the leaderboards. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLeaderBoards_Click(object sender, EventArgs e)
        {

            ScoreForm leaders = new ScoreForm(SwpMngr.GetAllBoards());
            leaders.ShowDialog();
        }
    }
}
