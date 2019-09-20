/**
 * ## Project TileCleaner ##
 * EvalForm.cs
 * Part of the project-assignment in DA204A.
 * Written by Alexander Andrén 2019-05-09.  
 */

using System.Windows.Forms;

namespace Project_TileCleaner
{
    /// <summary>
    /// Class EvalForm describes a window showing the results of the game.
    /// It may allow user to enter name if he/she qualified for leaderboard. 
    /// </summary>
    public partial class EvalForm : Form
    {
        public EvalForm(string title, string msg, string button, bool getName)
        {
            InitializeComponent();

            this.Text = title;
            lblGreeting.Text = msg;
            btnOKRetry.Text = button;
            inputName.Enabled = getName;
        }

        /// <summary>
        /// Returns the contents of the textbox. 
        /// </summary>
        /// <returns>string.</returns>
        public string GetName()
        {
            return inputName.Text.Trim();
        }

        /// <summary>
        /// EnterButton performs a click on the OkRetry-button. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EvalForm_Enter(object sender, System.EventArgs e)
        {
            btnOKRetry.PerformClick();
        }
    }
}
