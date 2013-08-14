//Write a program that extracts from a given text all dates that match the format DD.MM.YYYY. 
//Display them in the standard date format for Canada.

using System;
using System.Globalization;
using System.Threading;

class ExtractDatesInSpecificFormat
{
    static void Main()
    {
        //we are looking for exactly "dd.mm.yyyy" format
        Thread.CurrentThread.CurrentCulture = new CultureInfo("bg-BG");
        const string InputText = @"Анджелина Джоли е родена на 04.6.1975 година в семейството на американския актьор Джон Войт и френската актриса Маршелин Бертран.
На 28.03.1996г. се жени за британския актьор Джони Лий Милър, с когото се запознава по време на снимките на филма „Хакери“ (развеждат се на 03.02.1999 г.).
На 5.05.2000г. се жени за актьора Били Боб Торнтон (развеждат се на 27.05.2003г.).";
        for (int i = 0; i < InputText.Length-9; i++)
        {
            DateTime currentDate = new DateTime();
            if (Char.IsDigit(InputText[i]))
            {
                string possibleDate=InputText.Substring(i,10).Trim();
                bool parseToDate = DateTime.TryParseExact(possibleDate, "dd.MM.yyyy", CultureInfo.CurrentCulture, DateTimeStyles.None, out currentDate);
                if (parseToDate)
                {
                    if ((i+10<InputText.Length&&!Char.IsDigit(InputText[i+10]))||(i+10==InputText.Length)
                        &&(i>0&&!Char.IsLetterOrDigit(InputText[i-1])||i==0))
                    {
                        Thread.CurrentThread.CurrentCulture = new CultureInfo("en-Ca");
                        Console.WriteLine(currentDate.ToShortDateString());
                        Thread.CurrentThread.CurrentCulture = new CultureInfo("bg-BG");
                        i += 9;
                    }
                }
            }
        }
    }
}