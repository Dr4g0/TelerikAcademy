//Write a program that finds how many times a substring is contained in a given text (perform case insensitive search).
//Example: The target substring is "in". The text is as follows:
//  "We are living in an yellow submarine. We don't have anything else. 
//  Inside the submarine is very tight. So we are drinking all the day. 
//  We will move out of it in 5 days."
//The result is: 9.

using System;

class CountSubstring
{
    static void Main()
    {
        string hardcoreText = "We are living in an yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
        Console.WriteLine("The text is:");
        Console.WriteLine("\"{0}\"",hardcoreText);
        Console.Write("Enter the substring we looking for: ");
        string lookingSubstring = Console.ReadLine();
        int counter = 0;
        //insensitive search
        hardcoreText = hardcoreText.ToLower();
        lookingSubstring = lookingSubstring.ToLower();
        int startIndex = hardcoreText.IndexOf(lookingSubstring);
        while (startIndex!=-1)
        {
            counter++;
            startIndex = hardcoreText.IndexOf(lookingSubstring, startIndex + 1);
        }
        Console.WriteLine("Insensitive search! The rezult is:{0}",counter);
    }
}