using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Humans
{
    class Student : Human
    {
        private int grade;

        public int Grade
        {
            get { return grade; }
            set { grade = value; }
        }

        public Student(string firstName, string lastName, int grade)
            : base(firstName, lastName)
        {
            this.grade = grade;
        }

        public override string ToString()
        {
            StringBuilder student = new StringBuilder();
            student.AppendFormat("{0,-15} - grade {1}",this.FirstName+" "+this.LastName,this.grade);
            return student.ToString();
        }
    }
}
