using BaristaBuddyApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaristaBuddyApi.Repositories
{
    public interface IitemsRepository
    {
        Task<IEnumerable<ItemDTO>> GetAllItems();
        Task<ItemDTO> GetOneItem(int id);
        Task<bool> UpdateItem(int id, Item item);
        Task SaveNewItem(Item item);
    }
}
