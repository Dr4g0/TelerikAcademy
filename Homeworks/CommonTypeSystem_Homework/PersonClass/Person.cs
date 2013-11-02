using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonClass
{
    class Person
    {
        private string name;
        private int? age;

        public int? Age
        {
            get { return age; }
            set { age = value; }
        }
        

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The name is empty.");
                }
                name = value;
            }
        }

        public Person(string name, int? age = null)
        {
            this.Name = name;
            this.Age = age;
        }

        public override string ToString()
        {
            return String.Format("Name:{0}\r\nAge:{1}",this.Name,this.Age!=null?this.Age.ToString():"Unspecified");
        }
    }
}
