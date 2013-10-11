using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPrjoect
{
    class Teacher : Person,ICommentable
    {
        private List<Tuple<Class, Course>> teacherProgram=new List<Tuple<Class,Course>>();
        private List<string> allComments = new List<string>();

        public List<Tuple<Class, Course>> TeacherProgram
        {
            get { return this.teacherProgram; }
            set { this.teacherProgram = value; }
        }

        public List<string> AllComments
        {
            get { return this.allComments; }
            set { this.allComments = value; }
        }

        public Teacher(string firstName, string lastName, List<Tuple<Class, Course>> teacherProgram)
            : base(firstName, lastName)
        {
            this.TeacherProgram = teacherProgram;   
        }

        public void AddComment(string comment)
        {
            AllComments.Add(comment);
            
        }

        public override string ToString()
        {
            StringBuilder teacherInfo = new StringBuilder();
            teacherInfo.AppendFormat("Information about teacher's {0} {1} courses", this.FirstName, this.LastName);
            teacherInfo.AppendFormat("\r\n{0,-10}{1}","Class","Course");
            foreach (Tuple<Class, Course> course in this.TeacherProgram)
            {
                teacherInfo.AppendFormat("\r\n'{0}{1,-8}{2}",course.Item1.ClassName,"'",course.Item2.CourseName);
            }
            teacherInfo.AppendFormat("\r\n\r\nComments about teacher {0} {1}:", this.FirstName, this.LastName);
            if (AllComments.Count == 0)
            {
                teacherInfo.Append("None");
            }
            else
            {
                for (int i = 1; i <= AllComments.Count; i++)
                {
                    teacherInfo.AppendFormat("\r\n{0}.{1}", i, AllComments[i - 1]);
                }
            }
            teacherInfo.AppendLine();
            return teacherInfo.ToString();
        }
    }
}
