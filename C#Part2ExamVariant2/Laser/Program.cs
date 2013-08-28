using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laser
{
    //class Laser
    //{
    //    public int LaserWidth { get; set; }
    //    public int LaserHeight { get; set; }
    //    public int LaserDepth { get; set; }
    //    public Laser(int laserWidth, int laserHeight, int laserDepth)
    //    {
    //        this.LaserWidth = laserWidth;
    //        this.LaserHeight = laserHeight;
    //        this.LaserDepth = laserDepth;
    //    }
    //}

    class Program
    {
        private static int width, height, depth;
        //private static Laser ourLaser;
        private static int[,,] cube;
        private static int currentWidth = -1;
        private static int currentHeight = -1;
        private static int currentDepth = -1;

        static void Main()
        {
            ParseInputData();
            BurnTheEdges();
            MoveLaser();
            Console.WriteLine("{0} {1} {2}",currentWidth+1,currentHeight+1,currentDepth+1);
        }

        private static void BurnTheEdges()
        {
            for (int w = 0; w < width; w++)
            {
                for (int h = 0; h < height; h++)
                {
                    for (int d = 0; d < depth; d++)
                    {
                        if ((d==0&&h==0)||(d==0&&w==0)||(h==0&&w==0))
                        {
                            cube[w, h, d] = 1; 
                        }
                        if ((d==depth-1&&h==height-1)||(d==depth-1&&w==width-1)||(w==width-1&&h==height-1))
                        {
                            cube[w, h, d] = 1; 
                        }
                        if ((d==0&&h==height-1)||(d==depth-1&&h==0))
                        {
                            cube[w, h, d] = 1;
                        }
                        if ((w == 0 && h == height - 1) || (w == width - 1 && h == 0))
                        {
                            cube[w, h, d] = 1;
                        }
                        if ((d == 0 && w == width - 1) || (d == depth - 1 && w == 0))
                        {
                            cube[w, h, d] = 1;
                        }
                    }
                }
            }
        }

        private static void MoveLaser()
        {
            string[] direction = Console.ReadLine().Split();
            int[] numbersDirection=new int[direction.Length];
            for (int dir = 0; dir < direction.Length; dir++)
            {
                numbersDirection[dir]=int.Parse(direction[dir]);
            }
            while (true)
            {
                int tmpWidth = currentWidth;
                int tmpHeight = currentHeight;
                int tmpDepth = currentDepth;
                switch (numbersDirection[0])
                {
                    case 1:
                        tmpWidth++;
                        break;
                    case 0:
                        break;
                    case -1:
                        tmpWidth--;
                        break;
                    default: throw new ArgumentException("Invalid direction");
                }
                switch (numbersDirection[1])
                {
                    case 1:
                        tmpHeight++;
                        break;
                    case 0:
                        break;
                    case -1:
                        tmpHeight--;
                        break;
                    default: throw new ArgumentException("Invalid direction");
                }
                switch (numbersDirection[2])
                {
                    case 1:
                        tmpDepth++;
                        break;
                    case 0:
                        break;
                    case -1:
                        tmpDepth--;
                        break;
                    default: throw new ArgumentException("Invalid direction");
                }
                if (cube[tmpWidth,tmpHeight,tmpDepth]!=0)
                {
                    break;
                }
                else 
                {
                    if (tmpWidth == width-1||tmpWidth==0)
                    {
                        numbersDirection[0] /= -1;
                    }
                    if (tmpHeight == height-1||tmpHeight==0)
                    {
                        numbersDirection[1] /= -1;
                    }
                    if (tmpDepth == depth-1||tmpDepth==0)
                    {
                        numbersDirection[2] /= -1;
                    }
                    cube[currentWidth, currentHeight, currentDepth] = 1;
                    currentWidth=tmpWidth;
                    currentHeight=tmpHeight;
                    currentDepth=tmpDepth;
                }
            }
        }

        private static void ParseInputData()
        {
            string[] cubeSize = Console.ReadLine().Split();
            width = int.Parse(cubeSize[0]);
            height = int.Parse(cubeSize[1]);
            depth = int.Parse(cubeSize[2]);
            cube = new int[width, height, depth];
            string[] position = Console.ReadLine().Split();
            currentWidth = int.Parse(position[0])-1;
            currentHeight = int.Parse(position[1])-1;
            currentDepth = int.Parse(position[2])-1;
            //ourLaser = new Laser(currentWidth, currentHeight, currentDepth);
        }
    }
}
