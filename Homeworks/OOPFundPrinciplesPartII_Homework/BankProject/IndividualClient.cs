using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject
{
    public class IndividualClient : Customer
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public ulong IDNumber { get; set; }
        public Gender Gender { get; set; }

        public IndividualClient(int clientNumber, string firstName, string middleName, string lastName, ulong idNumber, string address, Gender gender)
            : base(clientNumber, address)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.IDNumber = idNumber;
            this.Gender = gender;
        }

        public override string ToString()
        {
            StringBuilder clientInfo = new StringBuilder();
            clientInfo.AppendFormat("\r\nInformation about client number {0}", this.ClientNumber.ToString().PadLeft(6, '0'));
            clientInfo.AppendFormat("\r\nType of the client: {0}", this.GetType().Name);
            clientInfo.AppendFormat("\r\nFirst name: {0}", this.FirstName);
            clientInfo.AppendFormat("\r\nMiddle name: {0}", this.MiddleName);
            clientInfo.AppendFormat("\r\nLast name: {0}", this.LastName);
            clientInfo.AppendFormat("\r\nID number: {0}", this.IDNumber);
            clientInfo.AppendFormat("\r\nAddress: {0}", this.Address);
            clientInfo.AppendFormat("\r\nGender: {0}", this.Gender);
            clientInfo.Append(AddAcounts(this.ClientAccounts.ToArray()));
            return clientInfo.ToString();
        }
    }
}
