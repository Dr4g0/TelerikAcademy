//Write a program that reads a string from the console and replaces all series of consecutive identical letters with a single one. 
//Example: "aaaaabbbbbcdddeeeedssaa" -> "abcdedsa".

using System;
using System.Text;

class ReplaceConsecutions
{
    static void Main(string[] args)
    {
        ////hardcore text:
        //string inputText = " AAADONTA, FLYING JIBBBOOM, PEEENT, FREEER, FREEEST, ISHIII, FRILLLESS, WALLLESS, LAPAROHYSTEROSALPINGOOOPHORECTOMY, BRRR, GODDESSSHIP, COUNTESSSHIP, DUCHESSSHIP, GOVERNESSSHIP, HOSTESSSHIP, VERTUUUS, UUULA, and YAYYY.";

        Console.WriteLine("Enter a string:");
        string inputText = Console.ReadLine();
        
        StringBuilder text = new StringBuilder(inputText);
        for (int i = 0; i < text.Length; i++)
        {
            int counterConsLetters = 1;
            while (Char.IsLetter(text[i])&&(i<text.Length-1)&&(text[i]==text[i+1]))
            {
                counterConsLetters++;
                i++;
            }
            if (counterConsLetters>1)
            {
                string substringForReplace = text.ToString().Substring(i + 1 - counterConsLetters, counterConsLetters);
                text.Replace(substringForReplace, text[i].ToString(), i + 1 - counterConsLetters, counterConsLetters);
                i=i+1-counterConsLetters; //return iterator because we change the length of the string
            }
        }
        Console.WriteLine(text);
    }
}