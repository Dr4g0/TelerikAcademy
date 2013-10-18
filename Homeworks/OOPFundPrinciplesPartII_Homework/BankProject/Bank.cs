using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject
{
    class Bank
    {
        public string Name { get; set; }
        public string Branch { get; set; }

        private List<Customer> allCustomers=new List<Customer>();
        private List<Account> allAccounts=new List<Account>();

        public List<Account> AllAccounts
        {
            get { return allAccounts; }
            set { allAccounts = value; }
        }
        
        public List<Customer> AllCustomers
        {
            get { return allCustomers; }
            set { allCustomers = value; }
        }
        
        public Bank(string name,string branch)
        {
            this.Name = name;
            this.Branch = branch;
        }
    }
}
