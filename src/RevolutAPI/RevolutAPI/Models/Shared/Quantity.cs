using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutAPI.Models.Shared
{
    public class Quantity
    {
        [JsonProperty("value")]
        public double Value { get; set; }

        [JsonProperty("unit")]
        public string Unit { get; set; }
        public Quantity(double value,string unit = null)
        {
            Value = value;
            Unit = unit;
        }
    }
}
