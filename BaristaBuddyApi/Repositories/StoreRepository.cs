using BaristaBuddyApi.Data;
using BaristaBuddyApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaristaBuddyApi.Repositories
{
    internal class StoreRepository : IStoreRepository
    {
        private BaristaBuddyDbContext _context;

        public StoreRepository(BaristaBuddyDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<StoreDTO>> GetAllStores()
        {
            var store = await _context.Store
                .Select(store => new StoreDTO
                {
                    Id = store.Id,
                    Name = store.Name,
                    StreetAddress = store.StreetAddress,
                    City = store.City,
                    State = store.State,
                    Zip = store.Zip,
                    Phone = store.Phone,
                    WebsiteUrl = store.WebsiteUrl,
                    StoreImageUrl = store.StoreImageUrl
                })
                .ToListAsync();

            return store;
        }

        
    }
}