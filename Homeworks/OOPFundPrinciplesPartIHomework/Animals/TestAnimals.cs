/*Create a hierarchy Dog, Frog, Cat, Kitten, Tomcat and define useful constructors and methods.
 * Dogs, frogs and cats are Animals. All animals can produce sound (specified by the ISound interface). 
 * Kittens and tomcats are cats. All animals are described by age, name and sex. 
 * Kittens can be only female and tomcats can be only male. Each animal produces a specific sound. 
 * Create arrays of different kinds of animals and calculate the average age of each kind of animal 
 * using a static method (you may use LINQ).
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    class TestAnimals
    {
        static void Main()
        {
            Kitten[] kittens = new Kitten[]
            {
                new Kitten(CatsClassification.SmallCats, "Kiti", 2, SexVarieties.female),
                new Kitten(CatsClassification.SmallCats, "Pipi", 1, SexVarieties.female)
            };
            Console.WriteLine("The average age of kittens is {0}",Animal.AverageAge(kittens));
            Console.WriteLine("Kittens says \"{0}\"",kittens[0].ProduceSound());
            Tomcat[] tomcats = new Tomcat[]
            {
                new Tomcat(CatsClassification.SmallCats, "Pepo", 5, SexVarieties.male),
                new Tomcat(CatsClassification.SmallCats, "Zhuzho", 6, SexVarieties.male)
            };
            Console.WriteLine("\r\nThe average age of tomcats is {0}", Animal.AverageAge(tomcats));
            Console.WriteLine("Tomcats says \"{0}\"", tomcats[0].ProduceSound());
            Dog[] dogs = new Dog[]
            {
                new Dog("Sharo", 4, SexVarieties.male),
                new Dog("Liza", 5, SexVarieties.female)
            };
            Console.WriteLine("\r\nThe average age of dogs is {0}", Animal.AverageAge(dogs));
            Console.WriteLine("Dogs says \"{0}\"", dogs[0].ProduceSound());
            Frog[] frogs=new Frog[]
            {
                new Frog("Shrek",3,SexVarieties.male),
                new Frog("Fiona",2,SexVarieties.female)
            };
            Console.WriteLine("\r\nThe average age of frogs is {0}", Animal.AverageAge(frogs));
            Console.WriteLine("Frogs says \"{0}\"", frogs[0].ProduceSound());
            Console.WriteLine();
        }
    }
}
