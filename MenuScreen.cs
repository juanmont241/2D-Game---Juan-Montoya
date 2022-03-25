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
           GameScreen.lives = 10; //Declare how much lives send to Gamescreen
           GameScreen.difficuly = 4; //Declares the difficuly number (We use this number for a if statement)
            Form1.ChangeScreen(this, new GameScreen()); //Change Screen from Menuscreen to Gamescreen
        }

        private void buttonMedium_Click(object sender, EventArgs e) // Button coding for the "Medium" Difficuly
        {
            GameScreen.lives = 5;
            GameScreen.difficuly = 7;
            Form1.ChangeScreen(this, new GameScreen());
        }

        private void buttonHard_Click(object sender, EventArgs e) // Button coding for the "Hard" Difficuly
        {
            GameScreen.lives = 3;
            GameScreen.difficuly = 10;
            Form1.ChangeScreen(this, new GameScreen());
        }

        private void buttonExit_Click(object sender, EventArgs e) //Closes the program
        {
            Application.Exit();
        }
    }
}
