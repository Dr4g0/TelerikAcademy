using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    abstract class Animal
    {
        private string name;
        private uint age;
        private SexVarieties sex;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public uint Age
        {
            get { return age; }
            set { age = value; }
        }

        public SexVarieties Sex
        {
            get { return sex; }
            set { sex = value; }
        }
        

        public Animal(string name,uint age, SexVarieties sex)
        {
            this.Name = name;
            this.Age = age;
            this.Sex = sex;
        }

        public static double AverageAge(Animal[] animals)
        {
            double average = animals.Average(x => x.Age);
            return average;    
        }

        public override string ToString()
        {
            return String.Format("{0} is {1} year old. Its sex is {2}",this.Name,this.Age,this.Sex);
        }
    }
}
