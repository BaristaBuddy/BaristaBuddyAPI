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

        
        public async Task<Orders> GetOneOrder(int id)
        {
            var order = await _context.Order
                .Where(o=> o.Id==id)
               .Select(order => new Orders
               {
                   PickupName = order.PickupName,
                   OrderTime = order.OrderTime,
                   OrderItem= order.OrderItem
                   .Where(o=> o.OrderId == id)
                   .Select(ot=> new OrderItem { 
                       ItemId=ot.ItemId,
                   }).ToList()
               }).FirstOrDefaultAsync();

            return order;
        }

        public async Task<Orders> GetAllOrders(string userid)
        {
            var order = await _context.Order
                .Where(o=>o.User.Id==userid)
                .Select(order => new Orders
                {
                    PickupName = order.PickupName,
                    OrderTime = order.OrderTime,
                    OrderItem = order.OrderItem
                   .Select(ot => new OrderItem
                   {
                       ItemId = ot.ItemId,
                   }).ToList(),
               }).FirstOrDefaultAsync();

            return order;
        }


    }
}
