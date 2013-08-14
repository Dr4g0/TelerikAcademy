//Write a program for extracting all email addresses from given text. 
//All substrings that match the format <identifier>@<host>…<domain> should be recognized as emails.

using System;
using System.Text;

class ExtractEmailAddresses
{
    static void Main()
    {
        //using Yahoo format for local part: Only letters, numbers, underscores, and one dot (.) are allowed
        //accept that first left '.' (before any punctuations or whitespace characters) is part of the email address.
        //domain part - only letters, numbers and maximum two dots (.)
        const string InputText = @"
    By simply sending an email to .John.Smith123@txt.att.net for example, 
    you can send text messages to cell phones via email. This simple technology can also be applied to your DIY projects. 
    For example, if you were creating a DIY security system, you could use your computer’s parallel port to automatically text you if your alarm goes off.
    AT&T – cellnumber@txt.att.net
    Verizon – cellnumber@vtext.com
    T-Mobile – cellnumber@tmomail.net
    Sprint PCS - cellnumber@messaging.sprintpcs.com.com
    Virgin Mobile – cellnumber@vmobl.com
    US Cellular – cellnumber@email.uscc.net
    Nextel - cellnumber@messaging.nextel.com
    Boost - cellnumber@myboostmobile.com
    Alltel – cellnumber@message.alltel.com
    For more cell phone hacks, check out our entire collection and subscribe for more.";
        int startIndex = InputText.IndexOf("@");
        while (startIndex!=-1)
        {
            int index = startIndex;
            StringBuilder currentEmailAddress = new StringBuilder("@");
            int doteCounter = 0;
            while (Char.IsLetterOrDigit(InputText,index-1)||InputText[index-1]=='_'||(InputText[index-1]=='.'&&doteCounter<1))
            {
                if (InputText[index-1]=='.')
                {
                    doteCounter++;
                }
                currentEmailAddress.Insert(0, InputText[index - 1]);
                index--;
            }
            index = startIndex;
            doteCounter = 0;
            while (Char.IsLetterOrDigit(InputText, index + 1) || (InputText[index + 1] == '.' && doteCounter < 2))
            {
                if (InputText[index - 1] == '.')
                {
                    doteCounter++;
                }
                currentEmailAddress.Append(InputText[index + 1]);
                index++;
            }
            Console.WriteLine(currentEmailAddress);
            startIndex = InputText.IndexOf("@",startIndex+1);
        }
    }
}