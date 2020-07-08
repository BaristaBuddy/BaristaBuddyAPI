using BaristaBuddyApi.Data;
using BaristaBuddyApi.Models;
using BaristaBuddyApi.Models.DTO;
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
        
        public OrderItemController ( IOrderItemRepository orderItemRepository)
        {
            this.orderItemRepository = orderItemRepository;
        }

        [HttpGet("{id}")]
        public async  Task<ActionResult<OrderItemDTO> > GetOrderItem (int id )
        {
            var orderItem = await orderItemRepository.GetOneOrderItem(id);

            if (orderItem == null)
            {
                return NotFound();
            }

            return orderItem;
        }
    }
}
