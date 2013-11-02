/*Create a class Person with two fields – name and age. Age can be left unspecified 
 * (may contain null value. Override ToString() to display the information of a person 
 * and if age is not specified – to say so. Write a program to test this functionality.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonClass
{
    class TestPerson
    {
        static void Main()
        {
            Person student1 = new Person("Pesho");
            Console.WriteLine("Student 1\r\n{0}",student1);
            Console.WriteLine();
            Person student2 = new Person("Gosho", 19);
            Console.WriteLine("Student 2\r\n{0}",student2);
        }
    }
}
