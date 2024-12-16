/*

 --------------------------
| Created by: Om Patel     |
| Date: December 10, 2024  |
| A simple air hockey game |
 --------------------------

*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirHockey
{
    public partial class Form1 : Form
    {
        //Global variables
        Rectangle player1 = new Rectangle(120, 305, 60, 60);
        Rectangle player1Inner = new Rectangle(135, 320, 30, 30);
        Rectangle player2 = new Rectangle(855, 305, 60, 60);
        Rectangle player2Inner = new Rectangle(870, 320, 30, 30);
        Rectangle puck = new Rectangle(495, 310, 45, 45);
        Rectangle rightSide = new Rectangle(7, 7, 400, 618);
        Rectangle rightGoal = new Rectangle(-55, 245, 145, 145);
        Rectangle rightGoalRect = new Rectangle(0, 253, 15, 129);
        Rectangle leftSide = new Rectangle(630, 7, 400, 618);
        Rectangle leftGoal = new Rectangle(945, 245, 145, 145);
        Rectangle leftGoalRect = new Rectangle(1023, 253, 15, 129);
        Rectangle middleLine = new Rectangle(460, 275, 120, 120);

        int p1Score = 0;
        int p2Score = 0;

        int playerSpeed = 4;
        int puckXSpeed = 7;
        int puckYSpeed = 7;

        bool wPressed = false;
        bool sPressed = false;
        bool aPressed = false;
        bool dPressed = false;
        bool upPressed = false;
        bool downPressed = false;
        bool leftPressed = false;
        bool rightPressed = false;

        SolidBrush cyanBrush = new SolidBrush(Color.Cyan);
        Pen cyanPen = new Pen(Color.Cyan);
        SolidBrush limeBrush = new SolidBrush(Color.Lime);
        Pen limePen = new Pen(Color.Lime);
        SolidBrush blackBrush = new SolidBrush(Color.Black);
        Pen blackPen = new Pen(Color.Black);
        Pen whitePen = new Pen(Color.White);
        Pen purplePen = new Pen(Color.Purple);
        SolidBrush redBrush = new SolidBrush(Color.Red);
        SolidBrush whiteBrush = new SolidBrush(Color.White);

        SoundPlayer puckHit = new SoundPlayer(Properties.Resources.puckMovement);
        SoundPlayer puckGoal = new SoundPlayer(Properties.Resources.puckGoal);
        SoundPlayer winner = new SoundPlayer(Properties.Resources.winnerDrumRoll);

        public Form1()
        {
            InitializeComponent();

            gameTimer.Start();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wPressed = true;
                    break;
                case Keys.S:
                    sPressed = true;
                    break;
                case Keys.A:
                    aPressed = true;
                    break;
                case Keys.D:
                    dPressed = true;
                    break;
                case Keys.Up:
                    upPressed = true;
                    break;
                case Keys.Down:
                    downPressed = true;
                    break;
                case Keys.Left:
                    leftPressed = true;
                    break;
                case Keys.Right:
                    rightPressed = true;
                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wPressed = false;
                    break;
                case Keys.S:
                    sPressed = false;
                    break;
                case Keys.A:
                    aPressed = false;
                    break;
                case Keys.D:
                    dPressed = false;
                    break;
                case Keys.Up:
                    upPressed = false;
                    break;
                case Keys.Down:
                    downPressed = false;
                    break;
                case Keys.Left:
                    leftPressed = false;
                    break;
                case Keys.Right:
                    rightPressed = false;
                    break;
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            puck.X += puckXSpeed;
            puck.Y += puckYSpeed;

            if (wPressed == true)
            {
                player1.Y -= playerSpeed;
                player1Inner.Y -= playerSpeed;
            }

            if (sPressed == true)
            {
                player1.Y += playerSpeed;
                player1Inner.Y += playerSpeed;
            }

            if (dPressed == true)
            {
                player1.X += playerSpeed;
                player1Inner.X += playerSpeed;
            }

            if (aPressed == true)
            {
                player1.X -= playerSpeed;
                player1Inner.X -= playerSpeed;
            }

            if (upPressed == true)
            {
                player2.Y -= playerSpeed;
                player2Inner.Y -= playerSpeed;
            }

            if (downPressed == true)
            {
                player2.Y += playerSpeed;
                player2Inner.Y += playerSpeed;
            }

            if (leftPressed == true)
            {
                player2.X -= playerSpeed;
                player2Inner.X -= playerSpeed;
            }

            if (rightPressed == true)
            {
                player2.X += playerSpeed;
                player2Inner.X += playerSpeed;
            }

            if (puck.X < 5 || puck.X > this.Width - puck.Width)
            {
                puckXSpeed *= -1;
            }

            if (puck.Y < 5 || puck.Y > this.Height - puck.Height)
            {
                puckYSpeed *= -1;
            }

            if (puck.IntersectsWith(leftGoalRect))
            {
                puckGoal.Play();

                p1Score += 1;
                p1ScoreLabel.Text = $"{p1Score}";

                puck.X = 495;
                puck.Y = 310;
                puckXSpeed *= -1;
            }

            if (puck.IntersectsWith(rightGoalRect))
            {
                puckGoal.Play();

                p2Score += 1;
                p2ScoreLabel.Text = $"{p2Score}";

                puck.X = 495;
                puck.Y = 310;
                puckXSpeed *= -1;
            }

            if (puck.IntersectsWith(player1))
            {
                puckHit.Play();

                Rectangle topRect = new Rectangle(player1.X + 10, player1.Y + 3, 40, 5);
                Rectangle rightRect = new Rectangle(player1.X + 50, player1.Y + 10, 5, 40);
                Rectangle leftRect = new Rectangle(player1.X + 5, player1.Y + 10, 5, 40);
                Rectangle bottomRect = new Rectangle(player1.X + 10, player1.Y + 52, 40, 5);

                if (puck.IntersectsWith(leftRect))
                {
                    puckXSpeed *= -1;
                    puck.X = player1.X - puck.Width;
                }

                if (puck.IntersectsWith(rightRect))
                {
                    puckXSpeed *= -1;
                    puck.X = player1.X + player1.Width;
                }

                if (puck.IntersectsWith(topRect))
                {
                    puckYSpeed *= -1;
                    puck.Y = player1.Y - puck.Height;
                }

                if (puck.IntersectsWith(bottomRect))
                {
                    puckYSpeed = -puckYSpeed;
                    puck.Y = player1.Y + player1.Height;
                }
            }

            if (puck.IntersectsWith(player2))
            {
                puckHit.Play();

                Rectangle topRect = new Rectangle(player2.X + 10, player2.Y + 3, 40, 5);
                Rectangle rightRect = new Rectangle(player2.X + 50, player2.Y + 10, 5, 40);
                Rectangle leftRect = new Rectangle(player2.X + 5, player2.Y + 10, 5, 40);
                Rectangle bottomRect = new Rectangle(player2.X + 10, player2.Y + 52, 40, 5);

                if (puck.IntersectsWith(leftRect))
                {
                    puckXSpeed *= -1;
                    puck.X = player2.X - puck.Width;
                }

                if (puck.IntersectsWith(rightRect))
                {
                    puckXSpeed *= -1;
                    puck.X = player2.X + player2.Width;
                }

                if (puck.IntersectsWith(topRect))
                {
                    puckYSpeed *= -1;
                    puck.Y = player2.Y - puck.Height;
                }

                if (puck.IntersectsWith(bottomRect))
                {
                    puckYSpeed = -puckYSpeed;
                    puck.Y = player2.Y + player2.Height;
                }
            }

            if (p1Score == 3)
            {
                winner.Play();

                puck.X = 495;
                puck.Y = 310;

                player1.X = 120;
                player1.Y = 305;

                player1Inner.X = 135;
                player1Inner.Y = 320;

                player2.X = 855;
                player2.Y = 305;

                player2Inner.X = 870;
                player2Inner.Y = player1Inner.Y;

                outputLabel.Text = "Player1 Wins!";
            }

            if (p2Score == 3)
            {
                winner.Play();

                puck.X = 495;
                puck.Y = 310;

                player1.X = 120;
                player1.Y = 305;

                player1Inner.X = 135;
                player1Inner.Y = 320;

                player2.X = 855;
                player2.Y = 305;

                player2Inner.X = 870;
                player2Inner.Y = player1Inner.Y;

                outputLabel.Text = "Player2 Wins!";
            }

            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //
            e.Graphics.DrawRectangle(cyanPen, rightSide);
            e.Graphics.DrawEllipse(cyanPen, rightGoal);
            //
            e.Graphics.DrawRectangle(limePen, leftSide);
            e.Graphics.DrawEllipse(limePen, leftGoal);
            //
            purplePen.Width = 15;
            e.Graphics.DrawLine(purplePen, 520, 0, 520, 800);
            purplePen.Width = 10;
            e.Graphics.DrawEllipse(purplePen, middleLine);
            //
            e.Graphics.FillRectangle(blackBrush, leftGoalRect);
            e.Graphics.FillRectangle(blackBrush, rightGoalRect);
            //
            cyanPen.Width = 15;
            e.Graphics.FillEllipse(cyanBrush, player1);
            e.Graphics.DrawEllipse(blackPen, player1Inner);
            //
            limePen.Width = 15;
            e.Graphics.FillEllipse(limeBrush, player2);
            e.Graphics.DrawEllipse(blackPen, player2Inner);
            //
            e.Graphics.FillEllipse(redBrush, puck);
        }

    }
}
