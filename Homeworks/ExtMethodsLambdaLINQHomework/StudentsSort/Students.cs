/*
3.Write a method that from a given array of students finds all students whose first name is 
 * before its last name alphabetically. Use LINQ query operators.
4.Write a LINQ query that finds the first name and last name of all students 
 * with age between 18 and 24.
5.Using the extension methods OrderBy() and ThenBy() with lambda expressions sort 
 * the students by first name and last name in descending order. Rewrite the same with LINQ.
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsSort
{
    class Students
    {
        private string firstName;
        private string lastName;
        private int age;

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string  LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public Students(string first, string last, int years)
        {
            this.firstName = first;
            this.lastName = last;
            this.age = years;
        }

        public static dynamic ExtractNames(Students[] list)
        {
            var finalList =
                from student in list
                where student.FirstName.CompareTo(student.LastName) < 0
                select student;
            return finalList;
        }

        public static dynamic ExtractStudentsByAge(Students[] list)
        {
            var finalList =
                from student in list
                where student.Age >= 18 && student.Age <= 24
                select student;
            return finalList;
        }

        public static dynamic SortWithLambda(Students[] list)
        {
            var sortedArray = list.OrderByDescending(student => student.FirstName).ThenByDescending(student => student.LastName);
            return sortedArray;
        }

        public static dynamic SortWithLINQ(Students[] list)
        {
            var secondSortedArray =
                from student in list
                orderby student.LastName descending
                orderby student.FirstName descending
                select student;
            return secondSortedArray;
        }
    }
}
