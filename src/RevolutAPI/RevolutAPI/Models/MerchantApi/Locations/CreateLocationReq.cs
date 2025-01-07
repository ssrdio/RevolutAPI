using RevolutAPI.Models.MerchantApi.Locations.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RevolutAPI.Models.MerchantApi.Locations
{
    public class CreateLocationReq
    {

        public string Name { get; set; }
        public string Type { get; set; }
        public LocationDetails Details { get; set; }

     
    }
}
