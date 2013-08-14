//Write a program that extracts from a given text all palindromes, e.g. "ABBA", "lamal", "exe".

using System;
using System.Collections.Generic;

class ExtractPalindromes
{
    static void Main()
    {
        const string PalindromesPlaces = "Glenelg (Australia), Kanakanak (Alaska), Kinikinik (Colorado), Navan (Meath, Ireland), Neuquen (Argentina),WardDraw (South Dakota), Wassamassaw (South Carolina), YrekaBakery (Yreka, California)";
        string[] allPunctuations = { ".", ",", "?", "!", "...", ":", ";", "\"", "(", ")", "-", " ", "\n", "\t", "\r" };
        string[] words = PalindromesPlaces.Split(allPunctuations, StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < words.Length; i++)
        {
            char[] arrayLetters = words[i].ToLower().ToCharArray(); //non case sensetive check
            List<char> tmpArray = new List<char>();
            foreach (char c in arrayLetters)
            {
                tmpArray.Insert(0, c);
            }
            char[] reversedLetters = tmpArray.ToArray();
            
            if (IsArrayEqual(arrayLetters,reversedLetters))
            {
                Console.Write("\"{0}\",",words[i]);
            }
        }
        Console.WriteLine();
    }

    static bool IsArrayEqual(char[] array1, char[] array2) //same length
    {
        bool equalArrays = false;
        for (int i = 0; i < array1.Length; i++)
        {
            if (array1[i]!=array2[i])
            {
                equalArrays = false;
                break;
            }
            equalArrays = true;
        }
        return equalArrays;
    }
}