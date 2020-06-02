using BaristaBuddyApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BaristaBuddyApi.Repositories
{
    public interface IStoreRepository
    {
        Task<IEnumerable<Store>> GetAllStores();
    }
}