using BaristaBuddyApi.Data;
using BaristaBuddyApi.Models;
using BaristaBuddyApi.Models.DTO;
using Microsoft.Data.SqlClient;
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

        public async Task<ItemModifierDTO> AddNewItemModifier( int itemId, ItemModifier itemModifier)
        {
            var newIM = new ItemModifier
            {
                ItemId = itemId,
                ModifierId = itemModifier.ModifierId,
                AdditionalCost = itemModifier.AdditionalCost
            };

            _context.itemModifier.Add(newIM);
            await _context.SaveChangesAsync();


            var newIMDTO = new ItemModifierDTO
            {
                ModifierName = "new",
                AdditionalCost = itemModifier.AdditionalCost
            };

            return newIMDTO;
        }

        public async Task<ItemSizeDTO> AddNewItemSize(int itemId, ItemSize itemSize)
        {
            var newSize = new ItemSize
            {
               ItemId = itemId,
               Size = itemSize.Size,
               AdditionalCost = itemSize.AdditionalCost
            };

            _context.ItemSize.Add(newSize);
            await _context.SaveChangesAsync();

            var newSizeDTO = new ItemSizeDTO
            {
                Size = itemSize.Size,
                AdditionalCost = itemSize.AdditionalCost
            };

            return newSizeDTO;
        }

        public async Task<ItemDTO> DeleteItem(int storeId, int itemId)
        {
            var item = await _context.Item.FindAsync(itemId);
            if (item == null)
            {
                return null;
            }

            var itemToReturn = await GetOneItem(storeId, itemId);

            _context.Remove(item);
            
            await _context.SaveChangesAsync();

            return itemToReturn;

        }

        public async Task<ItemSizeDTO> DeleteItemSize(int itemId, string sizeId)
        {
            var size = await _context.ItemSize.FindAsync(itemId, sizeId);
            var sizeToReturn = new ItemSizeDTO
            {
                Size = size.Size,
                AdditionalCost = size.AdditionalCost
            };

            _context.Remove(size);
            await _context.SaveChangesAsync();

            return sizeToReturn;
            
        }

        public async Task<IEnumerable<ItemModifierDTO>> GetAllItemModifiers(int storeId, int itemId)
        {
            var allModifiers = await _context.itemModifier
                .Where(im => im.ItemId == itemId)
                .Select(im => new ItemModifierDTO
                {
                    ModifierName = im.Modifier.Name,
                    AdditionalCost = im.AdditionalCost
                }
                ).ToListAsync();

            return allModifiers;
                
        }

        public async Task<IEnumerable<ItemDTO>> GetAllItems(int storeId)
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
                    Price = item.Price,
                    ItemSizes = item.ItemSizes
                    .Select(size => new ItemSizeDTO
                    {
                        Size = size.Size,
                        AdditionalCost = size.AdditionalCost
                    }).ToList()
                }
                ).ToListAsync();

            return allItems;
        }

        public async Task<IEnumerable<ItemSizeDTO>> GetAllItemSizes(int storeId, int itemId)
        {
            var sizes = await _context.ItemSize
                .Where(size => size.ItemId == itemId)
                .Select(size => new ItemSizeDTO 
                {
                    Size = size.Size,
                    AdditionalCost = size.AdditionalCost
                }).ToListAsync();

            return sizes.OrderBy(size => size.AdditionalCost);
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
                   ItemModifiers = item.ItemModifiers
                   .Select(thisIm => new ItemModifierDTO
                   {
                       ModifierName = thisIm.Modifier.Name,
                       AdditionalCost = thisIm.AdditionalCost
                   }).ToList(),
                    Price = item.Price
                }

                ).FirstOrDefaultAsync();

            return oneItem;
        }

        public async Task<ItemDTO> SaveNewItem(CreateItem createItemData, int storeId)
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

            var itemToRetun = await GetOneItemByName(storeId, createItemData.Name);

            if (createItemData.ItemModifiers != null)
            {

                foreach (var itemMod in createItemData.ItemModifiers)
                {
                    await AddNewItemModifier(itemToRetun.ItemId, itemMod);

                } 
            }
            return itemToRetun;
        }

        private async Task<ItemDTO> GetOneItemByName(int storeId, string name)
        {
            var oneItem = await _context.Item
               .Where(item => item.StoreId == storeId)
               .Where(item => item.Name == name)
               .Select(item => new ItemDTO
               {
                   ItemId = item.ItemId,
                   StoreId = item.StoreId,
                   Name = item.Name,
                   Ingredients = item.Ingredients,
                   ImageUrl = item.ImageUrl,
                   ItemModifiers = item.ItemModifiers
                  .Select(thisIm => new ItemModifierDTO
                  {
                      ModifierName = thisIm.Modifier.Name,
                      AdditionalCost = thisIm.AdditionalCost
                  }).ToList(),
                   Price = item.Price
               }

               ).FirstOrDefaultAsync();

            return oneItem;
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

        public async Task<bool> UpdateItemSize(int itemId, string sizeId, ItemSize itemSize)
        {
            _context.Entry(itemSize).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemSizeExists(itemId, sizeId))
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

        private bool ItemSizeExists(int id, string sizeId)
        {
            return _context.ItemSize.Any(e => e.ItemId == id && e.Size == sizeId);
        }
    }
}
