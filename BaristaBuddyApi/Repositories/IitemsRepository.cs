using BaristaBuddyApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaristaBuddyApi.Repositories
{
    public interface IitemsRepository
    {
        Task<IEnumerable<Item>> GetAllItems();
    }
}
