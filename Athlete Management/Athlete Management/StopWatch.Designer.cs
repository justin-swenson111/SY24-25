namespace Athlete_Management
{
    partial class StopWatch
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
            this.timerLbl = new System.Windows.Forms.Label();
            this.startBtn = new System.Windows.Forms.Button();
            this.stopBtn = new System.Windows.Forms.Button();
            this.resetBtn = new System.Windows.Forms.Button();
            this.addBtn = new System.Windows.Forms.Button();
            this.athleteCombo = new System.Windows.Forms.ComboBox();
            this.raceCombo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // timerLbl
            // 
            this.timerLbl.AutoSize = true;
            this.timerLbl.Location = new System.Drawing.Point(173, 87);
            this.timerLbl.Name = "timerLbl";
            this.timerLbl.Size = new System.Drawing.Size(44, 16);
            this.timerLbl.TabIndex = 0;
            this.timerLbl.Text = "label1";
            // 
            // startBtn
            // 
            this.startBtn.Location = new System.Drawing.Point(176, 147);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(75, 23);
            this.startBtn.TabIndex = 1;
            this.startBtn.Text = "start";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // stopBtn
            // 
            this.stopBtn.Location = new System.Drawing.Point(257, 147);
            this.stopBtn.Name = "stopBtn";
            this.stopBtn.Size = new System.Drawing.Size(75, 23);
            this.stopBtn.TabIndex = 2;
            this.stopBtn.Text = "stop";
            this.stopBtn.UseVisualStyleBackColor = true;
            this.stopBtn.Click += new System.EventHandler(this.stopBtn_Click);
            // 
            // resetBtn
            // 
            this.resetBtn.Location = new System.Drawing.Point(338, 147);
            this.resetBtn.Name = "resetBtn";
            this.resetBtn.Size = new System.Drawing.Size(75, 23);
            this.resetBtn.TabIndex = 3;
            this.resetBtn.Text = "reset";
            this.resetBtn.UseVisualStyleBackColor = true;
            this.resetBtn.Click += new System.EventHandler(this.resetBtn_Click);
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(443, 124);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(75, 23);
            this.addBtn.TabIndex = 4;
            this.addBtn.Text = "add time";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click_1);
            // 
            // athleteCombo
            // 
            this.athleteCombo.FormattingEnabled = true;
            this.athleteCombo.Location = new System.Drawing.Point(535, 124);
            this.athleteCombo.Name = "athleteCombo";
            this.athleteCombo.Size = new System.Drawing.Size(121, 24);
            this.athleteCombo.TabIndex = 6;
            this.athleteCombo.SelectedIndexChanged += new System.EventHandler(this.athleteCombo_SelectedIndexChanged);
            // 
            // raceCombo
            // 
            this.raceCombo.FormattingEnabled = true;
            this.raceCombo.Location = new System.Drawing.Point(663, 124);
            this.raceCombo.Name = "raceCombo";
            this.raceCombo.Size = new System.Drawing.Size(121, 24);
            this.raceCombo.TabIndex = 7;
            // 
            // StopWatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.raceCombo);
            this.Controls.Add(this.athleteCombo);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.resetBtn);
            this.Controls.Add(this.stopBtn);
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.timerLbl);
            this.Name = "StopWatch";
            this.Text = "StopWatch";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label timerLbl;
        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.Button stopBtn;
        private System.Windows.Forms.Button resetBtn;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.ComboBox athleteCombo;
        private System.Windows.Forms.ComboBox raceCombo;
    }
}