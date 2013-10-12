using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.ImplementSubstring
{
    class TestSubstring
    {
        static void Main()
        {
            StringBuilder test = new StringBuilder();
            test.Append("Hello, C Sharp!");
            StringBuilder result = new StringBuilder(test.Substring(7, 7).ToString());
            Console.WriteLine(result);
        }
    }
}
