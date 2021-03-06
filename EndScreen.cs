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
    public partial class EndScreen : Form
    {
        public EndScreen()
        {
            InitializeComponent();
        }

        private void PlayAgain_Click(object sender, EventArgs e)        //Hides the end screen and starts the game again
        {
            Snake.GameScreen SnakeOperator = new Snake.GameScreen();
            this.Hide();
            SnakeOperator.Show();
        }

        private void ExitButton_Click(object sender, EventArgs e)           //Closes the application
        {
            Application.Exit();
        }
    }
}
