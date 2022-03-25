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
        }

        private void buttonMenu_Click(object sender, EventArgs e) //Sends the player back to the main menu
        {
            Form1.ChangeScreen(this, new MenuScreen());
        }

        private void buttonExit_Click(object sender, EventArgs e) //Closes the Application
        {
            Application.Exit();
        }
    }
}
