//Write a program that prints from given array of integers all numbers that are divisible 
//by 7 and 3. Use the built-in extension methods and lambda expressions. Rewrite the same with LINQ.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbersDivideBy3_7
{
    class NumbersDivideBy3_7
    {
        static void Main()
        {
            int[] array = new int[] { 4,5,84,98,78,56,42,84,89,144,551,244,168,899};
            Console.WriteLine("With lambda expressions:");
            var numbersDivideby21 = array.Where(number => number % 21 == 0).Select(number=>number);
            foreach (var number in numbersDivideby21)
            {
                Console.WriteLine(number);
            }
            Console.WriteLine();
            Console.WriteLine("With LINQ:");
            var dividedBy21 =
                from number in array
                where number % 21 == 0
                select number;
            foreach (var number in dividedBy21)
            {
                Console.WriteLine(number);
            }
        }
    }
}
