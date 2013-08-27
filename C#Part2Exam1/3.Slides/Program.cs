using System;
using System.IO;

class Slides
{
    static int widthW ;
    static int heightH ;
    static int depthD ;
    static int currentWidth ;
    static int currentHeight;
    static int currentDepth;
    static bool exit = true;

    static void Main()
    {
        //StreamReader inFile = new StreamReader(@"D:\My Documents\C#\BGCoder\C# Part2 4 Feb 2013 - Morning\Problem 3\Tests\test.003.in.txt");
        //Console.SetIn(new StreamReader(Console.OpenStandardInput(8192)));
        //string sizeOfCuboid = inFile.ReadLine();
        string sizeOfCuboid = Console.ReadLine();
        string[] directions = sizeOfCuboid.Split(new char[] { ' ' });
        widthW = int.Parse(directions[0]);
        heightH= int.Parse(directions[1]);
        depthD = int.Parse(directions[2]);
        string[] rows = new string[heightH];
        for (int i = 0; i < rows.Length; i++)
        {
            //rows[i] = inFile.ReadLine();
            rows[i] = Console.ReadLine();
        }
        //string initialWandD = inFile.ReadLine();
        string initialWandD = Console.ReadLine();
        string[] wAndD = initialWandD.Split(new char[] { ' ' });
        currentWidth = int.Parse(wAndD[0]);
        currentHeight = 0;
        currentDepth = int.Parse(wAndD[1]);
        string[,,] valueInCubes=new string[widthW,heightH,depthD];
        for (int i = 0; i < heightH; i++)
        {
            string[] tmpRowValues = rows[i].Split(new string[] { " | " }, StringSplitOptions.RemoveEmptyEntries);
            for (int j = 0; j < depthD; j++)
            {
                string[] tmpCubeValues = tmpRowValues[j].Split(new string[] { "(", ")"  }, StringSplitOptions.RemoveEmptyEntries);
                for (int k = 0; k < widthW; k++)
                {
                    valueInCubes[k, i, j] = tmpCubeValues[k];
                }
            }
        }
        while (exit)
        {
            while (valueInCubes[currentWidth, currentHeight, currentDepth][0] == 'T')
            {
                string[] teleportCoord = valueInCubes[currentWidth, currentHeight, currentDepth].Split(
                    new string[] { "T ", " " }, StringSplitOptions.RemoveEmptyEntries);
                currentWidth = int.Parse(teleportCoord[0]);
                currentDepth = int.Parse(teleportCoord[1]);
            }

            if (valueInCubes[currentWidth, currentHeight, currentDepth] == "B")
            {
                exit = false;
                break;
            }
            
            if (currentHeight == heightH - 1)
            {
                break;
            }
            else
            {
                if (valueInCubes[currentWidth,currentHeight,currentDepth]!="E")
                {
                    changeValueOfCoordinates(valueInCubes[currentWidth, currentHeight, currentDepth]);
                }
                if (exit)
                {
                    currentHeight++;
                }
            }
        }
        if (exit)
        {
            Console.WriteLine("Yes");
        }
        else
        {
            Console.WriteLine("No");
        }
        Console.WriteLine("{0} {1} {2}",currentWidth,currentHeight,currentDepth);
    }

    static void changeValueOfCoordinates(string command)
    {
        int tmpWidth = currentWidth;
        int tmpDepth = currentDepth;
        command = command.Remove(0, 2);
        for (int i = 0; i < command.Length; i++)
        {
            char currentLetterOfCommand=command[i];
            switch (currentLetterOfCommand)
            {
                case 'L':
                    if (tmpWidth > 0)
                    {
                        tmpWidth--;
                    }
                    else
                    {
                        exit = false;
                    }
                    break;

                case 'R':
                    if (tmpWidth < widthW - 1)
                    {
                        tmpWidth++;
                    }
                    else
                    {
                        exit = false;
                    }
                    break;
                case 'F':
                    if (tmpDepth > 0)
                    {
                        tmpDepth--;
                    }
                    else
                    {
                        exit = false;
                    }
                    break;
                case 'B':
                    if (tmpDepth < depthD - 1)
                    {
                        tmpDepth++;
                    }
                    else
                    {
                        exit = false;
                    }
                    break;
                default:
                    break;
            }
        }
        if (exit)
        {
            currentWidth = tmpWidth;
            currentDepth = tmpDepth;
        }
    }
}