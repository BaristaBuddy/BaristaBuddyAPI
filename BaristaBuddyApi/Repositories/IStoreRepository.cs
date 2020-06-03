using BaristaBuddyApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BaristaBuddyApi.Repositories
{
    public interface IStoreRepository
    {
        Task<IEnumerable<StoreDTO>> GetAllStores();
        Task<StoreDTO> GetOneSTore(int id);
        Task<bool> UpdateStore(int id, Store store);
        Task<StoreDTO> SaveNewStore(Store store);
        Task<StoreDTO> DeleteStore(int id);
    }
}