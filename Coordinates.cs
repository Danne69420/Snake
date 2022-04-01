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
        public void Draw(Graphics g)
        {
        // Create solid brush.
        SolidBrush blackBrush = new SolidBrush(Color.Black);
        Coordinates coordinates = new Coordinates();
        // Create location and size of rectangle.
        int x = coordinates.X;
        int y = coordinates.Y;
        int width = 12;
        int height = 12;

        coordinates.X += 15;
        coordinates.Y += 15;

        // Fill rectangle to screen.
        g.FillRectangle(blackBrush, x, y, width, height);

    }

}
