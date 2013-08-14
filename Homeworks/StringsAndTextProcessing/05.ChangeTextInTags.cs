//You are given a text. Write a program that changes the text in all regions 
//surrounded by the tags <upcase> and </upcase> to uppercase. 
//The tags cannot be nested. Example:
//      "We are living in a <upcase>yellow submarine</upcase>. 
//      We don't have <upcase>anything</upcase> else."
//The expected result:
//      "We are living in a YELLOW SUBMARINE. We don't have ANYTHING else."


using System;
using System.Text;

class ChangeTextInTags
{
    static void Main()
    {
        const string openTag = "<upcase>";
        const string closeTag = "</upcase>";
        const string text = "<upcase>We</upcase> are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.";
        StringBuilder modifiedText = new StringBuilder();
        int startIndex = text.IndexOf(openTag);
        int endIndex = 0;
        while (startIndex!=-1)
        {
            modifiedText=modifiedText.Append(text.Substring(endIndex,startIndex-endIndex));
            endIndex = text.IndexOf(closeTag,startIndex);
            int lengthOfTaggedText=endIndex-startIndex-8;
            modifiedText=modifiedText.Append(text.Substring(startIndex+openTag.Length,lengthOfTaggedText).ToUpper());
            startIndex = text.IndexOf(openTag, startIndex + 1);
            endIndex += 9;
        }
        modifiedText = modifiedText.Append(text.Substring(endIndex));
        Console.WriteLine(modifiedText);
    }
}