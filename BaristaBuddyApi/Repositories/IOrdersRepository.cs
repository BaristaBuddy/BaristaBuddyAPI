using BaristaBuddyApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaristaBuddyApi.Repositories
{
    public class IOrdersRepository
    {
        Task<IEnumerable<Orders>> GetAllOrders();
        Task<Orders> GetOneOrder(int id);
        Task<bool> UpdateOrder(int id, Orders order);
        Task<Orders> SaveNew(Orders order);
        Task<Orders> DeleteOrder(int id);
    }
}
