using BaristaBuddyApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaristaBuddyApi.Repositories
{
    public interface ICartRepository
    {
        Task<Cart> CreatePayement(string token);
    }
}
