using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Humans
{
    class TestHumans
    {
        static void Main()
        {
            Student[] students = new Student[]
            {
                new Student("Lili","Ivanova",4),
                new Student("Mihaela","Fileva",2),
                new Student("Mimi","Ivanova",3),
                new Student("Maria","Ilieva",4),
                new Student("Mariana","Popova",7),
                new Student("Rut","Koleva",8),
                new Student("Orlin","Goranov",1),
                new Student("Orlin","Pavlov",3),
                new Student("Dicho","Hristov",5),
                new Student("Vasil","Naidenov",6)
            };
            var orderedStudents = students.OrderBy(x=>x.Grade);
            Console.WriteLine("Students by grade in ascending order:");
            foreach (var student in orderedStudents)
            {
                Console.WriteLine(student);
            }
            Console.WriteLine();
            Worker[] workers = new Worker[]
            {
                new Worker("Sergei","Stanishev",120,4),
                new Worker("Boiko","Borisov",100,5),
                new Worker("Volen","Siderov",110,1),
                new Worker("Cvetan","Cvetanov",250,3),
                new Worker("Plamen","Oresharski",180,5),
                new Worker("Rosen","Plevneliev",250,6),
                new Worker("Rumen","Ovcharov",500,2),
                new Worker("Maya","Manolova",140,8),
                new Worker("Iskra","Fidosova",320,3),
                new Worker("Bat","Sali",1000,8)
            };
            var hardWorkers = workers.OrderByDescending(x => x.MoneyPerHour());
            Console.WriteLine("Workers by money per hour in descending order:");
            foreach (var worker in hardWorkers)
            {
                Console.WriteLine(worker);
            }
            Console.WriteLine();

            var mergedHumans = workers.Concat<Human>(students.ToArray()).OrderBy(x=>x.FirstName).ThenBy(x=>x.LastName);
            Console.WriteLine("Ordered humans by first and last names:");
            foreach (Human human in mergedHumans)
            {
                Console.WriteLine("{0} {1}",human.FirstName,human.LastName);
            }
            
        }
    }
}
