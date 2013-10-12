using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.ImplementExtMethods
{
    class TestExtMethods
    {
        static void Main()
        {
            int[] list=new int[]{1,100,10,1000,-10,-1000,51};
            Console.WriteLine("The sum of the items is: {0}",list.Sum());
            Console.WriteLine("The product of the items is: {0}",list.Product());
            Console.WriteLine("The minimum item is: {0}",list.Min());
            Console.WriteLine("The maximal item is: {0}",list.Max());
            Console.WriteLine("The average of the items is: {0}", list.Average());

            string[] testArray = new string[] {"Pesho","Gosho","Mimi" };
            Console.WriteLine(testArray.Sum());

            object[] testArr = new object[] { "Pesho",23,"Mimi"};
            Console.WriteLine(testArr.Sum());
        }
    }
}
