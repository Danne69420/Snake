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


}

