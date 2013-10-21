using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject
{
    public class LoanAccount : Account,IDeposit
    {
        public LoanMortageTerm Term { get; set; }

        public LoanAccount(string iban, Customer owner, decimal interestRate, LoanMortageTerm term, decimal initialLoanAmount)
            :base(iban,owner,interestRate)
        {
            this.Term = term;
            this.Balance = -initialLoanAmount;
        }

        public void DepositFunds(decimal amount)
        {
            this.Balance += amount;
            if (this.Balance>=0)
            {
                PrintMessage();
            }
        }

        public override decimal CalculateInterest(int months)
        {
            this.InterestMonths = months;
            if (this.AccountOwner.GetType().Name=="IndividualClient")
            {
                months -= 3;
            }
            else if (this.AccountOwner.GetType().Name == "CorporateClient")
            {
                months -= 2;
            }
            if (months>0)
            {
                return base.CalculateInterest(months);
            }
            else
            {
                return 0;
            }
        }
    }
}
