using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPrjoect
{
    class Class : ICommentable
    {
        private List<Student> classStudents = new List<Student>();
        private List<Tuple<Course, Teacher>> classProgram = new List<Tuple<Course, Teacher>>();
        private List<string> allComments = new List<string>();
        
        public string ClassName { get; set; }
        
        public List<string> AllComments 
        { 
            get
            {
                return this.allComments;
            }
            set
            {
                this.allComments = value;
            }
        }

        public List<Student> ClassStudents 
        { 
            get 
            { 
                return this.classStudents; 
            } 
        }

        public List<Tuple<Course, Teacher>> ClassProgram
        {
            get
            {
                return this.classProgram;
            }
        }

        public Class(string className)
        {
            this.ClassName = className;
        }

        public void AddStudent(Student student)
        {
            List<int> numbers = this.ClassStudents.Select(x => x.IDNumber).ToList();
            //validate unique IDNumber in same school class
            if (!numbers.Contains(student.IDNumber))
            {
                ClassStudents.Add(student);
            }
            else
            {
                throw new ArgumentException("There are students in one and the same class with equal IDNmubers");
            }
        }

        public void AddCourse(Tuple<Course,Teacher> course)
        {
            if (!this.ClassProgram.Contains(course))
            {
                ClassProgram.Add(course);
            }
        }

        public void AddComment(string comment)
        {
            AllComments.Add(comment);
        }

        public override string ToString()
        {
            StringBuilder courseInfo = new StringBuilder();
            courseInfo.AppendFormat("Information about '{0}' class:", this.ClassName);
            courseInfo.AppendFormat("\r\nStudents:");
            courseInfo.AppendFormat("\r\n{0,-15}{1,8}","IDNumber","Name");
            courseInfo.AppendFormat("\r\n{0}",new string('=', 30));
            var orderedStudents =
                from student in ClassStudents
                orderby student.IDNumber
                select student;
            foreach (var student in orderedStudents)
            {
                courseInfo.AppendFormat("\r\n{0,-15}{1} {2}",student.IDNumber,student.FirstName,student.LastName);
            }
            courseInfo.AppendFormat("\r\n\r\n{0,-15}{1,10}\r\n","Course","Teacher");
            courseInfo.AppendFormat(new string('=',30));
            foreach (Tuple<Course,Teacher> course in ClassProgram)
            {
                courseInfo.AppendFormat("\r\n{0,-15}{1} {2}",course.Item1.CourseName,course.Item2.FirstName,course.Item2.LastName);
            }

            courseInfo.AppendFormat("\r\n\r\nComments about '{0}' class:", this.ClassName);
            if (AllComments.Count==0)
            {
                courseInfo.Append("None");
            }
            else
            {
                for (int i = 1; i <= AllComments.Count; i++)
                {
                    courseInfo.AppendFormat("\r\n{0}.{1}",i,AllComments[i-1]);
                }
            }
            courseInfo.AppendLine();
            return courseInfo.ToString();
        }

    }
}