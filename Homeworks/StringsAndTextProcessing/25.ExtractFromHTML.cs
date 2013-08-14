//Write a program that extracts from given HTML file its title (if available), and its body text without the HTML tags.

using System;
using System.IO;

class ExtractFromHTML
{
    static void Main()
    {
        StreamReader inputFile = new StreamReader(@"..\..\InputFile.html");
        using (inputFile)
        {
            StreamWriter outputFile = new StreamWriter(@"..\..\OuputFile.txt");
            using (outputFile)
            {
                string allText = inputFile.ReadToEnd();
                int endTitleIndex = 0;
                if (allText.IndexOf("<title>")!=-1)
                {
                    int startTitleIndex=allText.IndexOf("<title>")+7;
                    endTitleIndex=allText.IndexOf('<',startTitleIndex);
                    int lengthOfTitle=endTitleIndex-startTitleIndex;
                    string title = allText.Substring(startTitleIndex, lengthOfTitle);
                    outputFile.WriteLine(title);
                    //Console.WriteLine(title);
                }
                int indexCloseTag = allText.IndexOf('>', endTitleIndex);
                int indexOpenTag = allText.IndexOf('<', indexCloseTag);
                int wordLength = indexOpenTag - indexCloseTag - 1;
                while (indexOpenTag != -1)
                {
                    string substring = allText.Substring(indexCloseTag + 1, wordLength);
                    if (!String.IsNullOrWhiteSpace(substring)) //check for whitespace symbols between tags
                    {
                        outputFile.WriteLine(allText.Substring(indexCloseTag + 1, wordLength));
                        //Console.WriteLine(allText.Substring(indexCloseTag + 1, wordLength));
                    }
                    indexCloseTag = allText.IndexOf('>', indexOpenTag);
                    indexOpenTag = allText.IndexOf('<', indexCloseTag);
                    wordLength = indexOpenTag - indexCloseTag - 1;
                }
            }
        }
        //to see the rezult open file "OuputFile.txt" in your current directory 
        //if you want print the rezult on the console uncomment Line 25 and Line 36
    }
}