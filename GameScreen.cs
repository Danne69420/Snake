using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Snake
{
    public partial class GameScreen : Form
    {
        Timer timer = new Timer();      //New instance of the timer class

        bool EndSCreenShowing = false;
        bool FoodExists;
        List<Coordinates> coordinateList = new List<Coordinates>();             //A new list of objects of the Coordinates class. Every object van hold an x value and a y value. 
        Food food = new Food();
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
            direction = Directions.Down;
            coordinateList.Add(new Coordinates());
            coordinateList.Add(new Coordinates());
            coordinateList.Add(new Coordinates());
            coordinateList.Add(new Coordinates());
            timer.Enabled = true;
            timer.Interval = 1000;  /* 1000 millisec */     //Timer ticks every 1000 ms
            timer.Tick += new EventHandler(timer1_Tick);    //Every time the timer ticks it calls timer1_tick. The eventhandler method is requered to call  Windows forms events
        }

        


        private void KeyIsDown(object sender, KeyEventArgs e)           //This gets triggered when a kay is pressed
        {
                Input.ChangeState(e.KeyCode, true);             //This changes the hashtable to reflect that
        }

        private void KeyIsUp(object sender, KeyEventArgs e)     //This gets triggered when a key is released
        {
            Input.ChangeState(e.KeyCode, false);            //This changes the hashtable to reflect that
        }


        private void GameScreen_Load(object sender, EventArgs e)            //This does nothing but when i remove it something in the windows forms designer breaks.
        {

        }

        private int timesTicked;                //keeps track of how many times the timer has ticked
        //IDEA: Right now the program only reads input at the exact moment the timer ticks. A possible fix could be to have a seperate timer ticking very frequently read the input while using this timer to still only update the graphics every second.
        private void timer1_Tick(object sender, EventArgs e)    //For some reason this seems to tick twice every other tick
        {

            if(coordinateList[0].X < 0 | coordinateList[0].X > pictureBox1.Width | coordinateList[0].Y < 0 | coordinateList[0].Y > pictureBox1.Height)          //If you touch the wall
            {
                this.Hide();
                Die();      //You die
            }
            for (int i = coordinateList.Count - 1; i > 0; i--)      //checks for collision between the snakes head and parts
            {
                if (i != 1)         //Because the part closest to the head has its coordinates set to be the same as the head after the graphics are drawn i ignore it when checking collision, or the player dies as soon as they eat. We can ignore it because this part will never touch the head because you cant move in the opposite direction. Probably a cleaner way to fix this.
                {


                    if (coordinateList[i].X == coordinateList[0].X && coordinateList[i].Y == coordinateList[0].Y)
                    {
                        this.Hide();
                        Die();
                    }
                }
            }
            if (timesTicked % 2 == 0)   //This makes it only do stuff every when timesTicked is evenly divisible by 2. this makes it skip every fourth tick however
            {
                if (coordinateList[0].X == food.X && coordinateList[0].Y == food.Y)
                {
                    EatFood();
                }

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
                if (coordinateList[0].X == food.X && coordinateList[0].Y == food.Y)
                {
                    EatFood();
                }

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
            if(FoodExists != true)
            {
                food.X = food.GenerateFoodX();
                food.Y = food.GenerateFoodY();
                FoodExists = true;
            }
            timesTicked++;
        }
        private void updateScreen(object sender, PaintEventArgs e)          //finally got this bullshit to work. Turns out you have to use a picturebox to display the graphics and .Invalidate to update.
        {

            Graphics g = e.Graphics;
            SolidBrush blackBrush = new SolidBrush(Color.Black);        //Creates a brush
            SolidBrush redBrush = new SolidBrush(Color.Red);
            int width = 18;                                             //Sets size of the circle
            int height = 18;
            g.FillEllipse(redBrush, food.X, food.Y, width, height);

            switch (direction)          //Depending on which direction the snake is moving the coordinates are updated differently. This only updates the coordinates of the head of the snake. 
            {
            case Directions.Down:
                coordinateList[0].Y += 20;
                break;
            case Directions.Up:
                coordinateList[0].Y -= 20;
                break;
            case Directions.Right:
                coordinateList[0].X += 20;
                break;
            case Directions.Left:
                coordinateList[0].X -= 20;
                break;
            }
            for (int i = 0; i < coordinateList.Count; i++)          //this iterates once for every objevt in the list and draws the corresponding circle
            {
                g.FillEllipse(blackBrush, coordinateList[i].X, coordinateList[i].Y, width, height);         //A circle is drawn using the variables of the objects in the list
            }
            for (int i = coordinateList.Count - 1; i > 0; i--)          //This sets the coordinates of all snake parts except the head. Theres probably a more correct/standard way of doing this but this works so im not gonna mess with it.
            {
                coordinateList[i].X = coordinateList[i - 1].X;          //The coordinates of the last part get set to the coordinates of the second to last part which get set to those of the third to last part and som on. 
                coordinateList[i].Y = coordinateList[i - 1].Y;                
            }

        }
        void Die()          //This shows the end screen. 
        {
            if (EndSCreenShowing == false)          //THis is a stupid workaround but it works. If i dont do this the code below keeps repeating. 
            {
                Snake.EndScreen endScreenOperator = new Snake.EndScreen();      
                endScreenOperator.Show();
                EndSCreenShowing = true;
            }
        }
        void EatFood()
        {
            FoodExists = false;
            coordinateList.Add(new Coordinates());                                      //A new part gets added to the snake
            coordinateList[coordinateList.Count - 1].X = coordinateList[coordinateList.Count - 2].X;          //the new parts coodinates are set to be the same as those of the fhurtest back part of the snake 
            coordinateList[coordinateList.Count - 1].Y = coordinateList[coordinateList.Count - 2].Y;
        }
    }
}