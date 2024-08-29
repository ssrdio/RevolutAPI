using System;
using System.Collections.Generic;
using System.Text;

namespace RevolutAPI.Models.Authorization
{
    public class AuthorizationCodeResp
    {
        public string AccessToken { get; set; }
        public string TokenType { get; set; }
        public long ExpiresIn { get; set; }
        public string RefreshToken { get; set; }
    }
}
