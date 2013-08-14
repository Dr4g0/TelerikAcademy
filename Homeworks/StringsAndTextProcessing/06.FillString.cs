//Write a program that reads from the console a string of maximum 20 characters. If the length of the string is less than 20, the rest of the characters should be filled with '*'. 
//Print the result string into the console.

using System;
using System.Text;
using System.Threading;

class FillString
{
    static void Main()
    {
        string originalString;
        while (true)
        {
            Console.Write("Enter the string (maximum 20 characters):");
            originalString = Console.ReadLine();
            if (originalString.Length <= 20)
            {
                break;
            }
            Console.WriteLine("Maximum 20 characters, please!");
            Thread.Sleep(1500);
            Console.Clear();
        }
        StringBuilder finishString = new StringBuilder();
        finishString = finishString.Append(originalString);
        while (finishString.Length<20)
        {
            finishString = finishString.Append('*');
        }
        Console.WriteLine("The modified string is: {0}",finishString);
    }
}
