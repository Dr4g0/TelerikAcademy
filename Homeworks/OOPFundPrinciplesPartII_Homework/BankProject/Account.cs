using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankProject
{
    public abstract class Account
    {
        public string IBAN { get; set; }
        public Customer AccountOwner { get; set; }
        public decimal Balance { get; set; }
        public decimal InterestRate { get; set; }

        public Account(string iban, Customer owner, decimal interestRate) //every initial account balance is 0
        {
            this.IBAN = iban;
            this.AccountOwner = owner;
            this.InterestRate = interestRate;
        }

        public virtual decimal CalculateInterest(int months)
        {
            return this.Balance * this.InterestRate * months / 100 ;
        }
    }
}
