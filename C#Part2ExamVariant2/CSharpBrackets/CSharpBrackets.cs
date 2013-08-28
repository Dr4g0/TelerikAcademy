using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class CSharpBrackets
{
    static void Main()
    {
        Console.SetIn(new StreamReader(Console.OpenStandardInput(8192)));
        int numberOfLines = int.Parse(Console.ReadLine());
        string tabString = Console.ReadLine();
        //bool isStartWithBracket = false;
        //int tabCount = 0;
        List<string> finishLines = new List<string>();
        for (int i = 0; i < numberOfLines; i++)
        {
            string currentLine = Console.ReadLine();
            currentLine = currentLine.Trim();
            if (currentLine=="")
            {
                continue;   
            }
            if (currentLine.IndexOf('{') < 0 && currentLine.IndexOf('}') < 0)
            {
                finishLines.Add(ClearInternalWhitespaces(currentLine).ToString());
            }
            else
            {
                string[] words = currentLine.Split(new char[] { '{', '}' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < words.Length; j++)
                {
                    if (words[j]==" ")
                    {
                        words[j] = "";
                    }
                }
                //for (int j = 0; j < words.Length; j++)
                //{
                //    words[j] = words[j].Trim();
                //}
                string[] brackets = currentLine.Split(words, StringSplitOptions.RemoveEmptyEntries);
                List<string> addWords = new List<string>(words);
                List<string> addBrackets = new List<string>(brackets);
                for (int b = 0; b < addBrackets.Count; b++)
                {
                    addBrackets[b] = addBrackets[b].Trim();
                    if (addBrackets[b].Length > 1)
                    {
                        for (int l = addBrackets[b].Length-1; l >=0; l--)
                        {
                            if (addBrackets[b][l]=='{'||addBrackets[b][l]=='}')
                            {
                                addBrackets.Insert(b + 1, addBrackets[b][l].ToString());
                            }
                        }
                        addBrackets.RemoveAt(b);
                    }
                }
                while (addWords.Count > 0 && addBrackets.Count > 0)
                {
                    if (currentLine.IndexOf(addWords[0]) < currentLine.IndexOf(addBrackets[0]))
                    {
                        StringBuilder tmpString = ClearInternalWhitespaces(addWords[0]);
                        if (tmpString.ToString()!="")
                        {
                            finishLines.Add(tmpString.ToString());
                        }
                        currentLine = currentLine.Remove(0, addWords[0].Length);
                        addWords.RemoveAt(0);
                    }
                    else
                    {
                        finishLines.Add(ClearInternalWhitespaces(addBrackets[0]).ToString());
                        currentLine = currentLine.Remove(0, 1);
                        addBrackets.RemoveAt(0);
                    }
                }
                while (addBrackets.Count > 0)
                {
                    finishLines.Add(ClearInternalWhitespaces(addBrackets[0]).ToString());
                    addBrackets.RemoveAt(0);
                }
                while (addWords.Count > 0)
                {
                    if (ClearInternalWhitespaces(addWords[0]).ToString() != "")
                    {
                        finishLines.Add(ClearInternalWhitespaces(addWords[0]).ToString());
                    }
                    addWords.RemoveAt(0);
                }
            }
        }
        PrintRezult(finishLines, tabString);
    }
    
    private static void PrintRezult(List<string> arrayWithWords, string tabString)
    {
        int tabCount = 0;
        while (arrayWithWords.Count > 0)
        {
            if (arrayWithWords[0] == "}")
            {
                tabCount--;
            }
            for (int i = 0; i < tabCount; i++)
            {
                Console.Write(tabString);
            }
            Console.WriteLine(arrayWithWords[0]);
            if (arrayWithWords[0] == "{")
            {
                tabCount++;
            }
            arrayWithWords.RemoveAt(0);
        }
    }

    private static StringBuilder ClearInternalWhitespaces(string line)
    {
        line = line.Trim();
        StringBuilder tmpLine = new StringBuilder();
        tmpLine.Append(line);
        for (int i = 1; i < tmpLine.Length; i++)
        {
            if (tmpLine[i] == ' ' && tmpLine[i - 1] == ' ')
            {
                tmpLine.Remove(i, 1);
                i--;
            }
        }
        return tmpLine;
    }
}