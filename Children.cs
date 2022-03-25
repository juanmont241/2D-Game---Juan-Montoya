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
        public int size;
        public int x, y;

        public int rest = 0;
        public Children(int _x, int _y, int _size)
        {
            x = _x;
            y = _y;
            size = _size;
        }

        public bool Collision(Player p)
        {
            Rectangle childRec = new Rectangle(x, y, size, size);
            Rectangle playerRec = new Rectangle(p.x, p.y, p.width, p.height);

            if (childRec.IntersectsWith(playerRec))
            {
                y = p.y - size;
            }
            else
            {
                y = p.y + p.height;
            }

                return true;
            }

            return false;

        }
}

//Things to ask:
// Add Collision with child and robot
// Fix the Patience Issue

