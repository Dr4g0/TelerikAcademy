//Implement a set of extension methods for IEnumerable<T> that implement the 
//following group functions: sum, product, min, max, average.

/*
 * Implement a set of extension methods for IEnumerable<T> that implement the following 
 * group functions: sum, product, min, max, average.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.ImplementExtMethods
{
    public static class ImplementExtMethods
        
    {

        public static T Sum<T>(this IEnumerable<T> list)
        {
            dynamic sum = default(T);
            foreach (var item in list)
            {
                sum += item;
            }
            return sum;
        }

        public static decimal Product<T>(this IEnumerable<T> list)
        {
            dynamic product = 1;
            foreach (var item in list)
            {
                product *=item;
            }
            return product;
        }

        public static decimal Min<T>(this IEnumerable<T> list)
            where T: IComparable
        {
            dynamic minValue = decimal.MaxValue;
            foreach (var item in list)
            {
                if ((dynamic)item<minValue)
                {
                    minValue = item;
                }
            }
            return minValue;
        }

        public static decimal Max<T>(this IEnumerable<T> list)
            where T : IComparable
        {
            dynamic maxValue = decimal.MinValue;
            foreach (var item in list)
            {
                if ((dynamic)item > maxValue)
                {
                    maxValue = item;
                }
            }
            return maxValue;
        }

        public static decimal Average<T>(this IEnumerable<T> list)
        {
            dynamic sum = 0;
            decimal counter = 0;
            foreach (var item in list)
            {
                sum += item;
                counter++;
            }
            return Math.Round(sum / counter,2);
        }
    }
}
