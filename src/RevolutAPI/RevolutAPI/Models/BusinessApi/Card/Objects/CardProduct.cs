using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutAPI.Models.BusinessApi.Card.Objects
{
    public class CardProduct
    {
        [JsonProperty("code")]
        public string Code {  get; set; }
    }
}
