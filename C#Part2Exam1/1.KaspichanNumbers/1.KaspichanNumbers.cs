using System;
using System.Text;

    class KaspichanNumbers
    {
        static void Main()
        {
            ulong number=ulong.Parse(Console.ReadLine());
            int counter = 0;
            string[] kaspichanDigits = new string[256];
            while (counter<256)
            {
                if (counter<26)
                {
                    kaspichanDigits[counter]=((char)(counter+65)).ToString();
                }
                else
                {
                    kaspichanDigits[counter] = (char)(counter/26+96)+((char)(counter %26+ 65)).ToString();
                }
                counter++;
            }
            StringBuilder finishNumber = new StringBuilder();
            if (number==0)
            {
                finishNumber.Append("A");
            }
            else
            {
                while (number > 0)
                {
                    string lastDigit = kaspichanDigits[number % 256];
                    finishNumber.Insert(0, lastDigit);
                    number /= 256;
                }
            }
            Console.WriteLine(finishNumber);
        }
    }