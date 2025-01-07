using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RevolutAPI.Models.BusinessApi.Card.Objects
{
    public class CardSpendProgram
    {
        [JsonProperty("label")]
        public string Label { get; set; }
    }
}
