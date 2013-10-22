using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Humans
{
    public abstract class Human
    {
        private string firstName;

        public string FirstName
        {
            get { return firstName; }
        }

        private string lastName;

        public string LastName
        {
            get { return lastName; }
        }

        public Human(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public override string ToString()
        {
            StringBuilder human = new StringBuilder();
            human.AppendFormat("{0} {1}",this.FirstName,this.LastName);
            return human.ToString();
        }
    }
}
