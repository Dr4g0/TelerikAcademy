using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject
{
    public class MortageAccount : Account, IDeposit
    {
        public LoanMortageTerm Term { get; set; }

        public MortageAccount(string iban, Customer owner, decimal interestRate, LoanMortageTerm term, decimal initialMortageAmount)
            :base(iban,owner,interestRate)
        {
            this.Term = term;
            this.Balance = -initialMortageAmount;
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
            if ((this.AccountOwner as IndividualClient)!=null)
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
            else if (this.AccountOwner as CorporateClient!=null)
            {
                if (months > 12)
                {
                    return Math.Abs(this.Balance * this.InterestRate / 100 / 2 * 12 + this.Balance * this.InterestRate/100 * (months - 12));
                }
                else if (months>0)
                {
                    return Math.Abs(this.Balance * this.InterestRate / 2 * months);
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
