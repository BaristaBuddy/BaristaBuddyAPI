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
        Task<StoreDTO> SaveNewHotel(Store store);
        Task<StoreDTO> DeleteHotel(int id);
    }
}