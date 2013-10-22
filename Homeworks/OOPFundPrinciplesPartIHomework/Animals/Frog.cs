using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    class Frog : Animal,ISound
    {
        public Frog(string name,uint age, SexVarieties sex):base(name,age,sex)
        { 
        }

        public string ProduceSound()
        {
            return "Quaak, quaak";
        }
    }
}
