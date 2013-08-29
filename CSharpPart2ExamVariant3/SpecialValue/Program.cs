using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecialValue
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfRows = int.Parse(Console.ReadLine());
            int[][] cells = new int[numberOfRows][];
            for (int i = 0; i < numberOfRows; i++)
            {
                string[] currentNumbers = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                cells[i] = new int[currentNumbers.Length];
                for (int j = 0; j < currentNumbers.Length; j++)
                {
                    cells[i][j] = int.Parse(currentNumbers[j]);
                }
            }

            int currentRow = 0;
            int currentCol = 0;
            int maxSpecialValue = 0;

            //int[][] tmpArray = new int[cells.GetLength(0)][];

            for (int i = 0; i < cells[0].GetLength(0); i++)
            {
                bool[][] isCellVisited = new bool[cells.Length][];
                for (int j = 0; j < cells.GetLength(0); j++)
                {
                    isCellVisited[j] = new bool[cells[j].GetLength(0)];
                }
                currentRow = 0;
                currentCol = i;

                int countSteps = 1;
                while (true)
                {
                    if (cells[currentRow][currentCol] < 0)
                    {

                        if ((countSteps - cells[currentRow][currentCol]) > maxSpecialValue)
                        {
                            maxSpecialValue = countSteps - cells[currentRow][currentCol];
                        }
                        break;
                    }
                    else if (isCellVisited[currentRow][currentCol] == true)
                    {
                        break;
                    }

                    else
                    {
                        isCellVisited[currentRow][currentCol] = true;
                        currentCol = cells[currentRow][currentCol];
                        if (currentRow == cells.GetLength(0) - 1)
                        {
                            currentRow = 0;
                        }
                        else
                        {
                            currentRow++;
                        }
                    }
                    countSteps++;
                }

            }
            if (maxSpecialValue > 0)
            {
                Console.WriteLine(maxSpecialValue);
            }

        }
    }
}
