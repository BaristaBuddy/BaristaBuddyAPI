using BaristaBuddyApi.Data;
using BaristaBuddyApi.Models;
using BaristaBuddyApi.Models.DTO;
using BaristaBuddyApi.Models.Identity;
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

        
        public async Task<OrderDTO> GetOneOrder(int id)
        {
            var order = await _context.Order
                .Where(o=> o.Id==id)
               .Select(order => new OrderDTO
               {
                  
                               
             
               }).FirstOrDefaultAsync();

            return order;
        }



     
        public async Task<bool> UpdateOrder(int id, Orders order)
        {
            _context.Entry(order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }

            }
        }
        private bool OrderExists(int id)
        {
            return _context.Store.Any(e => e.Id == id);

        }

        public async Task<OrderDTO> SaveNewOrder(Orders order)
        {
            _context.Order.Add(order);
            await _context.SaveChangesAsync();

            return await GetOneOrder(order.Id);
        }

     
    }
}
