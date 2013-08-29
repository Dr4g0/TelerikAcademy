using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _9GagNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string allNumberAs9Gag = Console.ReadLine();
            List<int> splitNumbers = new List<int>();
            while (allNumberAs9Gag.Length>0)
            {
                string firstTwoSymbols = allNumberAs9Gag.Substring(0, 2);
                switch (firstTwoSymbols)
                {
                        case "-!":
                        splitNumbers.Insert(0, 0);
                        allNumberAs9Gag = allNumberAs9Gag.Remove(0, 2);
                            break;
                        case "**": 
                        splitNumbers.Insert(0, 1);
                        allNumberAs9Gag = allNumberAs9Gag.Remove(0, 2);
                            break;
                        case "!!":
                            if (allNumberAs9Gag[2]=='!')
                            {
                                splitNumbers.Insert(0,2);
                                
                                allNumberAs9Gag = allNumberAs9Gag.Remove(0, 3);
                            }
                            else
                            {
                                splitNumbers.Insert(0, 8);
                                
                                allNumberAs9Gag = allNumberAs9Gag.Remove(0, 6);
                            }
                            break;
                        case "&&": 
                        splitNumbers.Insert(0, 3);
                        allNumberAs9Gag = allNumberAs9Gag.Remove(0, 2);
                            break;
                        case "&-": 
                        splitNumbers.Insert(0, 4);
                        allNumberAs9Gag = allNumberAs9Gag.Remove(0, 2);
                            break;
                        case "!-":
                        splitNumbers.Insert(0, 5);
                        allNumberAs9Gag = allNumberAs9Gag.Remove(0, 2);
                            break;
                        case "*!": 
                        splitNumbers.Insert(0,6);
                        allNumberAs9Gag = allNumberAs9Gag.Remove(0, 4);
                            break;
                        case "&*": 
                        splitNumbers.Insert(0, 7);
                        allNumberAs9Gag = allNumberAs9Gag.Remove(0, 3);
                            break;
                }
            }
            BigInteger finishRezult = 0;
            for (int i = 0; i < splitNumbers.Count; i++)
            {
                finishRezult += BigInteger.Pow(9, i) * splitNumbers[i];
            }
            Console.WriteLine(finishRezult);
        }
    }
}
