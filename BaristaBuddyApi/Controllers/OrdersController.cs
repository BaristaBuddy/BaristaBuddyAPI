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
    [Route("Api/[Controller]")]
    [ApiController]
    public class OrdersController :ControllerBase
    {
        IOrdersRepository orderRepository;

        public OrdersController(IOrdersRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        // GET: api/ordes made by user
        

        // GET: api/ordes
        [HttpGet ("{id}")]

        public async Task<ActionResult<OrderDTO>> GetOneOrder(int id)
        {
            return Ok(await orderRepository.GetOneOrder(id));
        }

        [HttpPost]
        public async Task<ActionResult<OrderDTO>> PutOrder( int id,Orders order)
        {
            if (id != order.Id)
            {
                return BadRequest();
            }

            bool didUpdate = await orderRepository.UpdateOrder(id, order);

            if (!didUpdate)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
 }

