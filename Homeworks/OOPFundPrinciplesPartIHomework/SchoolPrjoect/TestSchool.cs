using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPrjoect
{
    class TestSchool
    {
        static void Main()
        {
            List<Class> myClasses = new List<Class>()
            {
                new Class("Ia"),
                new Class("Ib"),
                new Class("Ic"),
            };

            List<Course> myCourses = new List<Course>()
            {
                new Course("Math",10,15),
                new Course("Physics",5,5),
                new Course("Chemistry",4,5),
                new Course("Geography",6,3),
                new Course("Sport",1,10),
                new Course("History",5,1)
            };

            School mySchool = new School("SOU \"Ivan Vazov\"", SchoolType.GrammarSchool, myClasses, myCourses);

            Student[] allStudents = new Student[]
            {
            new Student("Ivan", "Laskin", myClasses[0], 3),
            new Student("Petar","Petrov",myClasses[1],3),
            new Student("Gosho","Petev",myClasses[2],2),
            new Student("Dimitar","Enchev",myClasses[0],2),
            new Student("Evlogi","Dimitrov",myClasses[1],1),
            new Student("Diana","Gerogieva",myClasses[2],3),
            new Student("Mimi","Taneva",myClasses[0],4),
            new Student("Cecka","Petrova",myClasses[1],4),
            new Student("Miro","Strashimirov",myClasses[2],5),
            new Student("Gosho","Kolev",myClasses[0],1),
            new Student("Kiko","Penev",myClasses[1],2),
            new Student("Ivan","Asparuhov",myClasses[2],4),
            new Student("Samuil","Dochev",myClasses[0],5),
            new Student("Albert","Einstein",myClasses[2],1)
            };

            foreach (Student student in allStudents)
            {
                student.InClass.AddStudent(student);
            }

            List<Tuple<Class,Course>> ivanPetrovProgram = new List<Tuple<Class,Course>>()
            {
                new Tuple<Class, Course>(myClasses[0], myCourses[0]),
                new Tuple<Class,Course>(myClasses[1],myCourses[0]),
                new Tuple<Class,Course>(myClasses[2],myCourses[0]),
                new Tuple<Class,Course>(myClasses[2],myCourses[1])
            };

            List<Tuple<Class, Course>> vladoYovchevProgram = new List<Tuple<Class, Course>>()
            {
                new Tuple<Class, Course>(myClasses[0], myCourses[1]),
                new Tuple<Class,Course>(myClasses[1],myCourses[1]),
                
            };

            Teacher[] allTeachers = new Teacher[]
            {
                new Teacher("Ivan","Petrov",ivanPetrovProgram),
                new Teacher("Vlado","Yovchev",vladoYovchevProgram)
            };

            foreach (Teacher teacher in allTeachers)
            {
                foreach (Tuple<Class,Course> item in teacher.TeacherProgram)
                {
                    foreach (Class _class in myClasses)
                    {
                        if (_class==item.Item1)
                        {
                            _class.AddCourse(new Tuple<Course, Teacher>(item.Item2, teacher));
                        }
                    }
                }
            }

            myClasses[0].AddComment("Low results.Check the reason.");
            allStudents[allStudents.Length - 1].AddComment("Genius!");
            allTeachers[0].AddComment("May be he is a drunkard, spy him.");
            Console.WriteLine(mySchool);
            Console.WriteLine();
            Console.WriteLine(myClasses[0]);
            Console.WriteLine();
            Console.WriteLine(allStudents[allStudents.Length - 1]);
            Console.WriteLine(allTeachers[0]);
        }
    }
}
