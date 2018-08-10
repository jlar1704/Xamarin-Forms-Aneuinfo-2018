using System;
using Newtonsoft.Json;

namespace BeerMarket.Models
{
    public class MashTemp
    {
        [JsonProperty("temp")]
        public BoilVolume Temp { get; set; }

        [JsonProperty("duration")]
        public long Duration { get; set; }
    }
}
