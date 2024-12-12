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
        Rectangle player1Top = new Rectangle(123, 305, 53, 5);
        Rectangle player1Right = new Rectangle(175, 308,5, 53);
        Rectangle player1Left = new Rectangle(120, 308, 5, 53);
        Rectangle player1Bottom = new Rectangle(123, 360, 53, 5);
        Rectangle player2 = new Rectangle(855, 305, 60, 60);
        Rectangle player2Top = new Rectangle(858, 305, 53, 5);
        Rectangle player2Right = new Rectangle(910, 308, 5, 53);
        Rectangle player2Left = new Rectangle(853, 308, 5, 53);
        Rectangle player2Bottom = new Rectangle(858, 360, 53, 5);
        Rectangle player2Inner = new Rectangle(870, 320, 30, 30);
        Rectangle puck = new Rectangle(495, 310, 50, 50);
        Rectangle rightSide = new Rectangle(7, 7, 400, 618);
        Rectangle rightGoal = new Rectangle(-55, 250, 150, 150);
        Rectangle rightGoalRect = new Rectangle(0, 258, 15, 135);
        Rectangle leftSide = new Rectangle(630, 7, 400, 618);
        Rectangle leftGoal = new Rectangle(950, 250, 150, 150);
        Rectangle leftGoalRect = new Rectangle(1023, 258, 15, 135);
        Rectangle middleLine = new Rectangle(460, 275, 120, 120);

        int p1Score = 0;
        int p2Score = 0;

        int playerSpeed = 10;
        int puckXSpeed = 7;
        int puckYSpeed = 10;

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

            if (wPressed == true && player1.Y > 0)
            {
                player1.Y -= playerSpeed;
                player1Top.Y -= playerSpeed;
                player1Bottom.Y -= playerSpeed;
                player1Left.Y -= playerSpeed;
                player1Right.Y -= playerSpeed;
                player1Inner.Y -= playerSpeed;
            }

            if (sPressed == true && player1.Y > 0)
            {
                player1.Y += playerSpeed;
                player1Top.Y += playerSpeed;
                player1Bottom.Y += playerSpeed;
                player1Left.Y += playerSpeed;
                player1Right.Y += playerSpeed;
                player1Inner.Y += playerSpeed;
            }

            if (dPressed == true && player1.Y > 0)
            {
                player1.X += playerSpeed;
                player1Top.X += playerSpeed;
                player1Bottom.X += playerSpeed;
                player1Left.X += playerSpeed;
                player1Right.X += playerSpeed;
                player1Inner.X += playerSpeed;
            }

            if (aPressed == true && player1.Y > 0)
            {
                player1.X -= playerSpeed;
                player1Top.X -= playerSpeed;
                player1Bottom.X -= playerSpeed;
                player1Left.X -= playerSpeed;
                player1Right.X -= playerSpeed;
                player1Inner.X -= playerSpeed;
            }

            if (upPressed == true && player1.Y > 0)
            {
                player2.Y -= playerSpeed;
                player2Top.Y -= playerSpeed;
                player2Bottom.Y -= playerSpeed;
                player2Left.Y -= playerSpeed;
                player2Right.Y -= playerSpeed;
                player2Inner.Y -= playerSpeed;
            }

            if (downPressed == true && player1.Y > 0)
            {
                player2.Y += playerSpeed;
                player2Top.Y += playerSpeed;
                player2Bottom.Y += playerSpeed;
                player2Left.Y += playerSpeed;
                player2Right.Y += playerSpeed;
                player2Inner.Y += playerSpeed;
            }

            if (leftPressed == true && player1.Y > 0)
            {
                player2.X -= playerSpeed;
                player2Top.X -= playerSpeed;
                player2Bottom.X -= playerSpeed;
                player2Left.X -= playerSpeed;
                player2Right.X -= playerSpeed;
                player2Inner.X -= playerSpeed;
            }

            if (rightPressed == true && player1.Y > 0)
            {
                player2.X += playerSpeed;
                player2Top.X += playerSpeed;
                player2Bottom.X += playerSpeed;
                player2Left.X += playerSpeed;
                player2Right.X += playerSpeed;
                player2Inner.X += playerSpeed;
            }

            if (puck.X < 0 || puck.X > this.Width - puck.Width)
            {
                puckXSpeed *= -1;
            }

            if (puck.Y < 0 || puck.Y > this.Height - puck.Height)
            {
                puckYSpeed *= -1;
            }

            if (puck.IntersectsWith(leftGoalRect))
            {
                p1Score += 1;
                p1ScoreLabel.Text = $"{p1Score}";

                puck.X = 495;
                puck.Y = 310;
                puckXSpeed *= -1;
            }

            if (puck.IntersectsWith(rightGoalRect))
            {
                p2Score += 1;
                p2ScoreLabel.Text = $"{p2Score}";

                puck.X = 495;
                puck.Y = 310;
                puckXSpeed *= -1;
            }

            if (puck.IntersectsWith(player1Left))
            {
                puckXSpeed *= -1;
                puck.X = player1.X - puck.Width;
            }

            if (puck.IntersectsWith(player1Right))
            {
                puckXSpeed *= -1;
                puck.X = player1.X + puck.Width;
            }

            if (puck.IntersectsWith(player1Top))
            {
                puckYSpeed *= -1;
                puck.Y = player1.Y + puck.Height;
            }

            if (puck.IntersectsWith(player1Bottom))
            {
                puckYSpeed = -puckYSpeed;
                puck.Y = player1.Y - puck.Height;
            }

            if (puck.IntersectsWith(player2Left))
            {
                puckXSpeed *= -1;
                puck.X = player2.X - puck.Width;
            }

            if (puck.IntersectsWith(player2Right))
            {
                puckXSpeed *= -1;
                puck.X = player2.X + puck.Width;
            }

            if (puck.IntersectsWith(player2Top))
            {
                puckYSpeed *= -1;
                puck.Y = player2.Y + puck.Height;
            }

            if (puck.IntersectsWith(player2Bottom))
            {
                puckYSpeed *= -1;
                puck.Y = player2.Y - puck.Height;
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
            e.Graphics.FillRectangle(limeBrush, rightGoalRect);
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
            //
            e.Graphics.FillRectangle(whiteBrush, player1Top);
            e.Graphics.FillRectangle(whiteBrush, player1Right);
            e.Graphics.FillRectangle(whiteBrush, player1Left);
            e.Graphics.FillRectangle(whiteBrush, player1Bottom);
            //
            e.Graphics.FillRectangle(whiteBrush, player2Top);
            e.Graphics.FillRectangle(whiteBrush, player2Right);
            e.Graphics.FillRectangle(whiteBrush, player2Left);
            e.Graphics.FillRectangle(whiteBrush, player2Bottom);
        }

    }
}
