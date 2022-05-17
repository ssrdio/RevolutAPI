using System.Net;

namespace RevolutAPI.Tests
{
    public class Config
    {
        public static readonly string ENDPOINT = "https://sandbox-b2b.revolut.com/api/1.0";
        public static readonly string TOKEN = "sand_your_key";

        // used in payments tests
        public static readonly string ACCOUNT_ID = "";
        public static readonly string COUNTERPARTY_ID = "";
        public static readonly string COUNTERPARTY_ACCOUNT_ID = "";
        // currency must match for both ACCOUNT_ID and COUNTERPARTY_ACCOUNT_ID
        public static readonly string CURRENCY = "EUR";

        public static readonly string MERCHANTAPIKEY = "lhAnTzB2LU1ehOHnoVr4A1DaXbQSdpkjVpS9i7txhOnxpiPb_l_XpbbvnUwlNKcQ";
        public static readonly string MERCHANTENDPOINT = "https://sandbox-merchant.revolut.com/api/1.0";

        public static readonly string PrivateCert;
        public static readonly string CertificatePassword;
        public static readonly string Issuer;
        public static readonly string ClientId;
        public static readonly string RefreshToken;
    }
}