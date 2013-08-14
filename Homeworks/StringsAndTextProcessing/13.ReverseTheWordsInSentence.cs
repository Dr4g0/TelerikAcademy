//Write a program that reverses the words in given sentence.
//Example: "C# is not C++, not PHP and not Delphi!"  "Delphi not and PHP, not C++ not is C#!".

using System;
using System.Collections.Generic;
using System.Text;

class ReverseTheWordsInSentence
{
    static void Main()
    {
        //not using String.Split()
        const string Sentence = "C# is not C++, not PHP and not Delphi!";
        //define all punctuations (add " " (space) to this array for more sample code)
        string[] allPunctuations = { ".", ",", "?", "!", "...", ":", ";", "\"", "(", ")", "-", " ", "\n", "\t", "\r" };
        char[] symbolFromSentence = Sentence.ToCharArray();
        //Three steps:
        //1.Build every word and put it in array
        //2.Separate punctuations in another array
        //3.Rememer the original positions of punstuations in another array
        List<string> words = new List<string>();
        List<string> punctuations = new List<string>();
        List<int> punctPositions = new List<int>();
        int positionCounter = 0;
        for (int i = 0; i < symbolFromSentence.Length; i++)
        {
            StringBuilder currentWord = new StringBuilder();
            if (i < symbolFromSentence.Length&&Array.IndexOf(allPunctuations, symbolFromSentence[i].ToString()) != -1)
            {
                if (symbolFromSentence[i]=='.'&&(i < symbolFromSentence.Length-1)&&symbolFromSentence[i+1]=='.')
                {
                    punctuations.Add("...");
                    i += 2;
                }
                else
                {
                    punctuations.Add(symbolFromSentence[i].ToString());
                }
                punctPositions.Add(positionCounter);
            }
            else
            {
                while (i < symbolFromSentence.Length&&Array.IndexOf(allPunctuations, symbolFromSentence[i].ToString()) < 0)
                {
                    currentWord.Append(symbolFromSentence[i]);
                    i++;   
                }
                i--; //return the iterator one position
                words.Add(currentWord.ToString());
            }
            positionCounter++;
        }
        words.Reverse();    //Reverse words and
                            //start to build rezult reversed sentence:
        StringBuilder reversedSentence = new StringBuilder();
        int lengthOfSentence=words.Count+punctuations.Count;
        for (int i = 0; i <lengthOfSentence ; i++)
        {
            if (punctPositions.Count>0&&punctPositions[0]==i)
            {
                reversedSentence.Append(punctuations[0]);
                punctuations.RemoveAt(0);
                punctPositions.RemoveAt(0);
            }
            else if (words.Count>0)
            {
                reversedSentence.Append(words[0]);
                words.RemoveAt(0);
            }
        }
        Console.WriteLine(reversedSentence);
    }
}