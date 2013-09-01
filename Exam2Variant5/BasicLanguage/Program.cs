using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicLanguage
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder inputText = new StringBuilder();
            while (true)
            {
                string currentLine = Console.ReadLine();
                inputText.Append(currentLine);
                if (currentLine.Contains("EXIT;"))
                {
                    break;
                }
            }
            //if (inputText[inputText.Length-1] != '\n')
            //{
            //    inputText.Append("\n");
            //}
            string[] commands = inputText.ToString().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            for (long i = 0; i < commands.Length; i++)
            {
                commands[i] = commands[i].Trim();
            }
            for (long i = 0; i < commands.Length; i++)
            {
                StartExecution(commands[i]);
            }
            Console.Write('\n');
        }

        private static void StartExecution(string commandLine)
        {
            if (commandLine==String.Empty)
            {
                return;
            }
            else if (commandLine[0] == 'E')
            {
                return;
            }
            else if (commandLine[0] == 'F')
            {
                long loops = 0;
                int indexOfFirstLeftBRacket = commandLine.IndexOf('(');
                int indexOfFirstRightBracket = commandLine.IndexOf(')');
                int indexOfComma = commandLine.Substring(0,indexOfFirstRightBracket).IndexOf(',');
                if (indexOfComma<0)
                {
                    loops = long.Parse(commandLine.Substring(indexOfFirstLeftBRacket+1, indexOfFirstRightBracket - indexOfFirstLeftBRacket-1));
                }
                else
                {
                    int firstNumber = int.Parse(commandLine.Substring(indexOfFirstLeftBRacket + 1, indexOfComma - indexOfFirstLeftBRacket-1));
                    int secondNumber = int.Parse(commandLine.Substring(indexOfComma + 1, indexOfFirstRightBracket-indexOfComma-1));
                    loops = secondNumber - firstNumber + 1;
                }
                commandLine = commandLine.Substring(indexOfFirstRightBracket + 1).Trim();
                for (long i = 0; i < loops; i++)
                {
                    StartExecution(commandLine);
                }
            }
            else if (commandLine[0]=='P')
            {
                int indexOfFirstLeftBRacket = commandLine.IndexOf('(');
                int indexOfFirstRightBracket = commandLine.IndexOf(')');
                string printText = commandLine.Substring(indexOfFirstLeftBRacket + 1, indexOfFirstRightBracket - indexOfFirstLeftBRacket - 1);
                Console.Write(printText);
            }
            else
            {
                commandLine = commandLine.Remove(0, 1);
            }
        }
    }
}
