using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace _2D_Game___Juan_Montoya
{

    internal class Children
    {
        public int size; //Set the Child's size and postion in Gamescreen
        public int x, y;

        public int rest = 0; //Make the rest varaible (How long the children wait until they get too impatience

        public Children(int _x, int _y, int _size)
        {
            x = _x;
            y = _y;
            size = _size;
        }

        public bool Collision(Player p) //Makes a rectangle around the player and children for Collision
        {
            Rectangle childRec = new Rectangle(x, y, size, size);
            Rectangle playerRec = new Rectangle(p.x, p.y, p.width, p.height);

            if (childRec.IntersectsWith(playerRec)) //If the child intersects with the player, turn on this behavior and sends the go ahead to the 
                                                    //function at GameScreen
            {
                return true;
            }

            return false;
        }

    }
    }


