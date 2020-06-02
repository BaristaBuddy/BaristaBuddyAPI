using BaristaBuddyApi.Models;
using BaristaBuddyApi.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaristaBuddyApi.Data
{
    public class IStoreRepository
    {
        Task <IEnumerable<StoreDTO>>GetAllStores();
        Task<StoreDTO> GetOneStore(int id);
        Task<bool> UpdateStore(int id, Store store);

        Task<StoreDTO> saveNewStore(Store store);
        Task<StoreDTO> DeleteStore(int id);
    }
}
