namespace RevolutAPI.Models.Authorization
{
    public class RefreshAccessTokenModel
    {
        public string PrivateCert { get; set; }
        public string CertificatePassword { get; set; }
        public string Issuer { get; set; }
        public string ClientId { get; set; }
        public string RefreshToken { get; set; }
    }
}
