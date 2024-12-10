/*
Created by: Om Patel
Date: December 10, 2024
A simple air hockey game
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
        Rectangle player2 = new Rectangle(855, 305, 60, 60);
        Rectangle player2Inner = new Rectangle(870, 320, 30, 30);
        Rectangle puck = new Rectangle(495, 310, 50, 50);
        Rectangle rightSide = new Rectangle(7, 7, 400, 618);
        Rectangle rightGoal = new Rectangle(-55, 250, 150, 150);
        Rectangle leftSide = new Rectangle(630, 7, 400, 618);
        Rectangle leftGoal = new Rectangle(950, 250, 150, 150);
        Rectangle middleLine = new Rectangle(460, 275, 120, 120);

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

        public Form1()
        {
            InitializeComponent();
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            cyanPen.Width = 15;
            e.Graphics.DrawRectangle(cyanPen, rightSide);
            e.Graphics.FillEllipse(cyanBrush, player1);
            e.Graphics.DrawEllipse(blackPen, player1Inner);
            e.Graphics.DrawEllipse(cyanPen, rightGoal);
            //
            limePen.Width = 15;
            e.Graphics.DrawRectangle(limePen, leftSide);
            e.Graphics.FillEllipse(limeBrush, player2);
            e.Graphics.DrawEllipse(blackPen, player2Inner);
            e.Graphics.DrawEllipse(limePen, leftGoal);
            //
            purplePen.Width = 15;
            e.Graphics.DrawLine(purplePen, 520, 0, 520, 800);
            purplePen.Width = 10;
            e.Graphics.DrawEllipse(purplePen, middleLine);
            //
            e.Graphics.FillEllipse(redBrush, puck);
        }
    }
}
