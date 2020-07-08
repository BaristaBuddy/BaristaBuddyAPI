using BaristaBuddyApi.Data;
using BaristaBuddyApi.Models;
using BaristaBuddyApi.Models.DTO;
using BaristaBuddyApi.Models.Identity;
using BaristaBuddyApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaristaBuddyApi.Controllers
{
    [Route("api/Order/Item")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        IOrderItemRepository orderItemRepository;

        public OrderItemController(IOrderItemRepository orderItemRepository)
        {
            this.orderItemRepository = orderItemRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderItemDTO>> GetOrderItem(int id)
        {
            var orderItem = await orderItemRepository.GetOneOrderItem(id);

            if (orderItem == null)
            {
                return NotFound();
            }

            return orderItem;
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<OrderItemDTO>> DeleteOrderItem(int id)
        {
            var orderItem = await orderItemRepository.DeleteOrderItem(id);
            if (orderItem == null)
            {
                return NotFound();
            }
            return orderItem;
        }

        [HttpPost]
        public async Task<ActionResult<OrderItem>> PostOrderItem(OrderItem orderItem)
        {
            await orderItemRepository.CreateNewOrderItem(orderItem);

            return CreatedAtAction("GetOrderItem", new { id = orderItem.Id }, orderItem);

        }

        [HttpPut("{id}")]
        
        public async Task<ActionResult<bool>> PostOrderItem(int id, OrderItem orderItem)
        {
            
            if (id != orderItem.Id)
            {
                return BadRequest();
            }

            bool didUpdate = await orderItemRepository.UptadeOrderItem(id,orderItem);

            if (!didUpdate)
            {
                return NotFound();
            }



            return NoContent();
        }
    }
}
