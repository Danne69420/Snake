using System;
using System.Collections;
using System.Windows.Forms;

namespace Projekt_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Snake.Menu snakeOperator = new Snake.Menu();            //This starts the Menu form
            snakeOperator.Show();
            
            Application.Run();


            Application.Exit();
        }
    }
}
