using System;

class JoroTheRabbit
{
    static void Main()
    {
        string inputData = Console.ReadLine();
        string[] splitData = inputData.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
        int[] terrainNumbers = new int[splitData.Length];
        for (int i = 0; i < terrainNumbers.Length; i++)
        {
            terrainNumbers[i] = int.Parse(splitData[i]);
        }
        int maxCount = 1;
        for (int initialPosition = 0; initialPosition < terrainNumbers.Length; initialPosition++)
        {
            for (int step = 0; step < terrainNumbers.Length;step++ )
            {
                //bool[] isVisited = new bool[terrainNumbers.Length];
                int startPosition = initialPosition;
                int currentCounter = 1;
                int nextPosition = startPosition + step;
                while (currentCounter<=2500)
                {
                    //isVisited[startPosition] = true;
                    if (startPosition + step > terrainNumbers.Length - 1)
                    {
                        nextPosition = startPosition - terrainNumbers.Length + step;
                    }
                    else
                    {
                        nextPosition = startPosition + step;
                    }
                    if (terrainNumbers[nextPosition] > terrainNumbers[startPosition])
                    {
                        currentCounter++;
                        //isVisited[nextPosition] = true;
                        startPosition = nextPosition;
                        if (currentCounter > maxCount)
                        {
                            maxCount = currentCounter;
                        }
                    }
                    else
                    {
                        if (currentCounter > maxCount)
                        {
                            maxCount = currentCounter;
                        }
                        break;
                    }
                }
            }
        }
        Console.WriteLine(maxCount);
    }
}