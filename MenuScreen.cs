using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2D_Game___Juan_Montoya
{
    public partial class MenuScreen : UserControl
    {
        public MenuScreen()
        {
            InitializeComponent();
            menuTitle.Text = "Deliver Cake to the Children!"; //Main Title Screen Label
        }

        private void buttonEasy_Click(object sender, EventArgs e) // Button coding for the "Easy" Difficuly
        {
           GameScreen.difficuly = 5; //Declares the difficuly number 
           GameScreen.lives = 3; //Declares how mnay lives the player has
           Form1.ChangeScreen(this, new GameScreen()); //Change Screen from MenuScreen to GameScreen
        }

        private void buttonMedium_Click(object sender, EventArgs e) // Button coding for the "Medium" Difficuly
        {
            GameScreen.difficuly = 10;
            GameScreen.lives = 5;
            Form1.ChangeScreen(this, new GameScreen());
        }

        private void buttonHard_Click(object sender, EventArgs e) // Button coding for the "Hard" Difficuly
        {
            GameScreen.difficuly = 15;
            GameScreen.lives = 5;
            Form1.ChangeScreen(this, new GameScreen());
        }

        private void buttonExit_Click(object sender, EventArgs e) //Closes the program
        {
            Application.Exit();
        }
    }
}
