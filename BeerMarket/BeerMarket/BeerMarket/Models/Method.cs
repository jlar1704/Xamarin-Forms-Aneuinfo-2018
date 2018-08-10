using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace BeerMarket.Models
{
    public class Method
    {
        [JsonProperty("mash_temp")]
        public List<MashTemp> MashTemp { get; set; }

        [JsonProperty("fermentation")]
        public Fermentation Fermentation { get; set; }

        [JsonProperty("twist")]
        public object Twist { get; set; }
    }
}
