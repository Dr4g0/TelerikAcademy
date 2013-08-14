//Write a program that converts a string to a sequence of C# Unicode character literals. 
//Use format strings. 

using System;
using System.Text;

class ConvertStringToUnicodeLiterals
{
    static void Main()
    {
        Console.Write("Enter a string:");
        string text = Console.ReadLine();
        for (int i = 0; i < text.Length; i++)
		{
			Console.Write(String.Format("{0}{1}","\\u",Convert.ToString(char.ConvertToUtf32(text,i)).PadLeft(4,'0')));
		}
        Console.WriteLine();
    }
}