using Newtonsoft.Json;

namespace RevolutAPI.Models.MerchantApi.Webhook
{
    public class RotateWebhookSigningSecretReq
    {
        /// <summary>
        /// The expiration period of the signing secret in the ISO 8601 format.
        /// </summary>
        /// <remarks>
        /// If defined, when the signing secret is rotated, it continues to be valid until the expiration
        /// period passes. Otherwise, it is invalidated immediately.
        /// Maximum expiration period is 7 days.
        /// </remarks>
        [JsonProperty("expiration_period",NullValueHandling = NullValueHandling.Ignore)]
        public string ExpirationPeriod { get; set; }
        public RotateWebhookSigningSecretReq(string expirationPeriod = null)
        {
            ExpirationPeriod = expirationPeriod;
        }
    }
}
