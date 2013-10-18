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
                new IndividualCustomer(1,"Koko","Popov","Milev",9010108887,"1 Parva str.",Gender.Male),
                new IndividualCustomer(2,"Pepo","Petev","Pipev",7701228688,"2 Vtora str.",Gender.Male),
                new IndividualCustomer(3,"Pepa","Coneva","Siveva",8912128974,"3 Treta str.",Gender.Female),
                new CorporateClient(4,"Kabeli vsiakakvi rejem",CompanyType.ET,127654258,"1 Industrialna str.",BusinessSegment.SmallCompany),
                 new CorporateClient(5,"Peralni, boileri izkupuvame",CompanyType.ET,127101154,"2 Industrialna str.",BusinessSegment.SmallCompany),
                 new CorporateClient(6,"Peralni, boileri izkupuvame",CompanyType.EOOD,127101154,"2 Industrialna str.",BusinessSegment.MiddleCompany),
                 new CorporateClient(7,"Mafia",CompanyType.AD,127897451,"4 Industrialna str.",BusinessSegment.BigCompany)
            };

            foreach (Customer cust in firstCustomers)
            {
                myBank.AllCustomers.Add(cust);
            }

            firstCustomers[0].ClientAccounts.Add(new DepositAccount("BG55RBBG91554000000115",firstCustomers[0],1.5m,DepositMaturity.SightDeposit));
            
        }
    }
}
