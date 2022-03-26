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
    public partial class GameOverScreen : UserControl
    {
        public GameOverScreen()
        {
            InitializeComponent();

            scoreLabel.Text = $" You gave {GameScreen.score} cakes to the children!"; //Label to show total score
        }

        private void buttonMenu_Click(object sender, EventArgs e) //Sends the player back to the main menu
        {
            Form1.ChangeScreen(this, new MenuScreen());
            GameScreen.score = 0;
            GameScreen.lives = 3; //Refreshing the varaibles so the game doesn't get stuck
           
        }

        private void buttonExit_Click(object sender, EventArgs e) //Closes the Application
        {
            Application.Exit();
        }
    }
}
