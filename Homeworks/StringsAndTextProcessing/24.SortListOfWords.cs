//Write a program that reads a list of words, separated by spaces and prints the list in an alphabetical order.

using System;

class SortListOfWords
{
    static void Main()
    {
        //hardcore text:
        string inputText = "In computer programming a string is traditionally a sequence of characters either as a literal constant or as some kind of variable.";
        //Console.WriteLine("Enter a string:");
        //string inputText = Console.ReadLine();
        char separator = ' ';
        string[] words = inputText.Split(separator);
        Array.Sort(words);
        for (int i = 0; i < words.Length; i++)
        {
            Console.WriteLine(words[i]);
        }
    }
}