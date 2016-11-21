using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGenerator
{
   public class Square
    {
        private Boolean isWall;
        private int x;
        private int y;

        public Square(int x, int y)
        {
            isWall = true;
            this.x = x;
            this.y = y;
        }

        public int getX()
        {
            return this.x;
        }

        public int getY()
        {
            return this.y;
        }

        public Boolean wall()
        {
            return this.isWall;
        }

        public void openWall()
        {
            isWall = false;
        }


        public String getStringRep()
        {
            if (isWall)
            {
                return "#";
            }else
            {
                return " ";
            }
        }
    }
}
