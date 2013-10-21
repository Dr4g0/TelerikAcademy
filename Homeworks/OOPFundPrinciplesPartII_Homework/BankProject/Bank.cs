using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject
{
    public class Bank
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

        public override string ToString()
        {
            StringBuilder bankInfo = new StringBuilder();
            bankInfo.AppendFormat("\r\nBasic information about {0}, branch {1}:",this.Name,this.Branch);
            bankInfo.AppendFormat("\r\nTotal number of customers: {0}",this.AllCustomers.Count());
            bankInfo.AppendFormat("\r\nTotal number of bank accounts: {0}",this.AllAccounts.Count());
            return bankInfo.ToString();
        }
    }
}
