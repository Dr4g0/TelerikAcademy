using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagesInABottle
{
    class MessagesInABottle
    {
        static int counter=0;
        static StringBuilder finishText = new StringBuilder();

        static void Main()
        {
            string secretMessage = Console.ReadLine();
            string cipher = Console.ReadLine();
            string[] letters = new string[26];
            int index = 0;
            for (int i = 0; i < cipher.Length; i++)
            {
                StringBuilder currentLetter = new StringBuilder();
                if (Char.IsLetter(cipher[i]))
                {
                    currentLetter.Append(cipher[i]);
                    i++;
                    while (i<cipher.Length&&Char.IsDigit(cipher[i]))
                    {
                        currentLetter.Append(cipher[i]);
                        i++;
                    }
                    i--;
                }
                letters[index] = currentLetter.ToString();
                index++;
            }
            Array.Sort(letters);
            string currentLine = String.Empty;
            Decoder(secretMessage, letters, currentLine);
            Console.WriteLine(counter);
            Console.WriteLine(finishText);
        }

        private static void Decoder(string secretMessage, string[] letters, string currentLine)
        {
            if (secretMessage.Length == 0)
            {
                counter++;
                SaveCurrentLine(currentLine);
                //currentLine.Clear();
                //return;
            }
            for (int i = 0; i < letters.Length; i++)
            {
                if (letters[i] != null)
                {
                    if (secretMessage.StartsWith(letters[i].Substring(1)))
                    {
                        Decoder(secretMessage.Substring(letters[i].Substring(1).Length), letters, currentLine+letters[i][0]);
                    }
                }
            }
        }

        private static void SaveCurrentLine(string currentLine)
        {
            finishText.AppendLine(currentLine);
        }
    }
}
