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

        bool EndSCreenShowing = false;

        enum Directions         //This is an enumerable variabel. It works sort of like a class. First i declare what values the enum can have. 
        {
            Left,
            Right,
            Up,
            Down,
        }
        Directions direction = Directions.Down;         //Then i make an object. The default direction is down. 
        public GameScreen()
        {
            InitializeComponent();
            timer.Enabled = true;
            timer.Interval = 1000;  /* 1000 millisec */     //Timer ticks every 1000 ms

            timer.Tick += new EventHandler(timer1_Tick);    //Every time the timer ticks it calls timer1_tick. The eventhandler method is requered to call  Windows forms events
        }

        


        private void KeyIsDown(object sender, KeyEventArgs e)
        {
                Input.ChangeState(e.KeyCode, true);
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            Input.ChangeState(e.KeyCode, false);
        }


        private void GameScreen_Load(object sender, EventArgs e)
        {

        }
        private int timesTicked;                //keeps track of how many times the timer has ticked


        //IDEA: Right now the program only reads input at the exact moment the timer ticks. A possible fix could be to have a seperate timer ticking very frequently read the input while using this timer to still only update the graphics every second.
        private void timer1_Tick(object sender, EventArgs e)    //For some reason this seems to tick twice every other tick
        {

            if(coordinates.X < 0 | coordinates.X > pictureBox1.Width | coordinates.Y < 0 | coordinates.Y > pictureBox1.Height)          //If you touch the wall
            {
                this.Hide();
                Die();      //You die
            }

            if (timesTicked % 2 == 0)   //This makes it only do stuff every when timesTicked is evenly divisible by 2. this makes it skip every fourth tick however
            {
                if (Input.KeyPress(Keys.Right) && direction != Directions.Left)     //If the right arrow key is pressed
                {
                    direction = Directions.Right;
                }
                if(Input.KeyPress(Keys.Left) && direction != Directions.Right)
                {
                    direction = Directions.Left;
                }
                if(Input.KeyPress(Keys.Up)&& direction != Directions.Down)
                {
                    direction = Directions.Up;
                }
                if(Input.KeyPress(Keys.Down)&& direction != Directions.Up)
                {
                    direction = Directions.Down;
                }
                pictureBox1.Invalidate();           //refreshes the graphics shown in the picturebox
            }
            else if (timesTicked % 3 == 0)  //This fixes it skipping every fourth tick. 
            {
                if (Input.KeyPress(Keys.Right) && direction != Directions.Left)     //If the right arrow key is pressed
                {
                    direction = Directions.Right;
                }
                if (Input.KeyPress(Keys.Left) && direction != Directions.Right)
                {
                    direction = Directions.Left;
                }
                if (Input.KeyPress(Keys.Up) && direction != Directions.Down)
                {
                    direction = Directions.Up;
                }
                if (Input.KeyPress(Keys.Down) && direction != Directions.Up)
                {
                    direction = Directions.Down;
                }
                pictureBox1.Invalidate();
            }
            timesTicked++;
        }


        private void updateScreen(object sender, PaintEventArgs e)          //finally got this bullshit to work. Turns out you have to use a picturebox to display the graphics and .Invalidate to update.
        {

            Graphics g = e.Graphics;
            // Create solid brush.
            SolidBrush blackBrush = new SolidBrush(Color.Black);
            // Create location and size of rectangle.
            int x = coordinates.X;          //x and y are set to the current coordinates
            int y = coordinates.Y;
            int width = 15;
            int height = 15;
            // Fill rectangle to screen.
            g.FillEllipse(blackBrush, x, y, width, height);         //A circle is drawn using the variables declared above

            switch (direction)          //Depending on which direction the snake is moving the coordinates are updated differently
            {
                case Directions.Down:
                    coordinates.Y += 15;
                    break;
                case Directions.Up:
                    coordinates.Y -= 15;
                    break;
                case Directions.Right:
                    coordinates.X += 15;
                    break;
                case Directions.Left:
                    coordinates.X -= 15;
                    break;
            }




        }
        void Die()
        {
            if (EndSCreenShowing == false)          //THis is a stupid workaaround but it works. If i dont do this the code below keeps repeating. 
            {



                Snake.EndScreen EndSCreenOperator = new Snake.EndScreen();      //This shows the end screen. 

                EndSCreenOperator.Show();
                EndSCreenShowing = true;
            }
        }

    }

}
