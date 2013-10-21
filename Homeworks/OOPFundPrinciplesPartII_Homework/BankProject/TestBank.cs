/*A bank holds different types of accounts for its customers: deposit accounts, loan accounts 
 * and mortgage accounts. Customers could be individuals or companies.
 * All accounts have customer, balance and interest rate (monthly based). 
 * Deposit accounts are allowed to deposit and with draw money. Loan and mortgage accounts can 
 * only deposit money.
 * All accounts can calculate their interest amount for a given period (in months). 
 * In the common case its is calculated as follows: number_of_months * interest_rate.
 * Loan accounts have no interest for the first 3 months if are held by individuals and for 
 * the first 2 months if are held by a company.
 * Deposit accounts have no interest if their balance is positive and less than 1000.
 * Mortgage accounts have ½ interest for the first 12 months for companies and no interest 
 * for the first 6 months for individuals.
 * Your task is to write a program to model the bank system by classes and interfaces. 
 * You should identify the classes, interfaces, base classes and abstract actions and implement 
 * the calculation of the interest functionality through overridden methods.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject
{
    class TestBank
    {
        static void Main()
        {
            Bank myBank = new Bank("SamuraiBank", "Sofia");
            Customer[] firstCustomers = new Customer[] 
            {
                new IndividualClient(1,"Koko","Popov","Milev",9010108887,"1 Parva str.",Gender.Male),
                new IndividualClient(2,"Pepo","Petev","Pipev",7701228688,"2 Vtora str.",Gender.Male),
                new IndividualClient(3,"Pepa","Coneva","Siveva",8912128974,"3 Treta str.",Gender.Female),
                new CorporateClient(4,"Kabeli vsiakakvi rejem",CompanyType.ET,127654258,"1 Industrialna str.",BusinessSegment.SmallCompany),
                 new CorporateClient(5,"Peralni, boileri izkupuvame",CompanyType.ET,127101154,"2 Industrialna str.",BusinessSegment.SmallCompany),
                 new CorporateClient(6,"Voda ne piem",CompanyType.EOOD,127101154,"3 Industrialna str.",BusinessSegment.MiddleCompany),
                 new CorporateClient(7,"Mafia",CompanyType.AD,127897451,"4 Industrialna str.",BusinessSegment.BigCompany)
            };

            foreach (Customer cust in firstCustomers)
            {
                myBank.AllCustomers.Add(cust); // add all customers in bank database
            }

            firstCustomers[0].ClientAccounts.Add(new DepositAccount("BG55RBBG91554000000115",firstCustomers[0],0.11m,DepositMaturity.SightDeposit));
            firstCustomers[0].ClientAccounts.Add(new LoanAccount("BG55RBBG91558000000113", firstCustomers[0], 0.8m, LoanMortageTerm.OneYear,10000));
            firstCustomers[0].ClientAccounts.Add(new MortageAccount("BG55RBBG91558000000121", firstCustomers[0], 0.59m,LoanMortageTerm.TwelveYears,25000));
            firstCustomers[1].ClientAccounts.Add(new DepositAccount("BG77RBBG91552000000216", firstCustomers[1], 0.15m, DepositMaturity.OneMonth));
            firstCustomers[2].ClientAccounts.Add(new LoanAccount("BG66RBBG91558000000314", firstCustomers[2], 0.89m, LoanMortageTerm.TwoYears,1500));
            firstCustomers[3].ClientAccounts.Add(new MortageAccount("BG88RBBG9155800000419", firstCustomers[3], 0.51m, LoanMortageTerm.FiveYears, 35000));
            firstCustomers[4].ClientAccounts.Add(new LoanAccount("BG21RBBG9155800000517", firstCustomers[4], 0.78m, LoanMortageTerm.ThreeYears, 20000));
            firstCustomers[5].ClientAccounts.Add(new DepositAccount("BG42RBBG9155400000614", firstCustomers[5], 0.09m, DepositMaturity.SightDeposit));

            for (int client = 0; client < firstCustomers.Length; client++)
            {
                foreach (Account acc in firstCustomers[client].ClientAccounts)
                {
                    myBank.AllAccounts.Add(acc); // add all acount in bank database
                }
                foreach (DepositAccount depAcc in firstCustomers[client].ClientAccounts.OfType<DepositAccount>().ToArray())
                {
                    depAcc.DepositFunds((client + 1) * 100); //deposit some funds in deposit accounts
                }
            }
            DepositAccount firstAccount = firstCustomers[0].ClientAccounts[0] as DepositAccount;
            if (firstAccount!=null)
            {
                firstAccount.DepositFunds(1115);
            }

            DepositAccount depAccount = firstCustomers[1].ClientAccounts[0] as DepositAccount;
            if (depAccount!=null)
            {
                depAccount.DrawFunds(20.50m);
            }

            MortageAccount mortAccount = firstCustomers[0].ClientAccounts[2] as MortageAccount;
            if (mortAccount != null)
            {
                mortAccount.DepositFunds(880);
            }

            LoanAccount loanAccount = firstCustomers[4].ClientAccounts[0] as LoanAccount;
            if (loanAccount!=null)
            {
                loanAccount.DepositFunds(19500);
                loanAccount.DepositFunds(500); //total loan is paid
            }

            Console.WriteLine(myBank);
            //firstCustomers[0].ClientAccounts[0].CalculateInterest(6);
            firstCustomers[0].ClientAccounts[1].CalculateInterest(15);
            firstCustomers[0].ClientAccounts[2].CalculateInterest(20);
            Console.WriteLine(firstCustomers[0]);
            firstCustomers[3].ClientAccounts[0].CalculateInterest(30);
            Console.WriteLine(firstCustomers[3]);
        }
    }
}
