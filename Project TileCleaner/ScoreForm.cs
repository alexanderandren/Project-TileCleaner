/**
 * ## Project TileCleaner ##
 * ScoreForm.cs
 * Part of the project-assignment in DA204A.
 * Written by Alexander Andrén 2019-05-08.  
 */

using System;
using System.Windows.Forms;

namespace Project_TileCleaner
{
    /// <summary>
    /// class ScoreForm describes a form for showing the leaderboards.
    /// It adapts to the number of difficulty levels, and displays the same number of leaberBoards. 
    /// This can be tested by adding or removing Difficulty-levels in Difficulty.cs. 
    /// </summary>
    public partial class ScoreForm : Form
    {
        /// <summary>
        /// Constructor. Calls methods to set up the graphics, and then method to print the current standings to the leaderboards. 
        /// </summary>
        /// <param name="currentStandings"></param>
        public ScoreForm(string[,] currentStandings)
        {
            InitializeComponent();

            int nrOfBoards = Enum.GetNames(typeof(Difficulty)).Length;
            SetupHeaderAndButton(nrOfBoards);
            SetupLabels(nrOfBoards);
            SetupLeaderBoards(nrOfBoards);
            DisplayTheStandings(currentStandings, nrOfBoards);
        }

        /// <summary>
        /// Sets the width of the window, and then centers the Header and Done-button. 
        /// </summary>
        /// <param name="nrOfBoards">(int) nr of difficulty-levels in Difficulty.cs. </param>
        private void SetupHeaderAndButton(int nrOfBoards)
        {
            // Sets the windowsize to hold all the boards. 
            // Each listbox is 180 wide, and given space of 180. 
            this.Width = (40 + 190 * nrOfBoards);

            // Calculations below place the header and button in the center of the window. 
            lblLeabderboards.Location = new System.Drawing.Point((this.Width/2) - 106, 9);
            btnDone.Location = new System.Drawing.Point((this.Width / 2) - 71, 170);
        }

        /// <summary>
        /// Creates and places the headers for each category of difficulty. 
        /// </summary>
        /// <param name="nrOfBoards">(int) nr of difficulty-levels in Difficulty.cs. </param>
        private void SetupLabels(int nrOfBoards)
        {
            for (int i = 0; i < nrOfBoards; i++)
            {
                Label newLabel = new Label();
                newLabel.AutoSize = true;
                newLabel.Font = new System.Drawing.Font("OCR A Extended", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                newLabel.Location = new System.Drawing.Point((13 + 190 * i), 43);
                newLabel.Name = "newLabel" + i;
                newLabel.Text = ((Difficulty)i).ToString();
                this.Controls.Add(newLabel);
            }
        }

        /// <summary>
        /// Sets up the listboxes that will hold the results. 
        /// </summary>
        /// <param name="nrOfBoards">(int) nr of difficulty-levels in Difficulty.cs. </param>
        private void SetupLeaderBoards(int nrOfBoards)
        {
            for(int i = 0; i < nrOfBoards; i++)
            {
                ListBox newListBox = new ListBox();
                newListBox.BackColor = System.Drawing.Color.OliveDrab;
                newListBox.Font = new System.Drawing.Font("OCR A Extended", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                newListBox.ForeColor = System.Drawing.Color.Gold;
                newListBox.FormattingEnabled = true;
                newListBox.ItemHeight = 17;
                // The position is decided by the formula below. 190*i sets each new form to the right of the previous. 
                newListBox.Location = new System.Drawing.Point((13 + 190*i), 70);
                newListBox.Name = "newListBox" + i;
                newListBox.Size = new System.Drawing.Size(180, 103);
                this.Controls.Add(newListBox);
            }
        }

        /// <summary>
        /// Prints the contents of the provided stringarray-matrix to the listboxes. 
        /// </summary>
        /// <param name="currentStandings">(string[,]) containing all the current results. </param>
        /// <param name="nrOfBoards">(Integer). Nr of boards created. </param>
        private void DisplayTheStandings(string[,] currentStandings, int nrOfBoards)
        {
            // boardLength will be used in the loop below to find when to write to the next loop. 
            int boardLength = currentStandings.Length / nrOfBoards;

            for (int i = 0; i < nrOfBoards; i++)
            {
                ListBox currListBox = (ListBox)Controls.Find(("newListBox" + i), true)[0];
                for (int j = 0; j < boardLength; j++)
                {
                    currListBox.Items.Add(currentStandings[i,j]);
                }  
            }
        }

        /// <summary>
        /// Enter button closes the form. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScoreForm_Enter(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
