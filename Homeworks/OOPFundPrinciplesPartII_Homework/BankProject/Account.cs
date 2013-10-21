using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankProject
{
    public abstract class Account
    {
        private decimal interestRate;

        public string IBAN { get; set; }
        public Customer AccountOwner { get; set; }
        public decimal Balance { get; set; }
        public int InterestMonths { get; set; }

        public decimal InterestRate {
            get
            { return this.interestRate; }
            set
            {
                if (value<=0)
                {
                    throw new ArgumentException("Interest rate must be postivie.");
                }
                this.interestRate = value;
            }
        }

        public Account(string iban, Customer owner, decimal interestRate)
        {
            this.IBAN = iban;
            this.AccountOwner = owner;
            this.InterestRate = interestRate;
        }

        public virtual decimal CalculateInterest(int months)
        {
            if (months<=0)
            {
                throw new ArgumentException("The period must be a positive number.");
            }
            return Math.Abs(this.Balance * this.InterestRate * months / 100 );
        }

        public void PrintMessage() // print the message if all loan/mortage is paid
        {
            if (this.AccountOwner as IndividualClient != null)
            {
                IndividualClient ic = this.AccountOwner as IndividualClient;
                Console.WriteLine("Dear Mrs./Mr. {0}, your loan was paid.", ic.LastName);
            }
            else if (this.AccountOwner as CorporateClient != null)
            {
                CorporateClient cc = this.AccountOwner as CorporateClient;
                Console.WriteLine("Dear \"{0}\" {1}, your loan was paid.", cc.CompanyName, cc.Type);
            }
        }
    }
}
