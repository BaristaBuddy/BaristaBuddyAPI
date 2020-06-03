using BaristaBuddyApi.Models;
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
    }
}
