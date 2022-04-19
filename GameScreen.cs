using System;
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
        Timer timer = new Timer();      //New instance of the timer class
        private  Coordinates coordinates = new Coordinates(); //New instance of the coordinates class.

        bool MovingLeft;
        bool MovingRight;
        bool MovingUp;
        bool MovingDown;

        public GameScreen()
        {
            InitializeComponent();
            timer.Enabled = true;
            timer.Interval = 1000;  /* 1000 millisec */     //Timer ticks every 1000 ms
            timer.Tick += new EventHandler(timer1_Tick);    //Every time the timer ticks it calls timer1_tick. The eventhandler method is requered to call  Windows forms events
        }

        


        private void KeyIsDown(object sender, KeyEventArgs e)
        {

        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {

        }


        private void GameScreen_Load(object sender, EventArgs e)
        {

        }
        private int timesTicked;                //keeps track of how many times the timer has ticked
        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();           //refreshes the graphics shown in the picturebox
            timesTicked++;
        }


        private void updateScreen(object sender, PaintEventArgs e)          //finally got this bullshit to work. Turns out you have to use a picturebox to display the graphics and .Invalidate to update.
        {
            Graphics g = e.Graphics;
            // Create solid brush.
            SolidBrush blackBrush = new SolidBrush(Color.Black);
            // Create location and size of rectangle.
            int x = coordinates.X;
            int y = coordinates.Y;
            int width = 12;
            int height = 12;

            coordinates.X += 0;
            coordinates.Y += 15;

            // Fill rectangle to screen.
            g.FillRectangle(blackBrush, x, y, width, height);


        }



    }

}
