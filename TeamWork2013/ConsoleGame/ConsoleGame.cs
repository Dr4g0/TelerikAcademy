using System;
using System.Text;
using System.Threading;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.IO;
using System.Media;

namespace ConsoleGame
{
    class ConsoleGame
    {
        static char[,] playfieldMatrix;
        static char popeyeSymbol = (char)001;
        static int popeyeX = 0;
        static int popeyeY = 0;
        static int previousPopeyeX = 0;
        static int previousPopeyeY = 0;
        static int windowHeight = Console.BufferHeight = Console.WindowHeight = 20;
        static int playfieldHeigth = windowHeight - 5;
        static int windowWidth = Console.BufferWidth = Console.WindowWidth = 40;
        static int liveScore = 3;
        static int score = 0;
        static int levels = 1;
        static int sleepTime = 300;
        static int sleepTimeCopy = 300;
        static char[] popeyeBonusSymbols = { 'S', 'P', 'I', 'N', 'A', 'C', 'H' };
        static char[] enemySymbols = { '#', '@', '*', '&' };
        static List<char> collected = new List<char>();
        static char[] underlinesAndLetters = { '_', ' ', '_', ' ', '_', ' ', '_', ' ', '_', ' ', '_', ' ', '_' };
        static SoundPlayer melody1 = new SoundPlayer(@"..\..\tada.wav");
        static SoundPlayer sp = new SoundPlayer(@"..\..\Popeye10sec.wav");
        static SoundPlayer player = new SoundPlayer(@"..\..\ThePopcornSong.wav");
        static SoundPlayer bombSound = new SoundPlayer(@"..\..\bomb.wav");

        static void Main()
        {
            //PlayMainMusic();
            sp.PlayLooping();
            PrintInscriptions.SetIntroPositionsAndColors();
            sp.Stop();
            player.PlayLooping();
            windowHeight = Console.BufferHeight = Console.WindowHeight = 20;
            playfieldHeigth = windowHeight - 5;
            windowWidth = Console.BufferWidth = Console.WindowWidth = 40;
            Console.Clear();
            Console.OutputEncoding = Encoding.Unicode;
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, playfieldHeigth);
            Console.WriteLine(new String('═', windowWidth));
            PrintLiveScore();
            PrintScore();
            PrintLevels();
            PrintCollected();
            PrintOnStringPosition(15, playfieldHeigth / 2, "Level " + levels, ConsoleColor.Gray);
            Thread.Sleep(1500); //time for seeing the text "Level 1" on the console
            popeyeX = playfieldHeigth / 2;
            playfieldMatrix = new char[playfieldHeigth, windowWidth];
            playfieldMatrix[popeyeX, popeyeY] = popeyeSymbol;
            GenerateRightColumnOfSymbols(playfieldHeigth, windowWidth, playfieldMatrix);
        }

        private static void PrintCollected()
        {
            for (int i = 0; i < underlinesAndLetters.Length; i++)
            {
                Console.SetCursorPosition(i + 13, playfieldHeigth + 4);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(underlinesAndLetters[i]);
            }
        }

        private static void PrintLevels()
        {
            PrintOnStringPosition(30, playfieldHeigth + 2, "Level: " + levels, ConsoleColor.DarkYellow);
        }

        private static void PrintScore()
        {
            PrintOnStringPosition(15, playfieldHeigth + 2, "Score: " + score, ConsoleColor.DarkCyan);
        }

        static void PrintLiveScore()
        {
            PrintOnStringPosition(0, playfieldHeigth + 2, "Lives: " + liveScore, ConsoleColor.Gray);
            if (liveScore == 0)
            {
                GameOver();
            }
        }

        static void GenerateRightColumnOfSymbols(int playfieldHigth, int windowWidth, char[,] matrix)
        {
            int chance = ReturnRandomNumer(100);  //chance to appear the symbol for a bomb
            char bombSymbol = 'B';
            int indexBonusSymbol = ReturnRandomNumer(popeyeBonusSymbols.Length);
            List<char> symbols = new List<char>(enemySymbols);
            symbols.Add(popeyeBonusSymbols[indexBonusSymbol]);
            if (chance < 5)
            {
                symbols.Add(bombSymbol);
            }
            int indexSymbol = ReturnRandomNumer(symbols.Count);
            int symbolPosition = ReturnRandomNumer(playfieldHigth);
            matrix[symbolPosition, windowWidth - 1] = symbols[indexSymbol];
            MovingObjects(symbolPosition, symbols[indexSymbol], matrix);
        }

        static void MovingObjects(int symbolPosition, char symbol, char[,] matrix)
        {
            while (liveScore > 0)
            {
                while (Console.KeyAvailable)
                {
                    previousPopeyeX = popeyeX;
                    previousPopeyeY = popeyeY;
                    ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                    playfieldMatrix[popeyeX, popeyeY] = '\0';
                    if (pressedKey.Key == ConsoleKey.LeftArrow)
                    {
                        if (popeyeY - 1 >= 0)
                        {
                            popeyeY--;
                            TestCollisions(matrix);
                        }
                    }
                    if (pressedKey.Key == ConsoleKey.RightArrow)
                    {
                        if (popeyeY + 1 < playfieldMatrix.GetLength(1))
                        {
                            popeyeY++;
                            TestCollisions(matrix);
                        }
                    }
                    if (pressedKey.Key == ConsoleKey.UpArrow)
                    {
                        if (popeyeX - 1 >= 0)
                        {
                            popeyeX--;
                            TestCollisions(matrix);
                        }
                    }
                    if (pressedKey.Key == ConsoleKey.DownArrow)
                    {
                        if (popeyeX + 1 < playfieldMatrix.GetLength(0))
                        {
                            popeyeX++;
                            TestCollisions(matrix);
                        }
                    }
                }

                for (int rows = 0; rows < matrix.GetLength(0); rows++)
                {
                    for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                    {
                        if (!(col == popeyeY - 1 && rows == popeyeX))
                        {
                            matrix[rows, col] = matrix[rows, col + 1];
                            matrix[rows, col + 1] = '\0';
                        }
                        if ((col == popeyeY) &&
                            (rows == popeyeX) && (matrix[rows, col] != '\0'))
                        {
                            Collisions(matrix[rows, col]);
                            PrintLiveScore();
                            PrintScore();
                            PrintLevels();
                            //PrintCollected();
                        }
                    }
                }
                playfieldMatrix[popeyeX, popeyeY] = popeyeSymbol;
                PrintMatrix(matrix);
                if (sleepTimeCopy >= 0)
                {
                    sleepTime = sleepTimeCopy;
                }
                Thread.Sleep(sleepTime);
                PrintLiveScore();
                PrintScore();
                PrintLevels();
                //PrintCollected();
                GenerateRightColumnOfSymbols(matrix.GetLength(0), matrix.GetLength(1), matrix);
            }
        }

        static void TestCollisions(char[,] matrix)
        {
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    if ((col == popeyeY) &&
                        (rows == popeyeX) && (matrix[rows, col] != '\0'))
                    {
                        Collisions(matrix[rows, col]);
                        PrintLiveScore();
                        PrintScore();
                        PrintLevels();
                        PrintCollected();
                    }
                }
            }
        }

        static void Collisions(char symbol)
        {
            if (Array.IndexOf(popeyeBonusSymbols, symbol) > -1)
            {
                Console.Beep(528, 1000 / 3);
                score += 10;
                if (!collected.Contains(symbol))
                {
                    collected.Add(symbol);
                    switch (symbol)
                    {
                        case 'S':
                            {
                                underlinesAndLetters[0] = 'S';
                                break;
                            }
                        case 'P':
                            {
                                underlinesAndLetters[2] = 'P';
                                break;
                            }
                        case 'I':
                            {
                                underlinesAndLetters[4] = 'I';
                                break;
                            }
                        case 'N':
                            {
                                underlinesAndLetters[6] = 'N';
                                break;
                            }
                        case 'A':
                            {
                                underlinesAndLetters[8] = 'A';
                                break;
                            }
                        case 'C':
                            {
                                underlinesAndLetters[10] = 'C';
                                break;
                            }
                        case 'H':
                            {
                                underlinesAndLetters[12] = 'H';
                                break;
                            }
                    }
                    PrintCollected();
                }
                if (collected.Count == 7)
                {
                    Thread.Sleep(1000);
                    levels++;
                    melody1.PlaySync();
                    player.PlayLooping();
                    if (sleepTimeCopy < 70)
                    {
                        sleepTimeCopy = 0;
                    }
                    else
                    {
                        sleepTimeCopy -= 70;
                    }
                    //collected.RemoveAll(item => item == 'S');
                    //collected.RemoveAll(item => item == 'P');
                    //collected.RemoveAll(item => item == 'I');
                    //collected.RemoveAll(item => item == 'N');
                    //collected.RemoveAll(item => item == 'A');
                    //collected.RemoveAll(item => item == 'C');
                    //collected.RemoveAll(item => item == 'H');
                    collected.Clear();
                    for (int i = 0; i < underlinesAndLetters.Length; i++)
                    {
                        if (i == 0 || i % 2 == 0)
                        {
                            underlinesAndLetters[i] = '_';
                        }
                        else
                        {
                            underlinesAndLetters[i] = ' ';
                        }
                    }
                    Console.Clear();
                    Console.SetCursorPosition(0, playfieldHeigth);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(new String('═', windowWidth));
                    PrintLiveScore();
                    PrintScore();
                    PrintLevels();
                    PrintCollected();
                    PrintOnStringPosition(15, playfieldHeigth / 2, "Level " + levels, ConsoleColor.Gray);
                    Thread.Sleep(1500); //time for seeing the text "Level 1" on the console
                    for (int rows = 0; rows < playfieldMatrix.GetLength(0); rows++)
                    {
                        for (int col = 0; col < playfieldMatrix.GetLength(1); col++)
                        {
                            playfieldMatrix[rows, col] = '\0';
                        }
                    }
                }
                if (score % 200 == 0 && liveScore < 3)
                {
                    liveScore++;
                }

            }
            else if (Array.IndexOf(enemySymbols, symbol) > -1)
            {
                liveScore--;
                PrintOnStringPosition(previousPopeyeY, previousPopeyeX, " ", ConsoleColor.Black);
                PrintOnStringPosition(popeyeY, popeyeX, "X", ConsoleColor.Yellow);
                PrintOnStringPosition(popeyeY + 1, popeyeX, " ", ConsoleColor.Black);
                Console.Beep();

            }
            else if (symbol == 'B')
            {
                Console.BackgroundColor = ConsoleColor.Red;
                for (int rows = 0; rows < playfieldMatrix.GetLength(0); rows++)
                {
                    for (int col = 0; col < playfieldMatrix.GetLength(1); col++)
                    {
                        playfieldMatrix[rows, col] = '\0';
                    }
                }
                PrintOnStringPosition(5, 5, @"
╔══╗  ╔══╗ ╔══╗ ╔╗  ╔╗   ║
║  ║  ║  ║ ║  ║ ║╚╗╔╝║   ║
╠══╩╗ ║  ║ ║  ║ ║ ╚╝ ║   ║
║   ║ ║  ║ ║  ║ ║    ║   ║
╚═══╝ ╚══╝ ╚══╝ ╝    ╚   O
", ConsoleColor.Yellow);

                bombSound.PlaySync();
                player.PlayLooping();
                Thread.Sleep(1000);
                Console.BackgroundColor = ConsoleColor.Black;
            }
        }

        static void GameOver()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(5, 5);
                throw new Exception();
            }
            catch (Exception)
            {
                Console.Clear();
                windowHeight = Console.BufferHeight = Console.WindowHeight = 50;
                windowWidth = Console.BufferWidth = Console.WindowWidth = 170;
                Console.ForegroundColor = ConsoleColor.Red;
                try
                {
                    StreamReader bombPicture = new StreamReader(@"..\..\bombPicture.txt");
                    using (bombPicture)
                    {
                        string line = bombPicture.ReadLine();
                        while (line != null)
                        {
                            Console.WriteLine(line);
                            line = bombPicture.ReadLine();
                        }
                    }
                }

                catch (FileNotFoundException)
                {
                    PrintInscriptions.PrintNiceAlphabet("ooops", 0, 0, ConsoleColor.Red);
                }
                //                Console.WriteLine(@"
                //                                           ъ
                //                                    ,se%n.   ,  щ
                //                                 ,seэ'  `э'щ,$
                //                               ,sэ'  щ  `s,,$$.   щ
                //                           ,. ,$'   ъ  щ `$F^?$э'  ъ
                //       .,ssSS$$$SSss,.  .sS$$s;э        ,э'$s$$, щ
                //    ,sS$$$$$$$$$$$$$$$s$$$$$$$$,      щ  щ $'щ`э.
                //  ,s$?M$$$$$$$$$$$$$$$$$$$$$$э'            ' ъ  ъ
                // ,$V;;tY$$$$$$$$$$$$$$$$$$$F'         ъ   щ      щ
                //,$Y;;tYV$$$$$$$$$$$$$$$$$$$$,
                //$Y;;tYH$$$$$$$$$$$$$$$$$$$$$$
                //$;;iYV$$$$$$$$$$$$$$$$$$$$$$$
                //$=;IYYV$$$$$$$$$$$$$$$$$$$$$$
                //`Y;;YV$$$$$$$$$$$$$$$$$$$$$$'
                // `$YV$$$$$$$$$$$$$$$$$$$$$$'
                //  `э$$$$$$$$$$$$$$$$$$$$$э'
                //    `эS$$$$$$$$$$$$$$$Sэ'
                //       `'ээSS$$$SSээ''");
                Thread.Sleep(800);
                PrintInscriptions.PrintNiceAlphabet("you are death", 30, 15, ConsoleColor.Yellow);
                PrintInscriptions.PrintNiceAlphabet("my muscled friend", 40, 25, ConsoleColor.Blue);
                Thread.Sleep(2000);
                Console.WriteLine("Play again? y/n:");
                if (Console.ReadLine()=="y")
                {
                    score = 0;
                    liveScore = 3;
                    levels = 1;
                    Console.Clear();
                    Console.SetCursorPosition(0, 0);
                    Main();
                }
                //Environment.Exit(-1);
            }
        }

        static void PrintMatrix(char[,] matrix)
        {
            Console.SetCursorPosition(0, 0);
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[rows, col] == popeyeSymbol)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    }
                    else if (matrix[rows, col] == 'S' || matrix[rows, col] == 'P' || matrix[rows, col] == 'I' || matrix[rows, col] == 'N' ||
                        matrix[rows, col] == 'A' || matrix[rows, col] == 'C' || matrix[rows, col] == 'H')
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else if (matrix[rows, col] == 'B')
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    Console.Write(matrix[rows, col]);

                }
            }
        }
        public static void PrintOnStringPosition(int col, int row, string str, ConsoleColor color)
        {
            Console.SetCursorPosition(col, row);
            Console.ForegroundColor = color;
            for (int i = 0; i < str.Length; i++)
            {
                if ((int)str[i] == 13)
                {
                    if (i != 0)
                    {
                        Console.SetCursorPosition(col, ++row);
                    }
                    i++;
                }
                else
                {
                    Console.Write(str[i]);
                }
            }
            Console.WriteLine();
        }

        static int ReturnRandomNumer(int numbers)
        {
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] data = new byte[1];
                rng.GetBytes(data);
                byte value = Buffer.GetByte(data, 0);
                int rezult = value % numbers;
                return rezult;
            }
        }
        //static void PlayMainMusic()
        //{
        //    SoundPlayer mainMusic = new SoundPlayer();
        //    using (mainMusic)
        //    {
        //        mainMusic.SoundLocation = (@"..\..\Popeye - HQ Original Theme Tune.wav");
        //        mainMusic.PlayLooping();
        //    }
        //}
    }
}

