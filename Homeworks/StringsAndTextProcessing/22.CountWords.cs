//Write a program that reads a string from the console and lists all different words in the string 
//along with information how many times each word is found.

using System;
using System.Collections.Generic;

class CountWords
{
    static void Main()
    {
        ////hardcore text:
        //string inputText = @"In computer programming, a string is traditionally a sequence of characters, either as a literal constant or as some kind of variable.
        //        The latter may allow its elements to be mutated and/or the length changed, or it may be fixed (after creation). 
        //        A string is generally understood as a data type and is often implemented as an array of bytes (or words) that stores a sequence of elements, 
        //        typically characters, using some character encoding. A string may also denote more general arrays or other sequence (or list) data types and structures.";
        Console.WriteLine("Enter a string:");
        string inputText = Console.ReadLine();
        string[] allPunctuations = { ".", ",", "?", "!", "...", ":", ";", "\"", "(", ")", "-", " ", "\n", "\t", "\r" };
        string[] wordsFromText = inputText.Split(allPunctuations, StringSplitOptions.RemoveEmptyEntries);
        List<string> words = new List<string>();
        List<int> countWords = new List<int>();
        for (int i = 0; i < wordsFromText.Length; i++)
        {
            if (words.IndexOf(wordsFromText[i]) < 0)
            {
                words.Add(wordsFromText[i]);
                countWords.Add(1);
            }
            else
            {
                countWords[words.IndexOf(wordsFromText[i])]++;
            }
        }
        Console.WriteLine();
        Console.WriteLine("{0,10}{1,15}", "word", "reps");
        for (int i = 0; i < words.Count; i++)
        {
            Console.WriteLine("{0,15}{1,10}", words[i], countWords[i]);
        }
        Console.WriteLine();
    }
}