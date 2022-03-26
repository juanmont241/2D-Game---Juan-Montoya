using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace _2D_Game___Juan_Montoya
{
    internal class Player //Set the player's variables
    {
        public int width = 20; //Dertermines the size
        public int height = 20;
        public int speed = 6; //How fast the player is
        public int x, y; //Set its postion in GameScreen

        public Player(int _x, int _y)
        {
            x = _x;
            y = _y;
        }

        public void Move(string direction, Size ss) //Code for moving the player up, down, left, and right
        {
            if (direction == "left")
            {
                x -= speed;

                if (x < 0)
                {
                    x = 0;
                }
            }

            if (direction == "right")
            {
                x += speed;

                if (x > ss.Width - width)
                {
                    x = ss.Width - width;
                }
            }

            if (direction == "up" == true)
            {
                y -= speed;

                if (y < 0)
                {
                    y = 0;
                }
            }

            if (direction == "down")
            {
                y += speed;

                if (y > ss.Height - height)
                {
                    y = ss.Height - height;
                }
            }

        }
    }
}
