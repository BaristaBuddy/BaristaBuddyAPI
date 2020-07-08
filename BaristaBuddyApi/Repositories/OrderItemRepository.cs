using BaristaBuddyApi.Data;
using BaristaBuddyApi.Models.DTO;
using BaristaBuddyApi.Models.Identity;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaristaBuddyApi.Repositories
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private BaristaBuddyDbContext _context;

        public OrderItemRepository (BaristaBuddyDbContext _context)
        {
            this._context = _context;
        }

        public async Task<OrderItemDTO> CreateNewOrderItem(OrderItem orderItem)
        {
            _context.OrderItem.Add(orderItem);

            await _context.SaveChangesAsync();

            return await GetOneOrder(orderItem.Id);

        }

        public Task<OrderItemDTO> DeleteOrderItem(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UptadeOrderItem(int id, OrderItem orderItem)
        {
            throw new NotImplementedException();
        }
    }
}
