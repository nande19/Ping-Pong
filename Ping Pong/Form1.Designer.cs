namespace Ping_Pong
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
            this.components = new System.ComponentModel.Container();
            this.player = new System.Windows.Forms.PictureBox();
            this.computer = new System.Windows.Forms.PictureBox();
            this.ball = new System.Windows.Forms.PictureBox();
            this.gameTmr = new System.Windows.Forms.Timer(this.components);
            this.startBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.computer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ball)).BeginInit();
            this.SuspendLayout();
            // 
            // player
            // 
            this.player.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.player.Location = new System.Drawing.Point(12, 65);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(28, 101);
            this.player.TabIndex = 0;
            this.player.TabStop = false;
            // 
            // computer
            // 
            this.computer.BackColor = System.Drawing.Color.Purple;
            this.computer.Location = new System.Drawing.Point(353, 65);
            this.computer.Name = "computer";
            this.computer.Size = new System.Drawing.Size(28, 101);
            this.computer.TabIndex = 1;
            this.computer.TabStop = false;
            // 
            // ball
            // 
            this.ball.Image = global::Ping_Pong.Properties.Resources.Basketball_Ball_PNG_Clipart;
            this.ball.Location = new System.Drawing.Point(162, 102);
            this.ball.Name = "ball";
            this.ball.Size = new System.Drawing.Size(30, 30);
            this.ball.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ball.TabIndex = 2;
            this.ball.TabStop = false;
            // 
            // gameTmr
            // 
            this.gameTmr.Enabled = true;
            this.gameTmr.Interval = 20;
            this.gameTmr.Tick += new System.EventHandler(this.GameTimer);
            // 
            // startBtn
            // 
            this.startBtn.BackColor = System.Drawing.Color.Green;
            this.startBtn.Location = new System.Drawing.Point(141, 102);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(100, 36);
            this.startBtn.TabIndex = 6;
            this.startBtn.Text = "Start";
            this.startBtn.UseVisualStyleBackColor = false;
            this.startBtn.Click += new System.EventHandler(this.Startbtn);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(393, 270);
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.ball);
            this.Controls.Add(this.computer);
            this.Controls.Add(this.player);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Player: 0 -- Computer: 0";
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.computer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ball)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox player;
        private System.Windows.Forms.PictureBox computer;
        private System.Windows.Forms.PictureBox ball;
        private System.Windows.Forms.Timer gameTmr;
        private System.Windows.Forms.Button startBtn;
    }
}

