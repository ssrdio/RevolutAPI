using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;

namespace RevolutAPI.Models.Account
{
    public class GetAccountResp
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double Balance { get; set; }
        public string Currency { get; set; }
        public string State { get; set; }
        public bool Public { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
