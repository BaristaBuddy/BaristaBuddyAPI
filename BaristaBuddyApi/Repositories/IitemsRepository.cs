using BaristaBuddyApi.Models;
using BaristaBuddyApi.Models.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaristaBuddyApi.Repositories
{
    public interface IitemsRepository
    {
        Task<IEnumerable<ItemDTO>> GetAllItems(int storeId);
        Task<ItemDTO> GetOneItem(int storeId, int itemId);
        Task<bool> UpdateItem(int storeId, int itemId, Item item);
        Task<ItemDTO> SaveNewItem(CreateItem createItem, int storeId);
        Task<ItemDTO> DeleteItem(int storeId, int itemId);
        Task<IEnumerable<ItemModifierDTO>> GetAllItemModifiers(int storeId, int itemId);
        Task<ItemModifierDTO> AddNewItemModifier(int storeId, int itemId, ItemModifier itemModifier);
        Task<IEnumerable<ItemSizeDTO>> GetAllItemSizes(int storeId, int itemId);
        Task<bool> UpdateItemSize(int itemId, string sizeId, ItemSize itemSize);
        Task<ItemSizeDTO> AddNewItemSize(int itemId, ItemSize itemSize);
    }
}
