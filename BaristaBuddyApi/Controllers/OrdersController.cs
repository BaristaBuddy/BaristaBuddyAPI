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
        IStoreRepository storeRepository;

        public OrdersController(IOrdersRepository orderRepository, IUserManager thisUserManager, IStoreRepository thisStoreRepository )
        {
            this.orderRepository = orderRepository;
            this.userManager = thisUserManager;
            this.storeRepository = thisStoreRepository;
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
        public async Task<ActionResult<OrderDTO>> PostOrder(CreateOrder orderData)
        {
            
            if (HttpContext.User.Identity is ClaimsIdentity identity)
            {
                var usernameClaim = identity.FindFirst("UserId");
                var userId = usernameClaim.Value;

                var thisUser = await userManager.FindByIdAsync(userId);
                if (thisUser == null)
                {
                    return Unauthorized();
                }
                var thisStore = await storeRepository.FindAStore(orderData.storeId);
                Orders order = new Orders()
                {
                    store = thisStore,
                    user = thisUser
                };

            await orderRepository.SaveNewOrder(order);

            return CreatedAtAction("GetOrder", new { id = order.Id }, order);
        }
            return Unauthorized();

        }
    }
 }

