/*Implement an extension method Substring(int index, int length) for the class StringBuilder 
 * that returns new StringBuilder and has the same functionality as Substring in the class 
 * String.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.ImplementSubstring
{
    public static class ImplementSubstring
    {
        public static StringBuilder Substring(this StringBuilder sb, int index, int length)
        {
            if (index<0||index>=sb.Length||(index+length)>sb.Length)
            {
                throw new ArgumentOutOfRangeException("Index or length are invalid");
            }
            StringBuilder result = new StringBuilder();
            int endIndex = index + length;
            for (int i = index; i < endIndex; i++)
            {
                result.Append(sb[i]);
            }
            return result;
        }

        public static StringBuilder Substring(this StringBuilder sb, int startIndex)
        {
            if (startIndex < 0 || startIndex >= sb.Length)
            {
                throw new ArgumentOutOfRangeException("Index is invalid");
            }
            StringBuilder result = new StringBuilder();
            for (int i = startIndex; i < sb.Length; i++)
            {
                result.Append(sb[i]);
            }
            return result;
        }
    }
}
