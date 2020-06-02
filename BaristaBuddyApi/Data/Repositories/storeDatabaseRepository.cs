using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaristaBuddyApi.Data
{
    public class storeDatabaseRepository : IStoreRepository
    {
        private readonly BaristaBuddyDbContext _context;

        public storeDatabaseRepository(BaristaBuddyDbContext context)
        {
            _context = context;
        }

    }
}
