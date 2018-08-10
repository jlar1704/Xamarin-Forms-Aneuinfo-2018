using System;
using Newtonsoft.Json;

namespace BeerMarket.Models
{
    public class Malt
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("amount")]
        public BoilVolume Amount { get; set; }
    }
}
