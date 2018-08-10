using System;
using Newtonsoft.Json;

namespace BeerMarket.Models
{
    public class Fermentation
    {
        [JsonProperty("temp")]
        public BoilVolume Temp { get; set; }
    }
}
