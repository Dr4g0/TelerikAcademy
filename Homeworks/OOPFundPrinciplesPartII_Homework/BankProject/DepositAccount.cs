using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject
{
    public class DepositAccount : Account, IDeposit, IDraw
    {
        public DepositMaturity DepositType { get; set; }

        public DepositAccount(string iban, Customer owner, decimal interestRate, DepositMaturity depositType)
            :base(iban,owner,interestRate)
        {
            this.DepositType = depositType;
        }

        public void DepositFunds(decimal amount)
        {
            this.Balance += amount;
        }

        public void DrawFunds(decimal amount)
        {
            if (this.Balance-amount<0)
            {
                throw new ArgumentException("The balance of the account is less then amount");
            }
            this.Balance -= amount;
        }

        public override decimal CalculateInterest(int months)
        {
            this.InterestMonths = months;
            if (this.Balance>=1000)
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
