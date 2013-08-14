//Write a program that reads a string from the console and prints all different letters 
//in the string along with information how many times each letter is found. 

using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter a string:");
        string inputText=Console.ReadLine();
        List<char> letters = new List<char>();
        List<int> countLetters = new List<int>();
        for (int i = 0; i < inputText.Length; i++)
        {
            if (Char.IsLetter(inputText[i]))
            {
                if (letters.IndexOf(inputText[i])<0)
                {
                    letters.Add(inputText[i]);
                    countLetters.Add(1);
                }
                else
                {
                    countLetters[letters.IndexOf(inputText[i])]++;
                }
            }
        }
        Console.WriteLine();
        Console.WriteLine("{0,8}{1,7}","letter","reps");
        for (int i = 0; i < letters.Count; i++)
        {
            Console.WriteLine("{0,6}{1,8}",letters[i],countLetters[i]);
        }
        Console.WriteLine();
    }
}