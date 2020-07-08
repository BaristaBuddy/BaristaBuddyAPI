
using BaristaBuddyApi.Models.Identity;
using BaristaBuddyApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BaristaBuddyApi.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
  
        public class UsersController : ControllerBase
        {
            private readonly IUserManager userManager;

            public UsersController(IUserManager userManager)
            {
                this.userManager = userManager;
            }
            [HttpPost("Login")]
            public async Task<IActionResult> Login(LoginData login)
            {
                var user = await userManager.FindByNameAsync(login.UserName);
                if (user != null)
                {
                    var result = await userManager.CheckPasswordAsync(user, login.Password);
                    if (result)
                    {
                        return Ok(new UserWithToken
                        {
                            UserId = user.Id,
                            Token = userManager.CreateToken(user)

                        });
                    }

                    await userManager.AccessFailedAsync(user);
                }
                return Unauthorized();
            }

            [HttpPost("Register")]

            public async Task<IActionResult> Register(Register register)
            {
                var user = new BaristaBuddyUser
                {
                    Email = register.Email,
                    UserName = register.Email,
                    PhoneNumber=register.PhoneNumber,
                    BirthDate= register.BirthDate,
                    FirstName = register.FirstName,
                    LastName = register.LastName

                };

                var result = await userManager.CreateAsync(user, register.Password);
                if (!result.Succeeded)
                {
                    return BadRequest(new 
                    {
                        message = "registration failed",
                        errors = result.Errors
                    });
                }

                return Ok(new UserWithToken
                {
                    UserId = user.Id,
                    Token = userManager.CreateToken(user)
                });


            }

            [Authorize]
            [HttpGet("Self")]
            public async Task<IActionResult> Self()
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

                    return Ok(new
                    {
                        user.Email,
                        user.BirthDate,
                        user.ImageUrl,
                        user.PhoneNumber,
                        user.FirstName,
                        user.LastName,

                    });
                }
                return Unauthorized();
            }

            [HttpGet("{userId}")]
            public async Task<IActionResult> GetUser(string userId)
            {
                var user = await userManager.FindByIdAsync(userId);
                if (user == null)
                    return NotFound();

                return Ok(new
                {
                    UserId = user.Id,
                    user.Email,
                    user.BirthDate,
                    user.ImageUrl,
                    user.PhoneNumber,
                    user.FirstName,
                    user.LastName,

                });
            }

            [HttpPut("userId")]

            public async Task<IActionResult> UpdateUser(string userId, BaristaBuddyUser data)
            {
                var user = await userManager.FindByIdAsync(userId);
                if (user == null)
                    return NotFound();

                user.FirstName = data.FirstName;
                user.LastName = data.LastName;

                await userManager.UpdateAsync(user);

                return Ok(new
                {
                    UserId = user.Id,
                    user.Email,
                    user.BirthDate,
                    user.ImageUrl,
                    user.PhoneNumber,
                    user.FirstName,
                    user.LastName,

                });
            }

            [HttpGet]

            public string GetUser()
            {
                return "hello";
            }
        }
    }
    

