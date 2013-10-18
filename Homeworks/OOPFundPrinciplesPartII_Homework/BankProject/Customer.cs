using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankProject
{
    public abstract class Customer
    {
        public int ClientNumber { get; set; }
        public string Address { get; set; }

        private List<Account> clientAccounts=new List<Account>();

        public List<Account> ClientAccounts
        {
            get { return clientAccounts; }
            set { clientAccounts= value; }
        }

        public Customer(int clientNumber, string address)
        {
            this.ClientNumber = clientNumber;
            this.Address = address;
        }
    }
}
