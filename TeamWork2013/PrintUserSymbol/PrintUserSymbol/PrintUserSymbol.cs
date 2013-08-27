using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyMethods
{
    class MyMethods
    {
        public static int liveScore = 5;

        struct Popeye
        {
            public int x;
            public int y;
            public char symbol;
            public ConsoleColor color;
        }

        static void PrintTheUserSymbol(int x, int y, char c, ConsoleColor color = ConsoleColor.Cyan)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.Write(c);
        }

        static void Main()
        {
            int windowHeight = Console.BufferHeight = Console.WindowHeight = 25;
            int playfield = windowHeight - 10;
            int windowWidth = Console.BufferWidth = Console.WindowWidth = 60;

            liveScore = 5;  //for example

            Popeye user = new Popeye();
            user.y = playfield / 2;
            user.x = 0;
            user.symbol = (char)001;
            user.color = ConsoleColor.Yellow;
            PrintTheUserSymbol(user.x, user.y, user.symbol, user.color);
            Console.ReadLine();
        }
    }
}