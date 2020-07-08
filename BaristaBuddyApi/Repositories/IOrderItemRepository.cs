using BaristaBuddyApi.Models.DTO;
using BaristaBuddyApi.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaristaBuddyApi.Repositories
{
    public interface IOrderItemRepository
    {
        Task<OrderItemDTO> CreateNewOrderItem(OrderItem orderItem);
        Task<OrderItemDTO> DeleteOrderItem(int id);
        Task<bool> UptadeOrderItem(int id, OrderItem orderItem);
        Task<OrderItemDTO> GetOneOrderItem(int id);
}
