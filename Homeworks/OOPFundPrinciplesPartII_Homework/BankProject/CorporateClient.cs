using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject
{
    class CorporateClient : Customer
    {
        public string CompanyName { get; set; }
        public int BULSTAT { get; set; }
        public BusinessSegment Segment { get; set; }
        public CompanyType Type { get; set; }

        public CorporateClient(int clientNumber, string companyName,CompanyType type ,int idBulstat,string address,BusinessSegment segment)
            : base(clientNumber,address)
        {
            this.CompanyName = companyName;
            this.BULSTAT = idBulstat;
            this.Segment = segment;
            this.Type = type;
        }

        public override string ToString()
        {
            StringBuilder clientInfo = new StringBuilder();
            clientInfo.AppendFormat("\r\nInformation about client number {0}", this.ClientNumber.ToString().PadLeft(6, '0'));
            clientInfo.AppendFormat("\r\nType of the client: {0}", this.GetType().Name);
            clientInfo.AppendFormat("\r\nName: {0} {1}", this.CompanyName,this.Type);
            clientInfo.AppendFormat("\r\nBULSTAT: {0}", this.BULSTAT);
            clientInfo.AppendFormat("\r\nAddress: {0}", this.Address);
            clientInfo.AppendFormat("\r\nEconomic segment: {0}", this.Segment);
            clientInfo.Append(AddAcounts(this.ClientAccounts.ToArray()));
            return clientInfo.ToString();
        }
    }
}
