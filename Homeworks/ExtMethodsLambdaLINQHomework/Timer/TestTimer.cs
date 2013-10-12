using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Timer
{
    class TestTimer
    {
        static void Main()
        {
            int currentDelay = 1;
            int numbers = 10;
            Console.WriteLine("This test print the numbers from {0} to 1 with delay from {1} seconds\r\n", numbers, currentDelay);
            TimerDelegate td = new TimerDelegate(PrintNumbers);
            Timer testTimer = new Timer(td, currentDelay, numbers);
            Thread threadTimer = new Thread(new ThreadStart(testTimer.Run));
            threadTimer.Start();
            Console.WriteLine("But may be this message prints first //demonstrate independent timer thread ffom main code");
        }

        private static void PrintNumbers(int number)
        {
            Console.WriteLine(number);
        }
    }
}
