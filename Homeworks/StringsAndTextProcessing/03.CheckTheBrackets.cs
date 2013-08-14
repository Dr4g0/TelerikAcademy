//Write a program to check if in a given expression the brackets are put correctly.
//Example of correct expression: ((a+b)/5-d).
//Example of incorrect expression: )(a+b)).

using System;

class CheckTheBrackets
{
    static void Main()
    {
        Console.WriteLine("Enter an expression:");
        string expression = Console.ReadLine();
        char openBracket = '(';
        char closedBracket = ')';
        int counter = 0;
        bool corecctlyBrackets = false;
        for (int i = 0; i < expression.Length; i++)
        {
            if (expression[i]==openBracket)
            {
                counter++;
            }
            else if (expression[i] == closedBracket)
            {
                counter--;
            }
            if (counter<0)
            {
                break;
            }
        }
        if (counter==0)
        {
            corecctlyBrackets = true;
        }
        if (corecctlyBrackets)
        {
            Console.WriteLine("The bracket are put correctly.");
        }
        else
        {
            Console.WriteLine("The bracket are put incorrectly.");
        }
    }
}