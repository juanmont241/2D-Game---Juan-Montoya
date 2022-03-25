using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace _2D_Game___Juan_Montoya
{
    public partial class GameScreen : UserControl
    {
        Children hungryChild; //Setting the classes
        Player robotCakebear;

        public static int lives, difficuly; //Declaring the ints from Menuscreen to Gamescreen to theses varablies
        public static int score = 0; //Declaring the score

        List<Children> littleChild = new List<Children>(); //Making a list for how many children are in the game

        Random randGen = new Random(); //Declaring the Random Genrator
        Size screenSize; //Declaring the screen size

        public static int gsWidth = 530; //Whats the width of the Gamescreen
        public static int gsHeight = 530; //Whats the Height of the Gamescreen
        public static int patienceTimer; //Declaring the patienceTimer for each child

        bool upArrowDown = false; //Setting the player's keys to false
        bool downArrowDown = false;
        public static bool leftArrowDown = false;
        bool rightArrowDown = false;

        public GameScreen()
        {
            InitializeComponent();

            InitializeGame();

        }


        public void InitializeGame() //What the Gamescreen is going to boot up first
        {
            screenSize = new Size(this.Width, this.Height); //Moving the Width and Height varaibles to the screen size

            int x = randGen.Next(40, screenSize.Width - 40); //Declaring the positon of x and y in random spots on the Gamescreen
            int y = randGen.Next(40, screenSize.Height - 40);
            hungryChild = new Children(x, y, 50); //Setting the varaibles for the list in each child (postion and size)

            x = randGen.Next(40, screenSize.Width - 40);
            y = randGen.Next(40, screenSize.Height - 40);
            robotCakebear = new Player(x, y); //Setting the varaibles for the player (postion)

            //Using the difficuly varaibles from Menuscreen, we determine how much children will be added to "littlechild" list

            for (int i = 0; i < difficuly; i++)
            {
                NewChild();
            }
        }

        public void NewChild()
        {
            int x = randGen.Next(40, screenSize.Width - 40); //How to send info to children without declaring theses lines of code again?
            int y = randGen.Next(40, screenSize.Height - 40);
            int size = 50;

            Children c = new Children(x, y, size); //Using the Children Class to make a new child
            littleChild.Add(c); //Add the child to the "littlechild" list

            patienceTimer = randGen.Next(500, 1500); //Declaring which timer does each child start with
            //(Remember 10sec x 50. Time ticks more faster thanks to Interval = 20)
            c.rest = patienceTimer; //Adds the random start times to each child in the list
            //(This line of code sets how long each child waits until they become unpatience)

       

            
        }


        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e) //Player's keys when their press down the key
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
            }
        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e) //Player's keys when they relece the key
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
            }
        }

        private void gameTImer_Tick(object sender, EventArgs e)
        {
            if (leftArrowDown == true) //Code for moving the player using the "Move" behavior from the Player class
            {
                robotCakebear.Move("left", screenSize); //screenSize is used to determine where the player is (to be up to date)
            }

            if (rightArrowDown == true)
            {
                robotCakebear.Move("right", screenSize);
            }

            if (upArrowDown == true)
            {
                robotCakebear.Move("up", screenSize);
            }

            if (downArrowDown == true)
            {
                robotCakebear.Move("down", screenSize);
            }

          //  if (hungryChild.Collision(robotCakebear)) //What happens when the player collisions with a child (Using the collision behavior in the player class)
        //    {
          //      c.rest = patienceTimer; //Restarts the child's timer to a random number
         //       score++; //Contines to add the score as long as the player keeps giving the child cake
          //  }

            foreach (Children c in littleChild) //For each child in the list
            {
                c.rest--; //Lower the timer in each child

                if (c.rest == 0) //if the child's patiences reaches 0, then the player loses a life and the timer rests to a random number
                {
                    lives--;
                    c.rest = patienceTimer;
                }
            }

            foreach (Children c in littleChild) //For each child in the list
            {
                if (c.Collision(robotCakebear)) //If a child collides with the player
                {
                    c.rest = patienceTimer; //
                    score++;

                    if (lives == 0) //if they are no more lives then the game ends and sends the player to the GameOverscreen
                    {
                        gameTImer.Enabled = false; //Turns off the game timer
                        Form1.ChangeScreen(this, new GameOverScreen());
                    }
                }
            }


            Refresh();
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            scoreLabel.Text = $"{score}"; //Sends the score as a label on the Gamescreen
            livesLabel.Text = $"{lives}"; //Sends the lives as a label on the Gamescreen

            foreach (Children c in littleChild) //For each child on the list
            {
                if (c.rest < 1500 && c.rest > 750) //Changing each child's colour if they reach certain time laps (Less than 20 seconds)
                {
                    e.Graphics.FillEllipse(Brushes.Green, c.x, c.y, c.size, c.size);
                }

                if (c.rest < 750 && c.rest > 500) //Less than 15 seconds, but more than 10 seconds
                {
                    e.Graphics.FillEllipse(Brushes.Orange, c.x, c.y, c.size, c.size);
                }

                if (c.rest < 500) //Less than 10 seconds
                {
                    e.Graphics.FillEllipse(Brushes.Red, c.x, c.y, c.size, c.size);
                }
            }

            e.Graphics.FillRectangle(Brushes.Brown, robotCakebear.x, robotCakebear.y, robotCakebear.width, robotCakebear.height);
            //setting the colour for the player
        }
    }
}
    
