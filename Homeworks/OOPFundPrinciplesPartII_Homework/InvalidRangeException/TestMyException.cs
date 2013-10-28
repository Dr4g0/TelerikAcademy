/*Define a class InvalidRangeException<T> that holds information about an error condition related to 
 * invalid range. It should hold error message and a range definition [start … end].
 * Write a sample application that demonstrates the InvalidRangeException<int> and 
 * InvalidRangeException<DateTime> by entering numbers in the range [1..100] and dates 
 * in the range [1.1.1980 … 31.12.2013].
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvalidRangeException
{
    class TestMyException
    {
        static void TestRangeValues<T>(T userData, T start, T end)
            where T : IComparable
        {
            if ((dynamic)userData<start||(dynamic)userData>end)
            {
                throw new InvalidRangeException<T>("The value is out of the range", start, end);
            }
        }

        static void Main()
        {
            int startRange = 1;
            int endRange = 100;
            int userNumber;
            string inputNumber;

            do
            {
            Console.WriteLine("Input a number in the range [{0}...{1}]",startRange,endRange);
               inputNumber=Console.ReadLine();
            }
            while(!Int32.TryParse(inputNumber,out userNumber));
            
            try
            {
                TestRangeValues(userNumber, startRange, endRange);
                Console.WriteLine("Your number {0} is in the range",userNumber);
            }
            catch (InvalidRangeException<int> ire)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("{0} [{1}...{2}]", ire.Message, ire.StartValue, ire.EndValue);
                Console.ResetColor();
            }

            DateTime startDate = new DateTime(1980, 01, 01);
            DateTime endDate = new DateTime(2013, 12, 31);
            DateTime userDate = new DateTime();
            string inputData;

            do
            {
                Console.WriteLine("Input a date between the range [{0:dd.MM.yyyy}...{1:dd.MM.yyyy}]",startDate,endDate);
                inputData=Console.ReadLine();
            }
            while(!DateTime.TryParse(inputData,out userDate));

            try
            {
                TestRangeValues(userDate, startDate, endDate);
                Console.WriteLine("Your date {0:dd.MM.yyyy} is in the range",userDate);
            }
            catch (InvalidRangeException<DateTime> ire)
            {
               Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("{0} [{1:dd.MM.yyyy}...{2:dd.MM.yyyy}]",ire.Message,ire.StartValue,ire.EndValue);
                Console.ResetColor();
            }
        }
    }
}
