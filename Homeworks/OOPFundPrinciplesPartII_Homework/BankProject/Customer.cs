using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankProject
{
    public abstract class Customer
    {
        private int clientNumber;

        public string Address { get; set; }
        private List<Account> clientAccounts = new List<Account>();

        public List<Account> ClientAccounts
        {
            get { return this.clientAccounts; }
            set { this.clientAccounts = value; }
        }

        public int ClientNumber
        {
            get
            {
                return this.clientNumber;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Client number must be a positive integer");
                }
                this.clientNumber = value;
            }
        }

        public Customer(int clientNumber, string address)
        {
            this.ClientNumber = clientNumber;
            this.Address = address;
        }

        public string AddAcountInfo(Account[] acc)
        {
            StringBuilder result = new StringBuilder();
            result.AppendFormat("\r\n{0,12} {1,28} ", "IBAN", "Current balance");
            foreach (Account account in acc)
            {
                result.AppendFormat("\r\n{0}{1,14:F2}", account.IBAN, account.Balance);
                if (account.InterestMonths>0)
                {
                    result.AppendFormat("\r\nInterest for {0} months: {1:F2}", account.InterestMonths, account.CalculateInterest(account.InterestMonths));
                }
            }
            return result.ToString();
        }

        protected string AddAcounts(Account[] acc)
        {
            StringBuilder final = new StringBuilder();
            final.AppendFormat("\r\n\r\nDeposit accounts:");
            DepositAccount[] depAcc = this.ClientAccounts.OfType<DepositAccount>().ToArray();
            if (depAcc.Count() > 0)
            {
                final.Append(AddAcountInfo(depAcc));
            }
            else
            {
                final.Append("None");
            }
            final.AppendFormat("\r\n\r\nLoan accounts:");
            LoanAccount[] loanAcc = this.ClientAccounts.OfType<LoanAccount>().ToArray();
            if (loanAcc.Count() > 0)
            {
                final.Append(AddAcountInfo(loanAcc));
            }
            else
            {
                final.Append("None");
            }
            final.AppendFormat("\r\n\r\nMortage accounts:");
            MortageAccount[] mortAcc = this.ClientAccounts.OfType<MortageAccount>().ToArray();
            if (mortAcc.Count() > 0)
            {
                final.Append(AddAcountInfo(mortAcc));
            }
            else
            {
                final.Append("None");
            }
            return final.ToString();
        }
    }
}
