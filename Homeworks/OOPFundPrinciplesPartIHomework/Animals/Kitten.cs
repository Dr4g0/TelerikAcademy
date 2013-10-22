using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    class Kitten : Cat, ISound
    {
        public Kitten(CatsClassification subfamily, string name, uint age, SexVarieties sex)
            : base(subfamily, name, age, sex)
        {
            if (this.Sex==SexVarieties.male)
            {
                throw new ArgumentException("Kittens are allways female");
            }
        
        }

        public string ProduceSound()
        {
            return "Mrrrr, mrrrr";
        }

    }
}
