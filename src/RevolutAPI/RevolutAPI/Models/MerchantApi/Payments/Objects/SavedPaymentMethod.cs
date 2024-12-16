using Newtonsoft.Json;


namespace RevolutAPI.Models.MerchantApi.Payments.Objects
{
    public class SavedPaymentMethod
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("initiator")]
        public string Initiator { get; set; }

        [JsonProperty("environment",NullValueHandling = NullValueHandling.Ignore)]
        public Enviroment Environment { get; set; }
        public SavedPaymentMethod(string type, string id , string initiator, Enviroment enviroment = null )
        {
            Type = type;
            Id = id; 
            Initiator = initiator; 
            Environment = enviroment;
        }
    }
}
