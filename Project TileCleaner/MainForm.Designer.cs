namespace Project_TileCleaner
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.lblHeader = new System.Windows.Forms.Label();
            this.btnNewGame = new System.Windows.Forms.Button();
            this.rBtnEasy = new System.Windows.Forms.RadioButton();
            this.rBtnIntermediate = new System.Windows.Forms.RadioButton();
            this.rBtnHard = new System.Windows.Forms.RadioButton();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.lblTimer = new System.Windows.Forms.Label();
            this.lblCounter = new System.Windows.Forms.Label();
            this.btnLeaderBoards = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("OCR A Extended", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.Location = new System.Drawing.Point(12, 9);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(124, 25);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "MinKraft";
            // 
            // btnNewGame
            // 
            this.btnNewGame.BackColor = System.Drawing.Color.ForestGreen;
            this.btnNewGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewGame.Font = new System.Drawing.Font("OCR A Extended", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewGame.Location = new System.Drawing.Point(14, 44);
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.Size = new System.Drawing.Size(122, 33);
            this.btnNewGame.TabIndex = 1;
            this.btnNewGame.Text = "New Game";
            this.btnNewGame.UseVisualStyleBackColor = false;
            this.btnNewGame.Click += new System.EventHandler(this.btnNewGame_Click);
            // 
            // rBtnEasy
            // 
            this.rBtnEasy.AutoSize = true;
            this.rBtnEasy.Checked = true;
            this.rBtnEasy.Font = new System.Drawing.Font("OCR A Extended", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rBtnEasy.Location = new System.Drawing.Point(142, 9);
            this.rBtnEasy.Name = "rBtnEasy";
            this.rBtnEasy.Size = new System.Drawing.Size(80, 27);
            this.rBtnEasy.TabIndex = 2;
            this.rBtnEasy.TabStop = true;
            this.rBtnEasy.Text = "Easy";
            this.rBtnEasy.UseVisualStyleBackColor = true;
            // 
            // rBtnIntermediate
            // 
            this.rBtnIntermediate.AutoSize = true;
            this.rBtnIntermediate.Font = new System.Drawing.Font("OCR A Extended", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rBtnIntermediate.Location = new System.Drawing.Point(142, 43);
            this.rBtnIntermediate.Name = "rBtnIntermediate";
            this.rBtnIntermediate.Size = new System.Drawing.Size(132, 27);
            this.rBtnIntermediate.TabIndex = 3;
            this.rBtnIntermediate.Text = "Intermed";
            this.rBtnIntermediate.UseVisualStyleBackColor = true;
            // 
            // rBtnHard
            // 
            this.rBtnHard.AutoSize = true;
            this.rBtnHard.Font = new System.Drawing.Font("OCR A Extended", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rBtnHard.Location = new System.Drawing.Point(142, 75);
            this.rBtnHard.Name = "rBtnHard";
            this.rBtnHard.Size = new System.Drawing.Size(80, 27);
            this.rBtnHard.TabIndex = 4;
            this.rBtnHard.Text = "Hard";
            this.rBtnHard.UseVisualStyleBackColor = true;
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // lblTimer
            // 
            this.lblTimer.BackColor = System.Drawing.Color.Black;
            this.lblTimer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTimer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTimer.Font = new System.Drawing.Font("OCR A Extended", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimer.ForeColor = System.Drawing.Color.Red;
            this.lblTimer.Location = new System.Drawing.Point(29, 116);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblTimer.Size = new System.Drawing.Size(68, 25);
            this.lblTimer.TabIndex = 5;
            // 
            // lblCounter
            // 
            this.lblCounter.BackColor = System.Drawing.Color.Black;
            this.lblCounter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCounter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblCounter.Font = new System.Drawing.Font("OCR A Extended", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCounter.ForeColor = System.Drawing.Color.Red;
            this.lblCounter.Location = new System.Drawing.Point(181, 116);
            this.lblCounter.Name = "lblCounter";
            this.lblCounter.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblCounter.Size = new System.Drawing.Size(68, 25);
            this.lblCounter.TabIndex = 6;
            // 
            // btnLeaderBoards
            // 
            this.btnLeaderBoards.BackColor = System.Drawing.Color.ForestGreen;
            this.btnLeaderBoards.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLeaderBoards.Font = new System.Drawing.Font("OCR A Extended", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLeaderBoards.Location = new System.Drawing.Point(14, 80);
            this.btnLeaderBoards.Name = "btnLeaderBoards";
            this.btnLeaderBoards.Size = new System.Drawing.Size(122, 33);
            this.btnLeaderBoards.TabIndex = 7;
            this.btnLeaderBoards.Text = "History";
            this.btnLeaderBoards.UseVisualStyleBackColor = false;
            this.btnLeaderBoards.Click += new System.EventHandler(this.btnLeaderBoards_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.YellowGreen;
            this.ClientSize = new System.Drawing.Size(280, 159);
            this.Controls.Add(this.btnLeaderBoards);
            this.Controls.Add(this.lblCounter);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.rBtnHard);
            this.Controls.Add(this.rBtnIntermediate);
            this.Controls.Add(this.rBtnEasy);
            this.Controls.Add(this.btnNewGame);
            this.Controls.Add(this.lblHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "MINKRAFT";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Button btnNewGame;
        private System.Windows.Forms.RadioButton rBtnEasy;
        private System.Windows.Forms.RadioButton rBtnIntermediate;
        private System.Windows.Forms.RadioButton rBtnHard;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.Label lblCounter;
        private System.Windows.Forms.Button btnLeaderBoards;
    }
}

