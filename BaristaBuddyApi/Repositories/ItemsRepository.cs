using BaristaBuddyApi.Data;
using BaristaBuddyApi.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BaristaBuddyApi.Repositories
{
    

    
    public class ItemsRepository : IitemsRepository
    {
        private BaristaBuddyDbContext _context;

        public ItemsRepository(BaristaBuddyDbContext _context)
        {
            this._context = _context;
        }

        public Task<IEnumerable<Item>> GetAllItems()
        {
            throw new NotImplementedException();
        }
    }
}
