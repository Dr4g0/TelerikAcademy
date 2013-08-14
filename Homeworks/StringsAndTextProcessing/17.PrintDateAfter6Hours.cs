//Write a program that reads a date and time given in the format: day.month.year hour:minute:second and prints 
//the date and time after 6 hours and 30 minutes (in the same format) along with the day of week in Bulgarian.

using System;
using System.Globalization;
using System.Threading;

class PrintDateAfter6Hours
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = new CultureInfo("bg-BG");

        //DateTime date = DateTime.Parse("10.08.2013 23:10:14"); //hardcore date

        //user's data input
        Console.Write("Enter date and time (day.month.year hour:minute:second): ");
        DateTime date = DateTime.Parse(Console.ReadLine());

        DateTime newDate = date.AddHours(6).AddMinutes(30);
        string dayOfWeekInBulgarian=DateTimeFormatInfo.CurrentInfo.GetDayName(newDate.DayOfWeek);
        Console.WriteLine("The date and time after 6 hours and 30 minutes will be: {0},{1}.",newDate,dayOfWeekInBulgarian);
    }
}