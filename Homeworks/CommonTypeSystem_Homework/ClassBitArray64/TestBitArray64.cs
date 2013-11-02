using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassBitArray64
{
    class TestBitArray64
    {
        static void Main()
        {
            BitArray64 number1 = new BitArray64(255);
            BitArray64 number2 = new BitArray64(1234);
            BitArray64 number3 = new BitArray64(255);
            Console.WriteLine("The binary representation of {0} is {1}", number1.Number, number1);
            Console.WriteLine("Number {0} is equal with {1} - {2}", number1.Number, number2.Number, number1.Equals(number2));
            Console.WriteLine("Number {0} is equal with {1} - {2}", number1.Number, number3.Number, number1.Equals(number3));
            Console.WriteLine("The thirth bit in {0} is {1}", number1.Number, number1[3]);
        }
    }
}
