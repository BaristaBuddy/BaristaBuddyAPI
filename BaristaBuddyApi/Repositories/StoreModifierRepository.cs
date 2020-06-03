using BaristaBuddyApi.Data;
using BaristaBuddyApi.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaristaBuddyApi.Repositories
{
    public class StoreModifierRepository : IstoreModifierRepository
    {

            private BaristaBuddyDbContext _context;

            public StoreModifierRepository(BaristaBuddyDbContext _context)
            {
                this._context = _context;
            }

            public async Task<StoreModifierDTO> DeleteItem(int modifierId)
            {
                var modofier = await _context.Item.FindAsync(modifierId);

                if (modifierId == null)
                {
                    return null;
                }

                var modifierToReturn = await GetOneModifier(modifierId);

                _context.Remove(modofier);
                await _context.SaveChangesAsync();

                return modifierToReturn;

            }

        public Task<StoreModifierDTO> DeleteModifier(int modifierId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<StoreModifierDTO>> GetAllIModifier()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<StoreModifierDTO>> GetAllItems(int storeId)
            {
                var allItems = await _context.Item
                    .Where(item => item.StoreId == storeId)
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

            public async Task<StoreModifierDTO> GetOneItem(int storeId, int itemId)
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

        public Task<StoreModifierDTO> GetOneModifier(int modifierId)
        {
            throw new NotImplementedException();
        }

        public async Task<StoreModifierDTO> SaveNewItem(CreateItem createItemData, int storeId)
            {
                var newItem = new Item
                {
                    StoreId = storeId,
                    ItemId = createItemData.ItemId,
                    Name = createItemData.Name,
                    Ingredients = createItemData.Ingredients,
                    ImageUrl = createItemData.ImageUrl,
                    Price = createItemData.Price
                };

                _context.Item.Add(newItem);
                await _context.SaveChangesAsync();

                var itemToRetun = await GetOneItem(storeId, createItemData.ItemId);
                return itemToRetun;
            }

        public Task<StoreModifierDTO> SaveNewModifier(StoreModifierDTO modifier)
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

        public Task<bool> UpdateModifier(int modifierId)
        {
            throw new NotImplementedException();
        }

        private bool ItemExists(int id)
            {
                return _context.Item.Any(e => e.ItemId == id);
            }
        }
    
}
