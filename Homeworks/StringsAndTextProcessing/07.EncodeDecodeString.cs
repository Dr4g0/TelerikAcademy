/*Write a program that encodes and decodes a string using given encryption key (cipher). 
The key consists of a sequence of characters. 
The encoding/decoding is done by performing XOR (exclusive or) operation over the first letter 
of the string with the first of the key, the second – with the second, etc. 
When the last key character is reached, the next is the first.
*/

using System;
using System.Text;

class EncodeDecodeString
{
    static void Main()
    {
        const string Text = "Happy new year,Happy new year";
        const string Key = "abc";
        Console.WriteLine("Encrypted text is: {0}",EncryptOrDecrypt(Text,Key));
        Console.WriteLine("Decryption of the encrypted text: {0}", EncryptOrDecrypt(EncryptOrDecrypt(Text, Key), Key));
    }

    static string EncryptOrDecrypt(string text, string key)
    {
        int countLengthOfText = 0;
        StringBuilder processedText = new StringBuilder();
        while (countLengthOfText<text.Length)
        {
            for (int i = 0; i < key.Length; i++)
            {
                if (countLengthOfText==text.Length)
                {
                    break;
                }
                else
                {
                    processedText.Append((char)(text[countLengthOfText] ^ key[i]));
                }
                countLengthOfText++;
            }
        }
        return processedText.ToString();
    }
}