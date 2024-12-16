using Newtonsoft.Json;
using RevolutAPI.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutAPI.Models.MerchantApi.Orders.Objects
{
    public class LineItem
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("quantity")]
        public Quantity Quantity { get; set; }
        [JsonProperty("unit_price_amount")]
        public long UnitPriceAmount { get; set; }
        [JsonProperty("total_amount")]
        public long TotalAmount { get; set; }
        [JsonProperty("external_id")]
        public string ExternalId { get; set; }
        [JsonProperty("discounts", NullValueHandling = NullValueHandling.Ignore)]
        public NameAmount Discounts { get; set; }
        [JsonProperty("taxes", NullValueHandling = NullValueHandling.Ignore)]
        public NameAmount Taxes { get; set; }

        [JsonProperty("image_urls")]
        public List<string> ImageUrls { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        public LineItem(string name,
            string type,
            Quantity quantity,
            long unitPrice,
            long totalAmount,
            string externalid = null,
            NameAmount discount = null,
            NameAmount taxes = null,
            List<string> imageurls = null,
            string descirption = null,
            string url = null)
        {
            Name = name;
            Type = type;
            Quantity = quantity;
            UnitPriceAmount = unitPrice;
            TotalAmount = totalAmount;
            ExternalId = externalid;
            Discounts = discount;
            Taxes = taxes;
            ImageUrls = imageurls;
            Description = descirption;
            Url = url;
        }

    }
}
