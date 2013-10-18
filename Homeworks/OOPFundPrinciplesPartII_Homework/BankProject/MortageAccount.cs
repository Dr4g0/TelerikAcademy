using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject
{
    class MortageAccount : Account, IDeposit
    {
        public LoanMortageTerm Term { get; set; }

        public MortageAccount(string iban, Customer owner, decimal interestRate, LoanMortageTerm term, decimal initialMortageAmount)
            :base(iban,owner,interestRate)
        {
            this.Term = term;
            this.Balance = initialMortageAmount;
        }

        public void DepositFunds(decimal amount)
        {
            this.Balance -= amount;
            if (this.Balance<=0)
            {
                Console.WriteLine("Congratulations! Your mortage is paid.");
                Console.WriteLine("We can release collateral.");
            }
        }

        public override decimal CalculateInterest(int months)
        {
            if (this.AccountOwner.GetType().Name == "IndividualClient")
            {
                months -= 6;
                if (months > 0)
                {
                    return base.CalculateInterest(months);
                }
                else
                {
                    return 0;
                }
            }
                // to be code more readable using else if
            else if (this.AccountOwner.GetType().Name == "CorporateClient")
            {
                if (months > 12)
                {
                    return this.Balance * this.InterestRate / 2 * 12 + this.Balance * this.InterestRate * (months - 12);
                }
                else if (months>0)
                {
                    return this.Balance * this.InterestRate / 2 * months;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }
    }
}
