namespace MySnakeUI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblScore = new System.Windows.Forms.Label();
            this.lblScoreNum = new System.Windows.Forms.Label();
            this.lblTimer = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblGameOver = new System.Windows.Forms.Label();
            this.lblBestScore = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblWin = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(12, 85);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(400, 400);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblScore.ForeColor = System.Drawing.Color.White;
            this.lblScore.Location = new System.Drawing.Point(12, 46);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(83, 37);
            this.lblScore.TabIndex = 1;
            this.lblScore.Text = "Счет:";
            // 
            // lblScoreNum
            // 
            this.lblScoreNum.AutoSize = true;
            this.lblScoreNum.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblScoreNum.ForeColor = System.Drawing.Color.White;
            this.lblScoreNum.Location = new System.Drawing.Point(133, 46);
            this.lblScoreNum.Name = "lblScoreNum";
            this.lblScoreNum.Size = new System.Drawing.Size(32, 37);
            this.lblScoreNum.TabIndex = 2;
            this.lblScoreNum.Text = "0";
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTimer.ForeColor = System.Drawing.Color.LightGray;
            this.lblTimer.Location = new System.Drawing.Point(291, 25);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(121, 37);
            this.lblTimer.TabIndex = 4;
            this.lblTimer.Text = "00:00:00";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.LightGray;
            this.label2.Location = new System.Drawing.Point(181, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 37);
            this.label2.TabIndex = 3;
            this.label2.Text = "Время:";
            // 
            // lblGameOver
            // 
            this.lblGameOver.AutoSize = true;
            this.lblGameOver.BackColor = System.Drawing.Color.White;
            this.lblGameOver.Font = new System.Drawing.Font("Segoe UI Semibold", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblGameOver.ForeColor = System.Drawing.Color.Red;
            this.lblGameOver.Location = new System.Drawing.Point(21, 242);
            this.lblGameOver.Name = "lblGameOver";
            this.lblGameOver.Size = new System.Drawing.Size(382, 65);
            this.lblGameOver.TabIndex = 5;
            this.lblGameOver.Text = "Игра окончена!";
            this.lblGameOver.Visible = false;
            // 
            // lblBestScore
            // 
            this.lblBestScore.AutoSize = true;
            this.lblBestScore.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblBestScore.ForeColor = System.Drawing.Color.Gold;
            this.lblBestScore.Location = new System.Drawing.Point(133, 9);
            this.lblBestScore.Name = "lblBestScore";
            this.lblBestScore.Size = new System.Drawing.Size(32, 37);
            this.lblBestScore.TabIndex = 7;
            this.lblBestScore.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.Gold;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 37);
            this.label3.TabIndex = 6;
            this.label3.Text = "Рекорд:";
            // 
            // lblWin
            // 
            this.lblWin.AutoSize = true;
            this.lblWin.BackColor = System.Drawing.Color.White;
            this.lblWin.Font = new System.Drawing.Font("Segoe UI Semibold", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblWin.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lblWin.Location = new System.Drawing.Point(37, 242);
            this.lblWin.Name = "lblWin";
            this.lblWin.Size = new System.Drawing.Size(345, 65);
            this.lblWin.TabIndex = 8;
            this.lblWin.Text = "Вы победили!";
            this.lblWin.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(422, 497);
            this.Controls.Add(this.lblWin);
            this.Controls.Add(this.lblBestScore);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblGameOver);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblScoreNum);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Змейка";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private Label lblScore;
        private Label lblScoreNum;
        private Label lblTimer;
        private Label label2;
        private Label lblGameOver;
        private Label lblBestScore;
        private Label label3;
        private Label lblWin;
    }
}