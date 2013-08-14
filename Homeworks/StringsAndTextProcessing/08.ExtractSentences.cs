//Write a program that extracts from a given text all sentences containing given word.
//Example: The word is "in". The text is:
//      "We are living in a yellow submarine. We don't have anything else. 
//      Inside the submarine is very tight. So we are drinking all the day. 
//      We will move out of it in 5 days."
//The expected result is:
//      "We are living in a yellow submarine.
//      We will move out of it in 5 days."
//Consider that the sentences are separated by "." and the words – by non-letter symbols.

using System;
using System.Text;

class ExtractSentences
{
    static void Main()
    {
        //case insensitive search
        const string Text = "We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
        const string Word = "in";
        StringBuilder rezultString = new StringBuilder();
        int indexOFWord = Text.ToLower().IndexOf(Word.ToLower());
        while (indexOFWord!=-1)
        {
            string currentSentence=ExtractSentence(Text, Word, indexOFWord);
            bool checkForWord=CheckIsItWord(currentSentence,Word);
            if (checkForWord)
            {
                rezultString.Append(currentSentence);
            }
            int nextStartIndex = Text.IndexOf('.', indexOFWord);
            indexOFWord = Text.ToLower().IndexOf(Word.ToLower(), nextStartIndex+1);
        }
        Console.WriteLine(rezultString);
    }

    static string ExtractSentence(string allText, string word, int index)
    {
        int leftSeparatorIndex = allText.Substring(0,index).LastIndexOf('.');
        int rightSeparatorIndex = allText.Substring(index).IndexOf('.')+index;
        string sentence = allText.Substring(leftSeparatorIndex + 1, rightSeparatorIndex - leftSeparatorIndex);
        return sentence;
    }

    static bool CheckIsItWord(string sentence,string word)
    {
        bool check = false;
        sentence = sentence.ToLower();
        word = word.ToLower();
        int index = sentence.IndexOf(word);
        while (index!=-1)
        {
            if (index>0&&(index+word.Length<sentence.Length))
            {
                if (!(Char.IsLetter(sentence,index-1)||Char.IsLetter(sentence,index+word.Length)))
                {
                    check = true;
                    break;
                }  
            }
            if (index==0)
            {
                if (!Char.IsLetter(sentence,index+word.Length))
                {
                    check = true;
                    break;
                }
            }
            if (index + word.Length == sentence.Length)
            {
                if (!(Char.IsLetter(sentence, index - 1)))
                {
                    check = true;
                    break;
                }
            }
            index = sentence.IndexOf(word, index + 1);
        }
        return check;
    }
}