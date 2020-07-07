using BaristaBuddyApi.Data;
using BaristaBuddyApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaristaBuddyApi.Repositories
{
    internal  class OrdersRepository:IOrdersRepository
    {
        private BaristaBuddyDbContext _context;

        public OrdersRepository (BaristaBuddyDbContext _context)
        {
            this._context = _context;
        }

        public async Task<Orders> DeleteOrder (int id ,int storId, int userId)
        {
            var order = await _context.Order.FindAsync();

                if (order==null)
            {
                return null;
            }

            var storeToReturn = await GetOneOrder(id);
            _context.Remove(order);

            await _context.SaveChangesAsync();
            return storeToReturn;

        }
        public async Task<Orders> GetOneOrder(int id)
        {
            var order = await _context.Order
                .Where(o=> o.Id==id)
               .Select(order => new Orders
               {
                   PickupName = order.PickupName,
                   OrderTime = order.OrderTime,
                   Id=order.Id,

               }).FirstOrDefaultAsync();

            return order;
        }

        public async Task<Orders> GetAllOrders()
        {
            var order = await _context.Order
                .Select(order => new Orders
                {
                    OrderTime= order.OrderTime,
                    PickupName= order.PickupName,
                    StoreId= order.StoreId,
                    User.

                }).ToListAsync();
        }
    }
}
