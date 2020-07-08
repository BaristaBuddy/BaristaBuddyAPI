using BaristaBuddyApi.Models;
using BaristaBuddyApi.Models.DTO;
using BaristaBuddyApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using BaristaBuddyApi.Services;
using System.Security.Claims;

namespace BaristaBuddyApi.Controllers
{
    [Route("Api/[Controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        IOrdersRepository orderRepository;
        private readonly IUserManager userManager;

        public OrdersController(IOrdersRepository orderRepository)
        {
            this.orderRepository = orderRepository;
            this.userManager = userManager;
        }

        // GET: api/ordes made by user


        // GET: api/ordes
        [HttpGet("{id}")]

        public async Task<ActionResult<OrderDTO>> GetOneOrder(int id)
        {
            return Ok(await orderRepository.GetOneOrder(id));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutOrder( int id,Orders order)
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
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<OrderDTO>> PostOrder(Orders order)
        {
            if (HttpContext.User.Identity is ClaimsIdentity identity)
            {
                var usernameClaim = identity.FindFirst("UserId");
                var userId = usernameClaim.Value;

                var user = await userManager.FindByIdAsync(userId);
                if (user == null)
                {
                    return Unauthorized();
                }
            }
            await orderRepository.SaveNewOrder(order);

            return CreatedAtAction("GetOrder", new { id = order.Id }, order);
        }
    }
 }

