using System;
using System.Collections;
using System.Windows.Forms;

namespace Projekt_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Snake.Menu snakeOperator = new Snake.Menu();
            //Snake.GameScreen gameOperator = new Snake.GameScreen();
            snakeOperator.Show();
            
            Application.Run();


            Application.Exit();
        }
    }
    class Game
    {
        static void Run()
        {

        }
        void Start()
        {

        }
    }
}
