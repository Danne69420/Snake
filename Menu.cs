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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();

        }


        private void playButton_Click(object sender, EventArgs e)
        {
            Snake.GameScreen gameOperator = new Snake.GameScreen();
            gameOperator.Show();
            this.Hide();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
