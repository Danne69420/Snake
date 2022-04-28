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

        static Random random = new Random();
        static int foodCoordinateFactor = random.Next(0, 26);
    public static int foodX = foodCoordinateFactor * 20;

    public int GenerateFoodX()
    {
         int foodX = foodCoordinateFactor * 20;
        return foodX;
    }
    public int GenerateFoodY() {

        int foodY = foodCoordinateFactor * 20;
        return foodY;
    }
}

