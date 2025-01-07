using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutAPI.Models.Shared
{
    public class Shipments
    {
        [JsonProperty("shipping_company_name")]
        public string ShippingCompanyName { get; set; }
        [JsonProperty("tracking_number")]
        public string TrackingNumber { get; set; }

        [JsonProperty("estimated_delivery_date")]
        public string  EstimatedDeliveryDate { get; set; }
        [JsonProperty("tracking_url")]
        public string TrackingUrl { get; set; }

        public Shipments(string companyName, string trackingNumber, string esitmatedDeliveryDate = null,string trackingUrl = null)
        {
            ShippingCompanyName = companyName;
            TrackingNumber = trackingNumber;
            EstimatedDeliveryDate = esitmatedDeliveryDate;
            TrackingUrl = trackingUrl;
        }
    }
}
