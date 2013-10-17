using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPrjoect
{
    class School
    {
        private List<Class> allClasses = new List<Class>();
        public string SchoolName { get; set; }
        public SchoolType Type { get; set; }
        public List<Class> AllClasses {
            get
            {
                return this.allClasses;
            }

            set
            {
                this.allClasses = value;
                //validate unique class
                if (this.AllClasses.GroupBy(i=>i.ClassName).Where(g=>g.Skip(1).Any()).SelectMany(i=>i).ToList().Count>0)
                {
                    throw new ArgumentException("There are two classes with same names");
                }
            }
        }
        public List<Course> AllCourses { get; set; }

        public School(string name, SchoolType type, List<Class> allClasses, List<Course> allCourses)
        {
            this.SchoolName = name;
            this.Type = type;
            this.AllClasses = allClasses;
            this.AllCourses = allCourses;
        }

        public override string ToString()
        {
            StringBuilder schoolInfo = new StringBuilder();
            schoolInfo.AppendFormat("Info about school {0}",this.SchoolName);
            schoolInfo.AppendFormat("\r\nType of the school: {0}",this.Type);
            schoolInfo.AppendFormat("\r\nNumber of classes in the school: {0}",this.AllClasses.Count());
            schoolInfo.AppendFormat("\r\nNumber of studied courses: {0}",this.AllCourses.Count());
            return schoolInfo.ToString();
        }
    }
}
