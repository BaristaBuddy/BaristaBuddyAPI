
using BaristaBuddyApi.Models;
using BaristaBuddyApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaristaBuddyApi.Controllers
{
    [Route("Api/[Controller]")]
    [ApiController]
    public class CartController :Controller
    {
       [HttpPost]
       public async Task<dynamic> Pay( Cart cart)
        {
            return await CartRepository.CreatePayement(cart.CardNumber, cart.Month, cart.Year, cart.Value, cart.Cvc);
        }
    }
}
