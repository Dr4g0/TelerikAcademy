using System;
using System.Text;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.Unicode;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(@"
╔══╗    ╔══╗    ╔══╗    ╔═══    ╗   ╔     ╔═══
║  ║    ║  ║    ║  ║    ║       ╚╗ ╔╝     ║
╠══╝    ║  ║    ╠══╝    ╠══      ╚╬╝      ╠══
║       ║  ║    ║       ║         ║       ║
║       ╚══╝    ║       ╚═══      ║       ╚═══
");
        Console.SetCursorPosition(10, 7);
        Console.WriteLine("THE SPINACH DESTROYER");
        Console.SetCursorPosition(0, 30);
    }
}
