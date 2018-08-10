using System;
using System.Collections.Generic;
using System.Net.Http;
using BeerMarket.Models;
using Newtonsoft.Json;

namespace BeerMarket.Services
{
    public class BeerServices : IBeerServices
    {
        public async System.Threading.Tasks.Task<IEnumerable<Beer>> GetAllBeersAsync()
        {
            var result = new List<Beer>();
            try
            {
                using (var client = new HttpClient())
                {
                    var stringResponse = await client.GetStringAsync("https://api.punkapi.com/v2/beers");
                    var settings = new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        MissingMemberHandling = MissingMemberHandling.Ignore
                    };
                    result = JsonConvert.DeserializeObject<List<Beer>>(stringResponse, settings);
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }

            return result;
        }
    }
}
