using System;
using System.Timers;
using System.Drawing;
    class Coordinates
    {
    private int x = 0;
        public int X 
        {
            get { return x; } set { x = value; }
        }
        public int Y { get; set; }

    public enum Directions         //This is an enumerable variabel. It works sort of like a class. First i declare what values the enum can have. 
    {
        Left,
        Right,
        Up,
        Down,
    }
    public Directions direction = new Directions();

    static Random random = new Random();


    //Should probably move the code below into its own class, but i dont have time right now. 
    //For some reason the game window is approximately 360 by 400, despite the fact that i set it to 500 by 500 in the windows forms designer.
    public int GenerateFoodX()
    {
        int foodCoordinateFactor = random.Next(0, 19);          //generates a number betwwen 0 and 18
        int foodX = foodCoordinateFactor * 20;                  //sets the coordinate of the foor. We wnat it tobe a multiple of 20 to make it aligned to the grid. 
        return foodX;
    }
    public int GenerateFoodY() 
    {
        int foodCoordinateFactor = random.Next(0, 21);
        int foodY = foodCoordinateFactor * 20;
        return foodY;
    }
}

