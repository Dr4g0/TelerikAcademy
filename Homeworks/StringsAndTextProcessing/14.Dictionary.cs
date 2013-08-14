//A dictionary is stored as a sequence of text lines containing words and their explanations. 
//Write a program that enters a word and translates it by using the dictionary. Sample dictionary:
//      .NET – platform for applications from Microsoft
//      CLR – managed execution environment for .NET
//      namespace – hierarchical organization of classes

using System;

class Dictionary
{
    static void Main()
    {
        string[] dictionary = { ".NET – platform for applications from Microsoft", "CLR – managed execution environment for .NET", "namespace – hierarchical organization of classes" };
        Console.WriteLine("Words in dictionary:");
        Console.WriteLine();
        for (int i = 0; i < dictionary.Length; i++)
        {
            string cleanWord = dictionary[i].Substring(0, dictionary[i].IndexOf('–')).Trim();
            Console.WriteLine("{0}",cleanWord);
        }
        Console.WriteLine();
        Console.Write("Type the word you want to transalte (case insensitive): ");
        string userChoice = Console.ReadLine();
        Console.WriteLine("\n{0}",FindTheExplanationInDictionary(userChoice, dictionary));
    }

    static string FindTheExplanationInDictionary(string word, string[] dictionary)
    {
        string explanation = String.Empty;
        for (int i = 0; i < dictionary.Length; i++)
        {
            if (word.ToLower() == dictionary[i].Substring(0, dictionary[i].IndexOf('–')).Trim().ToLower()) //case insensitive search
            {
                explanation=dictionary[i];
                break;
            }
            explanation = "There is no such word in the dictionary, try again.";
        }
        return explanation;
    }
}