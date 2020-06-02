using BaristaBuddyApi.Data;
using BaristaBuddyApi.Models;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<ItemDTO>> GetAllItems()
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

        public async Task<ItemDTO> GetOneItem(int id)
        {
            var oneItem = await _context.Item
                .Where(item => item.ItemId == id)
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
    }
}
