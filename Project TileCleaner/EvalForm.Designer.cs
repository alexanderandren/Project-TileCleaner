namespace Project_TileCleaner
{
    partial class EvalForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EvalForm));
            this.lblGreeting = new System.Windows.Forms.Label();
            this.btnOKRetry = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.inputName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblGreeting
            // 
            this.lblGreeting.AutoSize = true;
            this.lblGreeting.Font = new System.Drawing.Font("OCR A Extended", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGreeting.Location = new System.Drawing.Point(12, 9);
            this.lblGreeting.Name = "lblGreeting";
            this.lblGreeting.Size = new System.Drawing.Size(124, 25);
            this.lblGreeting.TabIndex = 1;
            this.lblGreeting.Text = "MinKraft";
            // 
            // btnOKRetry
            // 
            this.btnOKRetry.BackColor = System.Drawing.Color.ForestGreen;
            this.btnOKRetry.DialogResult = System.Windows.Forms.DialogResult.Retry;
            this.btnOKRetry.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOKRetry.Font = new System.Drawing.Font("OCR A Extended", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOKRetry.Location = new System.Drawing.Point(36, 153);
            this.btnOKRetry.Name = "btnOKRetry";
            this.btnOKRetry.Size = new System.Drawing.Size(122, 63);
            this.btnOKRetry.TabIndex = 2;
            this.btnOKRetry.Text = "Yey!";
            this.btnOKRetry.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.ForestGreen;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("OCR A Extended", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(233, 153);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(122, 63);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // inputName
            // 
            this.inputName.BackColor = System.Drawing.Color.Black;
            this.inputName.Font = new System.Drawing.Font("OCR A Extended", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputName.ForeColor = System.Drawing.Color.Red;
            this.inputName.Location = new System.Drawing.Point(103, 114);
            this.inputName.Name = "inputName";
            this.inputName.Size = new System.Drawing.Size(182, 27);
            this.inputName.TabIndex = 4;
            // 
            // EvalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.YellowGreen;
            this.ClientSize = new System.Drawing.Size(392, 228);
            this.Controls.Add(this.inputName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOKRetry);
            this.Controls.Add(this.lblGreeting);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EvalForm";
            this.Text = "EvalForm";
            this.Enter += new System.EventHandler(this.EvalForm_Enter);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblGreeting;
        private System.Windows.Forms.Button btnOKRetry;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox inputName;
    }
}