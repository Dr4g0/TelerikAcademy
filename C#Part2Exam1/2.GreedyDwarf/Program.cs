using System;

class GreedyDwarf
{
    static void Main()
    {
        string numbersInValley = Console.ReadLine();
        string[] valleyNumbers = numbersInValley.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
        int[] numbersValley = new int[valleyNumbers.Length];
        for (int i = 0; i < numbersValley.Length; i++)
        {
            numbersValley[i] = int.Parse(valleyNumbers[i]);
        }
        int numberOfPatternsM = int.Parse(Console.ReadLine());
        long maxSumOfCoins = int.MinValue;
        for (int i = 0; i < numberOfPatternsM; i++)
        {
            long currentSumOfCoins = 0;
            int currentPosition = 0;
            string numbersInPattern = Console.ReadLine();
            string[] patternNumbers = numbersInPattern.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
            int[] numbersPattern = new int[patternNumbers.Length];
            for (int j = 0; j < numbersPattern.Length; j++)
            {
                numbersPattern[j] = int.Parse(patternNumbers[j]);
            }
            bool[] isValleyPosVisited = new bool[numbersValley.Length];
            int counterPatternPos = -1;
            while (currentPosition >= 0 && currentPosition < numbersValley.Length && !isValleyPosVisited[currentPosition])
            {
                currentSumOfCoins += numbersValley[currentPosition];
                isValleyPosVisited[currentPosition] = true;
                counterPatternPos++;
                currentPosition += numbersPattern[counterPatternPos % numbersPattern.Length];
            }
            if (currentSumOfCoins > maxSumOfCoins)
            {
                maxSumOfCoins = currentSumOfCoins;
            }
        }
        Console.WriteLine(maxSumOfCoins);
    }
}