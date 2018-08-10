using System;
using Newtonsoft.Json;

namespace BeerMarket.Models
{
    public class BoilVolume
    {

        [JsonProperty("value")]
        public double Value { get; set; }

        [JsonProperty("unit")]
        public string Unit { get; set; }

    }
}
