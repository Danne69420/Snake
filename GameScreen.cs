﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public partial class GameScreen : Form
    {
        Timer timer = new Timer();
        public GameScreen()
        {
            InitializeComponent();
            timer.Enabled = true;
            timer.Interval = 1000;  /* 1000 millisec */
            timer.Tick += new EventHandler(timer1_Tick);
        }

        

        private void UpdateGraphics(object sender, PaintEventArgs e)
        {
            //// Create solid brush.
            //SolidBrush blackBrush = new SolidBrush(Color.Black);
            //Coordinates coordinates = new Coordinates();
            //// Create location and size of rectangle.
            //int x = coordinates.X;
            //int y = coordinates.Y;
            //int width = 12;
            //int height = 12;

            //coordinates.X += 15;
            //coordinates.Y += 15;

            //// Fill rectangle to screen.
            //e.Graphics.FillRectangle(blackBrush, x, y, width, height);
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {

        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void GameScreen_Load(object sender, EventArgs e)
        {
            label1.Width = 10;
            label1.Height = 10;
            label1.BackColor = Color.Black;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Sort of works. This code executes everytime the timer ticks (currently every 1000 ms)
            coordinates.X += 10;        //ten is added to the x coordinate
            coordinates.Y += 10;        //ten is added to the y coordinate

            label1.Left = coordinates.X;    //Left edge of the label is set to the x coordinate
            label1.Top = coordinates.Y;     //tob edge of the label is set to the y coordinate
            
        }

          private  Coordinates coordinates = new Coordinates();
        private void OnPaint(object sender, PaintEventArgs e)
        {
            //Graphics g = e.Graphics;
            //// Create solid brush.
            //SolidBrush blackBrush = new SolidBrush(Color.Black);
            //// Create location and size of rectangle.
            //int x = coordinates.X;
            //int y = coordinates.Y;
            //int width = 12;
            //int height = 12;

            //coordinates.X += 15;
            //coordinates.Y += 15;

            //// Fill rectangle to screen.
            //g.FillRectangle(blackBrush, x, y, width, height);
            //base.OnPaint(e);
        }

       

        //private void TimerCallback(object sender, EventArgs e) //Does not currently do anything. 
        //{
        //    coordinates.X += 10;
        //    coordinates.Y += 10;
        //    this.Invalidate();
        //    return;
        //}
    }

}
