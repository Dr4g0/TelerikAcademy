using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    abstract class Cat : Animal
    {
        public CatsClassification Subfamily { get; set; }

        public Cat(CatsClassification subfamily, string name, uint age, SexVarieties sex)
            : base(name, age, sex)
        {
            this.Subfamily = subfamily;
        }
    }
}
