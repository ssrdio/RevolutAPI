using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutAPI.Models.Shared
{
    public class Contact
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("phone")]
        public string Phone { get; set; }

        public Contact(string name = null, string email = null, string phone = null)
        {
            Name = name;
            Email = email;
            Phone = phone;
        }
    }
}
