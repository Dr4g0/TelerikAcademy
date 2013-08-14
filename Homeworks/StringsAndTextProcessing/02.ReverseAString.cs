//Write a program that reads a string, reverses it and prints the result at the console.
//Example: "sample" -> "elpmas".

using System;
using System.Text;

class ReverseAString
{
    static void Main()
    {
        Console.WriteLine("Enter some string:");
        string stringToReverse = Console.ReadLine();
        char[] tmpArray = stringToReverse.ToCharArray();
        StringBuilder reversedString = new StringBuilder();
        for (int i = tmpArray.Length-1; i >=0; i--)
        {
            reversedString = reversedString.Append(tmpArray[i]);
        }
        Console.WriteLine("The reversed string sound like that: {0}",reversedString);
    }
}