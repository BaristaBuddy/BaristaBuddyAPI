using BaristaBuddyApi.Data;
using BaristaBuddyApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IEnumerable<ItemDTO>> GetAllItems(int storeId)
        {
            var allItems = await _context.Item
                
                .Select(item => new ItemDTO
                {
                    ItemId = item.ItemId,
                    StoreId = item.StoreId,
                    Name = item.Name,
                    Ingredients = item.Ingredients,
                    ImageUrl = item.ImageUrl,
                    Price = item.Price
                }
                
                ).ToListAsync();

            return allItems;
        }

        public async Task<ItemDTO> GetOneItem(int storeId, int itemId)
        {
            var oneItem = await _context.Item
                .Where(item => item.StoreId == storeId)
                .Where(item => item.ItemId == itemId)
                .Select(item => new ItemDTO
                  {
                    ItemId = item.ItemId,
                    StoreId = item.StoreId,
                    Name = item.Name,
                    Ingredients = item.Ingredients,
                    ImageUrl = item.ImageUrl,
                    Price = item.Price
                }
                
                ).FirstOrDefaultAsync();

            return oneItem;
        }

        public Task SaveNewItem(Item item)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateItem(int storeId, int itemId, Item item)
        {
            _context.Entry(item).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemExists(itemId))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        private bool ItemExists(int id)
        {
            return _context.Item.Any(e => e.ItemId == id);
        }
    }
}
