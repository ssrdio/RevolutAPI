using System;
using System.Collections.Generic;
using System.Text;

namespace RevolutAPI.Models.Counterparties
{
    public class AddCounterpartyReq
    {
        public string ProfileType { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
