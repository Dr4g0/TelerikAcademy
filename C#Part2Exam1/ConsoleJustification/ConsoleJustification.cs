using System;
using System.Text;

class ConsoleJustification
{
    static void Main()
    {
        int numberOfLines = int.Parse(Console.ReadLine());
        int numberOfSymbols = int.Parse(Console.ReadLine());
        StringBuilder allText = new StringBuilder();
        for (int i = 0; i < numberOfLines; i++)
        {
            allText.Append(Console.ReadLine());
            allText.Append(" ");
        }
        string[] words = allText.ToString().Split(new char[] { ' ', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries);

        int currentSymbols = 0;
        int countWords = 0;
        int whitespacesBetweenWords = 0;
        int plusOneWhitespacePosiitons = 0;
        for (int i = 0; i < words.Length; i++)
        {
            if (currentSymbols + words[i].Length <= numberOfSymbols)
            {
                currentSymbols += words[i].Length;
                countWords++;
                    currentSymbols++;
                if (i == words.Length - 1)
                {
                    if (countWords > 1)
                    {
                        whitespacesBetweenWords = (numberOfSymbols - (currentSymbols - countWords)) / (countWords - 1);
                        plusOneWhitespacePosiitons = (numberOfSymbols - (currentSymbols - countWords)) % (countWords - 1);
                    }
                    
                        countWords --;
                    
                    StringBuilder currentLine = new StringBuilder();
                    for (int j = i - countWords; j <= i; j++)
                    {
                        currentLine.Append(words[j]);
                        if (j < i)
                        {
                            currentLine.Append(new string(' ', whitespacesBetweenWords));
                            if (plusOneWhitespacePosiitons > 0)
                            {
                                currentLine.Append(' ');
                                plusOneWhitespacePosiitons--;
                            }
                        }
                    }
                    Console.WriteLine(currentLine);
                }
            }
            else
            {
                if (countWords > 1)
                {
                    whitespacesBetweenWords = (numberOfSymbols - (currentSymbols - (countWords))) / (countWords - 1);
                    plusOneWhitespacePosiitons = (numberOfSymbols - (currentSymbols - (countWords))) % (countWords - 1);
                }
                StringBuilder currentLine = new StringBuilder();
                for (int j = i - countWords; j < i; j++)
                {
                    currentLine.Append(words[j]);
                    if (j < i - 1)
                    {
                        currentLine.Append(new string(' ', whitespacesBetweenWords));
                        if (plusOneWhitespacePosiitons > 0)
                        {
                            currentLine.Append(' ');
                            plusOneWhitespacePosiitons--;
                        }
                    }
                }
                Console.WriteLine(currentLine);
                i--;
                currentSymbols = 0;
                countWords = 0;
                whitespacesBetweenWords = 0;
                plusOneWhitespacePosiitons = 0;
            }
        }
    }
}