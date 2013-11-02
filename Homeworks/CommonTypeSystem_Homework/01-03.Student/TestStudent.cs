/* 1.Define a class Student, which contains data about a student – first, middle and last name, 
 * SSN, permanent address, mobile phone e-mail, course, specialty, university, faculty.
 * Use an enumeration for the specialties, universities and faculties. 
 * Override the standard methods, inherited by  System.Object: Equals(), ToString(), GetHashCode() and operators == and !=.
 * 2.Add implementations of the ICloneable interface. The Clone() method should deeply copy 
 * all object's fields into a new object of type Student.
 * 3.Implement the  IComparable<Student> interface to compare students by names 
 * (as first criteria, in lexicographic order) and by social security number 
 * (as second criteria, in increasing order).
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_03.Student
{
    class TestStudent
    {
        static void Main()
        {
            Student student1 = new Student("Misho", "Ivanov", "Mishev", 785, "Sofia", 0889784521, "misho@abv.bg", 4, Specialty.Accounting, University.IU_Varna, Faculty.Business);
            Student student2 = new Student("Misho", "Ivanov", "Mishev", 567, "Sofia", 0899521123, "misho_ivanov@gmail.com", 4, Specialty.Accounting, University.IU_Varna, Faculty.Business);
            Student copyStudent = student1.Clone();
            copyStudent.FirstName = "Ivan";
            Console.WriteLine("The first name of student1 is {0}",student1.FirstName);
            Console.WriteLine("The first name of cloned student is {0}",copyStudent.FirstName);
            Console.WriteLine("The result of CompareTo method is {0}",student1.CompareTo(student2));
        }
    }
}
