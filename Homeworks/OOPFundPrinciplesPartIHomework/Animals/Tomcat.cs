using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    class Tomcat:Cat,ISound
    {
        public Tomcat(CatsClassification subfamily, string name, uint age, SexVarieties sex)
            : base(subfamily, name, age, sex)
        {
            if (this.Sex==SexVarieties.female)
            {
                throw new ArgumentException("The tomcats are allways male");
            }
        }

        public string ProduceSound()
        {
            return "Grrrr, Myauuu";
        }
    }
}
