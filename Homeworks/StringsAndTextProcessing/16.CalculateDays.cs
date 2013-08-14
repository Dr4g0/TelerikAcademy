//Write a program that reads two dates in the format: day.month.year and calculates the number of days between them.

using System;
using System.Globalization;
using System.Threading;

class CalculateDays
{
    static void Main()
    {
        //we will calculate distance between days, including difference in years.
        Thread.CurrentThread.CurrentCulture = new CultureInfo("bg-BG");

        DateTime firstDate = DateTime.Parse("25.05.2010"); //hardcore dates
        DateTime secondDate = DateTime.Parse("25.04.2008"); //hardcore dates
        
        //Console.Write("Enter first date (day.month.year): ");
        //DateTime firstDate = DateTime.Parse(Console.ReadLine());
        //Console.Write("Enter second date (day.month.year): ");
        //DateTime secondDate = DateTime.Parse(Console.ReadLine());
        int distance = Math.Abs(int.Parse((secondDate - firstDate).Days.ToString()));
        Console.WriteLine("The distance between two dates is {0} days.",distance);
    }
}