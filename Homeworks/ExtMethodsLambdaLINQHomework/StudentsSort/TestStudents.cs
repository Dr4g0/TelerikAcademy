using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsSort
{
    class TestStudents
    {
        static void Main()
        {
            Students[] students = new Students[]
            { 
                new Students("Mimi","Pesheva",18),
                new Students("Pesho","Mimev",22),
                new Students("Karamfil","Grozdev",26),
                new Students("Minzuhar","Vinev",24),
                new Students("Pepo","Lamev",25),
                new Students("Evlogi","Statev",29),
                new Students("Parvanka","Golemova",17),
                new Students("Parvanka","Maleva",22)
            };
            var firstList = Students.ExtractNames(students);
            Console.WriteLine("Students whose first name is before its last name:");
            foreach (var student in firstList)
            {
                Console.WriteLine("{0} {1}",student.FirstName,student.LastName);
            }
            Console.WriteLine();
            var secondList = Students.ExtractStudentsByAge(students);
            Console.WriteLine("Students with age between 18 and 24:");
            foreach (var student in secondList)
            {
                Console.WriteLine("{0} {1}",student.FirstName,student.LastName);
            }
            Console.WriteLine();
            var sortWithLambda=Students.SortWithLambda(students);
            Console.WriteLine("Sorting the students by first name and last name in descending order (with lambda expr.):");
            foreach (var student in sortWithLambda)
            {
                Console.WriteLine("{0} {1}", student.FirstName, student.LastName);
            }
            Console.WriteLine();
            var sortWithLINQ = Students.SortWithLINQ(students);
            Console.WriteLine("Sort againt with LINQ:");
            foreach (var student in sortWithLINQ)
            {
                Console.WriteLine("{0} {1}", student.FirstName, student.LastName);
            }
        }
    }
}
