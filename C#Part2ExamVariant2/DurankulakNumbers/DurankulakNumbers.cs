using System;
using System.Numerics;

    class DurankulakNumbers
    {
        static void Main()
        {
            string durankulakNumber = Console.ReadLine();
            string[] numbers = new string[168];
            for (int i = 0; i < 168; i++)
            {
                if (i<26)
                {
                    numbers[i] = Convert.ToString((char)(i + 65));
                }
                else
                {
                    numbers[i] = Convert.ToString((char)(i / 26 + 96)) + (char)(i % 26 + 65);
                }
            }
            BigInteger decimalNumber = 0;
            int countDurankulakDigits = 0;
            while (durankulakNumber.Length>0)
            {
                if (durankulakNumber.Length>1)
                {
                    if (durankulakNumber[durankulakNumber.Length-2]>96)
                    {
                        string currentDigit = durankulakNumber.Substring(durankulakNumber.Length - 2, 2);
                    decimalNumber += BigInteger.Pow(168, countDurankulakDigits) * Array.LastIndexOf(numbers, currentDigit);
                    durankulakNumber = durankulakNumber.Remove(durankulakNumber.Length - 2, 2);
                    countDurankulakDigits++;
                    }
                    else
                    {
                        string currentDigit = durankulakNumber[durankulakNumber.Length-1].ToString();
                        decimalNumber += BigInteger.Pow(168, countDurankulakDigits) * Array.LastIndexOf(numbers, currentDigit);
                        durankulakNumber = durankulakNumber.Remove(durankulakNumber.Length - 1, 1);
                        countDurankulakDigits++;
                    }
                }
                else
                {
                    decimalNumber+=BigInteger.Pow(168,countDurankulakDigits)*Array.IndexOf(numbers,durankulakNumber[0].ToString());
                    durankulakNumber=durankulakNumber.Remove(0);
                }
                
            }
            Console.WriteLine(decimalNumber);
        }
    }