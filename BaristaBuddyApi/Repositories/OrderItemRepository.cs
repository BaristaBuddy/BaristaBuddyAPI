using BaristaBuddyApi.Data;
using BaristaBuddyApi.Models.DTO;
using BaristaBuddyApi.Models.Identity;
using Microsoft.EntityFrameworkCore;
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

            return await GetOneOrderItem(orderItem.Id);

        }

        public async Task<OrderItemDTO> DeleteOrderItem(int id)
        {
            var orderItem = await _context.OrderItem.FindAsync(id);

            if (orderItem == null)
            {
                return null;
            }

            var storeToReturn = await GetOneOrderItem(id);

            _context.OrderItem.Remove(orderItem);


            await _context.SaveChangesAsync();

            return storeToReturn;
        }

        public async Task<OrderItemDTO> GetOneOrderItem(int id)
        {
            var orderItem = await _context.OrderItem
                .Where(oi=> oi.Id==id)
               .Select(oi => new OrderItemDTO
               {
                  Price=oi.Item.Price,
                  Name=oi.Item.Name,
                  ImageUrl=oi.Item.ImageUrl,
                  Quantity=oi.Quantity,
                  Size=oi.Size,
                  AdditionalCost=oi.AdditionalCost,
               }).FirstOrDefaultAsync();

            return orderItem;
        }

        public async Task<bool> UptadeOrderItem(int id, OrderItem orderItem)
        {
            _context.Entry(orderItem).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderItemExists(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }

            }
        }

        public bool OrderItemExists(int id)
        {
            return _context.Store.Any(e => e.Id == id);
        }
    }
}
