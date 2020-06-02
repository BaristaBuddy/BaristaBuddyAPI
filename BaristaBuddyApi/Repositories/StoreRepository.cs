using BaristaBuddyApi.Data;
using BaristaBuddyApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
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

        public async Task<StoreDTO> DeleteStore(int id)
        {
            var store = await _context.Store.FindAsync(id);

            if (store == null)
            {
                return null;
            }

            var storeToReturn = await GetOneSTore(id);

            _context.Store.Remove(store);

            await _context.SaveChangesAsync();

            return storeToReturn;

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
                    StoreImageUrl = store.StoreImageUrl,
                    Items = store.Items



                })
                .ToListAsync();

            return store;
        }

        public async Task<StoreDTO> GetOneSTore(int id)
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
                    StoreImageUrl = store.StoreImageUrl,
                    Items = store.Items
                }).FirstOrDefaultAsync(store => store.Id == id);

            return store;
        }



        public async Task<StoreDTO> SaveNewStore(Store store)
        {
            _context.Store.Add(store);
            await _context.SaveChangesAsync();

            return await GetOneSTore(store.Id);
        }



        public async Task<bool> UpdateStore(int id, Store store)
        {
            _context.Entry(store).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StoreExists(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }

            }
        }

        private bool StoreExists(int id)
        {
            return _context.Store.Any(e => e.Id == id);

        }
    }
}