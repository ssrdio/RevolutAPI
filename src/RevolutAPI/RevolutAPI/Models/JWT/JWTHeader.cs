using System;
using System.Collections.Generic;
using System.Text;

namespace RevolutAPI.Models.JWT
{
    public class JWTHeader
    {
        public string alg => JwtHashAlgorithm.RS256.ToString();
        public string typ => "JWT";
    }
}
