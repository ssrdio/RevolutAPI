using System;
using System.Collections.Generic;
using System.Text;

namespace RevolutAPI.Models.JWT
{
    public class JWTPayload
    {
        public string iss { get; set; }
        public string sub { get; set; }
        public string aud => "https://revolut.com"; //hardcoded see documetation
        public long exp 
        {
            get
            {
                DateTimeOffset dto = new DateTimeOffset(DateTime.UtcNow, TimeSpan.Zero);
                return dto.ToUnixTimeSeconds() + 60 * 60;
            }
        }
    }
}
