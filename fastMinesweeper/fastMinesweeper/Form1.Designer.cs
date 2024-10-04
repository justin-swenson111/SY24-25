namespace fastMinesweeper
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pnlBody = new System.Windows.Forms.Panel();
            this.minePic = new System.Windows.Forms.PictureBox();
            this.FlagPic = new System.Windows.Forms.PictureBox();
            this.txtScore = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.minePic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FlagPic)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBody
            // 
            this.pnlBody.Location = new System.Drawing.Point(12, 101);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(381, 337);
            this.pnlBody.TabIndex = 0;
            // 
            // minePic
            // 
            this.minePic.Image = ((System.Drawing.Image)(resources.GetObject("minePic.Image")));
            this.minePic.Location = new System.Drawing.Point(390, 88);
            this.minePic.Name = "minePic";
            this.minePic.Size = new System.Drawing.Size(10, 10);
            this.minePic.TabIndex = 1;
            this.minePic.TabStop = false;
            this.minePic.Visible = false;
            // 
            // FlagPic
            // 
            this.FlagPic.Image = ((System.Drawing.Image)(resources.GetObject("FlagPic.Image")));
            this.FlagPic.Location = new System.Drawing.Point(390, 72);
            this.FlagPic.Name = "FlagPic";
            this.FlagPic.Size = new System.Drawing.Size(10, 10);
            this.FlagPic.TabIndex = 2;
            this.FlagPic.TabStop = false;
            this.FlagPic.Visible = false;
            // 
            // txtScore
            // 
            this.txtScore.AutoSize = true;
            this.txtScore.Location = new System.Drawing.Point(203, 35);
            this.txtScore.Name = "txtScore";
            this.txtScore.Size = new System.Drawing.Size(44, 16);
            this.txtScore.TabIndex = 3;
            this.txtScore.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 450);
            this.Controls.Add(this.txtScore);
            this.Controls.Add(this.FlagPic);
            this.Controls.Add(this.minePic);
            this.Controls.Add(this.pnlBody);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.minePic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FlagPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.PictureBox minePic;
        private System.Windows.Forms.PictureBox FlagPic;
        private System.Windows.Forms.Label txtScore;
    }
}

