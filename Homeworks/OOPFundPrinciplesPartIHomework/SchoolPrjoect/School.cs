using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPrjoect
{
    class School
    {
        public string SchoolName { get; set; }
        public SchoolType Type { get; set; }
        public List<Class> AllClasses { get; set; }
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
