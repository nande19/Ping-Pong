using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ping_Pong
{
    public partial class Form1 : Form
    {
        // Variables to track mouse dragging for player and computer picture boxes

        private bool isDragging = false;
        private Point lastLocation;
        private bool isComputerDragging = false;
        private Point computerLastLocation;

        // Variables to control the movement of the ball

        int ballXSpeed = 4;
        int ballYSpeed = 4;
        int speed = 6; // Speed of computer paddle movement
        private readonly Random RandomNumber = new Random();
        int computerSpeedChange = 50;// Speed change interval for computer paddle movement
                                     
        // Variables to keep track of player and computer scores
        int playerScore = 0;
        int computerScore = 0;

        // Variables related to player and computer paddle speeds
        int playerSpeed = 8;
        int[] a = { 5, 6, 8, 9 };
        int[] b = { 10, 9, 8, 11, 12 };

        //--------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        public Form1()
        {
            InitializeComponent();

            // Set the minimum and maximum sizes to make the form fixed in height and resizable in width
            int size = 400; // Set the desired size for both width and height
            this.MinimumSize = new Size(size, size);
            this.MaximumSize = new Size(size, size);

            // Set the initial location of the computer picture box
            int computerX = size - 40; // Adjust the value as needed
            int computerY = size / 2 - 25; // Adjust the value as needed
            computer.Location = new Point(computerX, computerY);

            // Event handlers for mouse actions on player and computer picture boxes
            player.MouseDown += Player_MouseDown;
            player.MouseMove += Player_MouseMove;
            player.MouseUp += Player_MouseUp;
            computer.MouseDown += Computer_MouseDown;
            computer.MouseMove += Computer_MouseMove;
            computer.MouseUp += Computer_MouseUp;

            // Disable the game timer initially
            gameTmr.Enabled = false;

            // Enable double buffering for the form to reduce flickering during rendering
            this.DoubleBuffered = true;
        }
        //--------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Event handler for Start button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void Startbtn(object sender, EventArgs e)
        {
            // Enable the game timer
            gameTmr.Enabled = true;

            // Hide the start button
            startBtn.Visible = false;
        }
        //--------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Game timer event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameTimer(object sender, EventArgs e)
        {
            // Flag to track if a score has been recorded in the current cycle
            bool scoreRecorded = false;

            // Update ball position based on its speed
            ball.Top -= ballYSpeed;
            ball.Left -= ballXSpeed;

            // Update player and computer scores display
            this.Text = "Player Score: " + playerScore + "-- Computer Score: " + computerScore;

            // Check for collision with top or bottom boundary
            if (ball.Top < 0 || ball.Bottom > this.ClientSize.Height)
            {
                ballYSpeed = -ballYSpeed;
            }

            // Check for collision with left boundary and update computer score
            if (ball.Left < -2 && !scoreRecorded)
            {
                ball.Left = 300;
                ballXSpeed = -ballXSpeed;
                computerScore++;
                scoreRecorded = true; // Mark score as recorded to avoid multiple updates
            }

            // Check for collision with right boundary and update player score
            if (ball.Right > this.ClientSize.Width + 2 && !scoreRecorded)
            {
                ball.Left = 300;
                ballXSpeed = -ballXSpeed;
                playerScore++;
                scoreRecorded = true; // Mark score as recorded to avoid multiple updates
            }

            // Limit computer paddle movement within form boundaries
            if (computer.Top <= 1)
            {
                computer.Top = 0;
            }
            else if (computer.Bottom >= this.ClientSize.Height)
            {
                computer.Top = this.ClientSize.Height - computer.Height;
            }

            // Adjust computer paddle movement based on ball position
            if (ball.Top < computer.Top + (computer.Height / 2) && ball.Left > 300)
            {
                computer.Top -= speed;
            }
            if (ball.Top < computer.Top + (computer.Height / 2) && ball.Left > 300)
            {
                computer.Top -= speed;
            }
            if (ball.Top < computer.Top + (computer.Height / 2) && ball.Left > 300)
            {
                computer.Top += speed;
            }

            // Adjust computer paddle movement speed at regular intervals
            computerSpeedChange -= 1;

            if (computerSpeedChange < 0)
            {
                speed = a[RandomNumber.Next(a.Length)];
                computerSpeedChange = 50;
            }

            // Check collision between ball and player/computer paddles
            CheckCollision(ball, player, player.Right + 5);
            CheckCollision(ball, computer, computer.Left - 35);

            // Check for winner and display game over message
            if (computerScore >= 4)
            {
                GameOverDisplay("LOSER!");
            }
            else if (playerScore >= 4)
            {
                GameOverDisplay("WINNER!");
            }
        }

        //--------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Method to check collision between two picture boxes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void CheckCollision(PictureBox pic1, PictureBox pic2, int offset)
        {
            if (pic1.Bounds.IntersectsWith(pic2.Bounds))
            {
                pic1.Left = offset;

                int x = a[RandomNumber.Next(a.Length)];
                int y = a[RandomNumber.Next(a.Length)];

                if (ballXSpeed < 0)
                {
                    ballXSpeed = x;
                }
                else
                {
                    ballXSpeed = -x;
                }

                if (ballXSpeed < 0)
                {
                    ballXSpeed = -y;
                }
                else
                {
                    ballXSpeed = y;
                }
            }
        }


        //--------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Event handler for mouse down on player paddle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void Player_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (player.ClientRectangle.Contains(e.Location))
                {
                    isDragging = true;
                    lastLocation = e.Location;
                }
            }
        }
        //--------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Event handler for mouse move on player paddle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Player_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                int deltaY = e.Y - lastLocation.Y;
                int newY = player.Top + deltaY;

                // Limit the movement to stay within the bounds of the form
                newY = Math.Max(0, Math.Min(newY, this.ClientSize.Height - player.Height));

                player.Top = newY;
            }
        }
        //--------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Event handler for mouse up on player paddle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Player_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
            }
        }

        //--------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Event handler for mouse down on computer paddle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>


        private void Computer_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (computer.ClientRectangle.Contains(e.Location))
                {
                    isComputerDragging = true;
                    computerLastLocation = e.Location;
                }
            }
        }

        //--------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Event handler for mouse move on computer paddle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Computer_MouseMove(object sender, MouseEventArgs e)
        {
            if (isComputerDragging)
            {
                int deltaY = e.Y - computerLastLocation.Y;
                int newY = computer.Top + deltaY;

                // Limit the movement to stay within the bounds of the form
                newY = Math.Max(0, Math.Min(newY, this.ClientSize.Height - computer.Height));

                computer.Top = newY;
            }
        }

        //--------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Event handler for mouse up on computer paddle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Computer_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isComputerDragging = false;
            }
        }


        //--------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to display game over message and reset game variables
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void GameOverDisplay(string message)
        {
            gameTmr.Stop();
            MessageBox.Show(message, "Look: ");
            computerScore = 0;
            playerScore = 0;
            ballXSpeed = ballYSpeed = 4;
            computerSpeedChange = 50;
            gameTmr.Start();

            }
       
    }
}
        //---------------------------------------- END OF FILE -------------------------------------------------------//
