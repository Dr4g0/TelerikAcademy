using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject
{
    class IndividualCustomer : Customer
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public ulong IDNumber { get; set; }
        public Gender Gender { get; set; }

        public IndividualCustomer(int clientNumber, string firstName, string middleName, string lastName, ulong idNumber,string address, Gender gender)
            : base(clientNumber,address)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.IDNumber = idNumber;
            this.Gender = gender;
        }
    }
}
