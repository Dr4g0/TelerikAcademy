using System;
using System.Text;
using System.Threading;

class ConsoleGame
{
    static Random randomPosition = new Random();
    static char[,] playfieldMatrix;
    static char popeyeSymbol = (char)001;
    static int popeyeX = 0;
    static int popeyeY = 0;
    static int windowHeight = Console.BufferHeight = Console.WindowHeight = 20;
    static int playfield = windowHeight - 5;
    static int windowWidth = Console.BufferWidth = Console.WindowWidth = 30;

    static void Main()
    {
        Console.OutputEncoding = Encoding.Unicode;
        Console.CursorVisible = false;
        Console.SetCursorPosition(0, playfield);
        Console.WriteLine(new String('═', windowWidth));
        popeyeX = playfield / 2;
        playfieldMatrix = new char[playfield, windowWidth];
        playfieldMatrix[popeyeX,popeyeY] = popeyeSymbol;
        GenerateRightColumnOfSymbols(playfield, windowWidth, playfieldMatrix);
    }


    static void GenerateRightColumnOfSymbols(int playfield, int windowWidth, char[,] matrix)
    {
        Random bonusSymbol = new Random();
        Random randomEnemySymbol = new Random();
        int symbolPosition = randomPosition.Next(0, playfield - 1);
        char[] popeyeBonusSymbols = { 'S' };
        int indexBonusSymbol = bonusSymbol.Next(0, popeyeBonusSymbols.Length);
        char[] symbols = { '#', '@', '*', (char)0xF, popeyeBonusSymbols[indexBonusSymbol] };
        int indexEnemySymbol = randomEnemySymbol.Next(0, symbols.Length);
        matrix[symbolPosition, windowWidth - 1] = symbols[indexEnemySymbol];
        MovingObjects(symbolPosition, symbols[indexEnemySymbol], matrix);
    }

    static void MovingObjects(int symbolPosition, char symbol, char[,] matrix)
    {
        while (true)
        {
            while (Console.KeyAvailable)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                playfieldMatrix[popeyeX, popeyeY] = '\0';
                if (pressedKey.Key == ConsoleKey.LeftArrow)
                {
                    if (popeyeY - 1 >= 0)
                    {
                        popeyeY--;
                    }
                }
                if (pressedKey.Key == ConsoleKey.RightArrow)
                {
                    if (popeyeY + 1 < playfieldMatrix.GetLength(1))
                    {
                        popeyeY++;
                    }
                }
                if (pressedKey.Key == ConsoleKey.UpArrow)
                {
                    if (popeyeX - 1 >= 0)
                    {
                        popeyeX--;
                    }
                }
                if (pressedKey.Key == ConsoleKey.DownArrow)
                {
                    if (popeyeX + 1 < playfieldMatrix.GetLength(0))
                    {
                        popeyeX++;
                    }
                }
            }
            
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    if (col==popeyeY-1&&rows==popeyeX)
                    {
                        
                    }
                    else
                    {
                        matrix[rows, col] = matrix[rows, col + 1];
                        matrix[rows, col + 1] = '\0';
                    }
                }
            }
            playfieldMatrix[popeyeX, popeyeY] = popeyeSymbol;
            PrintMatrix(matrix);
            Thread.Sleep(150);
            GenerateRightColumnOfSymbols(matrix.GetLength(0), matrix.GetLength(1), matrix);
        }
    }

    static void PrintMatrix(char[,] matrix)
    {
        //Console.Clear();
        Console.SetCursorPosition(0, 0);
        for (int rows = 0; rows < matrix.GetLength(0); rows++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (matrix[rows,col]==popeyeSymbol)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                else if (matrix[rows, col] == 'S')
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                Console.Write(matrix[rows, col]);
               
            }
        }
    }
}
