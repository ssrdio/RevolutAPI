using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutAPI.Models.Shared
{
    public class Shipping
    {
        [JsonProperty("address",NullValueHandling = NullValueHandling.Ignore)]
        public Address Address { get; set; }
        [JsonProperty("contact", NullValueHandling = NullValueHandling.Ignore)]
        public Contact Contact { get; set; }
        [JsonProperty("shipments",NullValueHandling = NullValueHandling.Ignore)]
        public List<Shipments> Shipments { get; set; }
        public Shipping(Address address = null, Contact contact = null, List<Shipments> shipments = null)
        {
            Address = address;
            Contact = contact;
            Shipments = shipments;
        }
    }
}
