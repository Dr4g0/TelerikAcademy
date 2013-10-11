using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPrjoect
{
    class Student : Person,ICommentable
    {
        private List<string> allComments=new List<string>();
        public Class InClass { get; set; }
        public int IDNumber { get; set; }
        
        public List<string> AllComments
        {
            get { return this.allComments; }
            set { this.allComments=value; }
        }

        public Student(string firstName, string lastName, Class inClass, int idNumber)
            : base(firstName, lastName)
        {
            this.InClass = inClass;
            this.IDNumber = idNumber;
        }

        public void AddComment(string comment)
        {
            AllComments.Add(comment);
        }

        public override string ToString()
        {
            StringBuilder studentInfo = new StringBuilder();
            studentInfo.AppendFormat("Information about student {0} {1}",this.FirstName,this.LastName);
            studentInfo.AppendFormat("\r\nClass:{0}",this.InClass.ClassName);
            studentInfo.AppendFormat("\r\nIDNumber:{0}",this.IDNumber);
            studentInfo.AppendFormat("\r\n\r\nComments about student {0} {1}:", this.FirstName, this.LastName);
            if (AllComments.Count == 0)
            {
                studentInfo.Append("None");
            }
            else
            {
                for (int i = 1; i <= AllComments.Count; i++)
                {
                    studentInfo.AppendFormat("\r\n{0}.{1}", i, AllComments[i - 1]);
                }
            }
            studentInfo.AppendLine();
            return studentInfo.ToString();
        }

    }
}
