using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGenerator
{
   public class Square
    {
        private Boolean isPlayer;
        private Boolean isWall;
        private Boolean treasure;
        private Boolean alreadyVisited;
        private Boolean finished;
        private int x;
        private int y;

        public Square(int x, int y)
        {
            isWall = true;
            treasure = false;
            alreadyVisited = false;
            isPlayer = false;
            finished = false;
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

        public Boolean player()
        {
            return isPlayer;
        }

        public void openWall()
        {
            isWall = false;
        }

        public Boolean isFinish()
        {
            return finished;
        }

        public void setFinished()
        {
            this.finished = true;
        }

        public Boolean isTreasure()
        {
            return treasure;
        }

        public void setTreasure()
        {
            this.treasure = true;
        }

        public Boolean isVisited()
        {
            return alreadyVisited;
        }

        public void visited()
        {
            this.alreadyVisited = true;
        }

        public void notVisited()
        {
            this.alreadyVisited = true;
        }

        public void setIsPlayer()
        {
            this.isPlayer = true;
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
