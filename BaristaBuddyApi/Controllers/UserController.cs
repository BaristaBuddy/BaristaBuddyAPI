
using BaristaBuddyApi.Models.Identity;
using BaristaBuddyApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaristaBuddyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public class UsersController : ControllerBase
        {
            private readonly IUserManager userManager;

            public UsersController(IUserManager userManager)
            {
                this.userManager = userManager;
            }

            [HttpPost("Login")]
            public async Task<IActionResult> Login(BaristaBuddyUser login)
            {
                var user = await userManager.FindByNameAsync(login.UserName);
                if (user != null)
                {
                    var result = await userManager.CheckPasswordAsync(user, login.Password);
                    if (result)
                    {
                       
                    }

                }
            }
}
