
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

        }
    }
}
