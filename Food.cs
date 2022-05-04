using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Food
    {
        public int X { get; set; }
        public int Y { get; set; }
        Random random = new Random();
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
}
