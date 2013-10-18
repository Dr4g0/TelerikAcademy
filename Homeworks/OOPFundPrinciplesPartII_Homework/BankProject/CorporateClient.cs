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
    }
}
