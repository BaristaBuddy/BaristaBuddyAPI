using BaristaBuddyApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaristaBuddyApi.Repositories
{
    public interface IcartRepository
    {
        Task<Cart> SaveNewCharge(Cart cart);
        Task<Cart> GetOneCharge (string id);
    }
}
