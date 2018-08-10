using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BeerMarket.Models;

namespace BeerMarket.Services
{
    public interface IBeerServices
    {
        Task<IEnumerable<Beer>> GetAllBeersAsync();
    }
}
