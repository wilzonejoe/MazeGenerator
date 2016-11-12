using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGenerator
{
    public class MazeGenerator
    {
        private int DIMENSION;
        Dictionary<int, List<Square>> map;
        Dictionary<int, List<Square>> visited;

        public MazeGenerator(int DIMENSION)
        {
            map = new Dictionary<int, List<Square>>();
            visited = new Dictionary<int, List<Square>>();
            this.DIMENSION = DIMENSION;
            init();
        }

        private Direction[] getDirections()
        {
           
            Direction[] direct = new Direction[4];
            int i = 0;
            foreach (Direction d in Enum.GetValues(typeof(Direction)))
            {
                if (d != Direction.NODIRECTION)
                {
                    direct[i] = d;
                    i++;
                }
            }
            return direct;
        }

        private int[] calculateNextPosToMakeWall(int x, int y, Direction dir)
        {
            int[] toReturn = new int[4];
            int xpath = x;
            int ypath = y;
            switch (dir)
            {
                case Direction.UP:
                    ypath--;
                    y -= 2;
                    break;
                case Direction.DOWN:
                    ypath++;
                    y += 2;
                    break;
                case Direction.LEFT:
                    xpath--;
                    x -= 2;
                    break;
                case Direction.RIGHT:
                    xpath++;
                    x += 2;
                    break;
            }
            toReturn[0] = x;
            toReturn[1] = y;
            toReturn[2] = xpath;
            toReturn[3] = ypath;

            return toReturn;
        }


        private Boolean isInBoundaries(int[] pos)
        {
            return !((pos[0] <= 0 || pos[0] >= DIMENSION - 1) || (pos[1] <= 0 || pos[1] >= DIMENSION - 1));
        }

        private Direction isStillPossibleToMove(int a, int b)
        {
            foreach (Direction value in Enum.GetValues(typeof(Direction)))
            {
                if (value != Direction.NODIRECTION)
                {
                    int[] pos = calculateNextPosToMakeWall(a, b, value);
                    if (isPossibleToMove(pos))
                    {
                        return value;
                    }
                }
            }
            return Direction.NODIRECTION;
        }

        private Boolean isPossibleToMove(int[] pos)
        {
            if (isInBoundaries(pos) && isWall(pos))
            {
                return true;
            }
            return false;
        }

        private Boolean isWall(int[] pos)
        {
            return map[pos[1]][pos[0]].wall();
        }

        private void openMaze(int a, int b)
        {
            Random rand = new Random();
            Stack<Square> stack = new Stack<Square>();
            stack.Push(map[b][a]);
            while (stack.Count != 0)
            {
                Square u = stack.Peek();
                u.openWall();
                Square w = null;
   
                int currentX = u.getX();
                int currentY = u.getY();
                while (isStillPossibleToMove(currentX, currentY) != Direction.NODIRECTION)
                {
                    Direction d = getDirections()[rand.Next(0,4)];
                    int[] nextPos = calculateNextPosToMakeWall(currentX, currentY, d);
                    if (isPossibleToMove(nextPos))
                    {
                        w = map[nextPos[1]][nextPos[0]];
                        map[nextPos[3]][nextPos[2]].openWall();
                        w.openWall();
                        currentX = w.getX();
                        currentY = w.getY();
                        stack.Push(w);
                    }
                }
                Square finished = stack.Pop();
            }
        }


        private void init()
        {
            for (int i = 0; i < DIMENSION; i++)
            {
                List<Square> list = new List<Square>();
                for (int j = 0; j < DIMENSION; j++)
                {
                    list.Add(new Square(j, i));
                }
                map.Add(i, list);
            }
            
            openMaze(1, 1);
        }

        public void printMaze()
        {
            for (int i = 0; i < map.Count; i++)
            {
                foreach (Square t in map[i])
                {
                    Console.Write(t.getStringRep());
                }
                Console.WriteLine("");
            }
        }

        static void Main(string[] args)
        {
            int num;
            Boolean evenNum = true;
            do
            {
                Console.WriteLine("Enter dimension (odd number): ");
                num = Convert.ToInt32(Console.ReadLine());
                if (evenNum =(num % 2 == 0))
                {
                    Console.WriteLine("====================================");
                    Console.WriteLine("Please enter ODD NUMBER!");
                }
                Console.WriteLine("====================================");
            } while (evenNum);

            MazeGenerator m1 = new MazeGenerator(num);
            m1.printMaze();
        }
    }
}

