using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RevolutAPI.Models.BusinessApi.Counterparties
{
    public class GetCounterpartiesReq
    {
        
        public string Name { get; set; }
        public string AccountNo { get; set; }
        public string SortCode { get; set; }
        public string Iban { get; set; }
        public string Bic { get; set; }
        public DateTime? CreatedBefore { get; set; }
        public int? Limit { get; set; }

        public GetCounterpartiesReq(string name = null,
            string accountNo = null,
            string sortCode = null, 
            string iban = null, 
            string bic = null, 
            DateTime? createdBefore = null, 
            int? limit = null)
        {
            Name = name;
            AccountNo = accountNo;
            SortCode = sortCode;
            Iban = iban;
            Bic = bic;
            CreatedBefore = createdBefore;
            Limit = limit;
        }
    }
}
