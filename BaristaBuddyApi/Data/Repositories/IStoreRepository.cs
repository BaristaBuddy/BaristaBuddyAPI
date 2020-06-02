using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaristaBuddyApi.Data
{
    public class IStoreRepository
    {
        Task <IEnumerable><StoreDTO>>GetAllStores();
    }
}
