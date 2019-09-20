/**
 * ## Project TileCleaner ##
 * Program.cs
 * Part of the project-assignment in DA204A.
 * Written by Alexander Andrén 2019-05-09.  
 * 
 * The program copies the old Windows game MineSweeper, with modifications. 
 * It utilizes Windows Forms Buttons to create a board of tiles, hiding mines or numbers. 
 * 
 * The game is won by revealing or flagging all mines. 
 * 
 * The use of Buttons is not the most efficient way of achieveing the functionality.
 * When the larger boards are used, the program becomes quite slow creating the board. 
 * However, for the scope of this project, the functionality is sufficient, and the program is
 * written in a fashion that the Class Tile could realtively easy be replaced with something else to 
 * speed up the program. 
 */

using System;
using System.Windows.Forms;

namespace Project_TileCleaner
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
