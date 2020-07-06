using BaristaBuddyApi.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaristaBuddyApi.Services
{
        public class UserManagerWrapper : IUserManager
        {
            private readonly UserManager<BaristaBuddyUser> userManager;
            private readonly IConfiguration configuration;

            public UserManagerWrapper(UserManager<BaristaBuddyUser> userManager, IConfiguration configuration)
            {
                this.userManager = userManager;
                this.configuration = configuration;
            }

            public Task AccessFailedAsync(BaristaBuddyUser user)
            {
                return userManager.AccessFailedAsync(user);
            }

            public Task<bool> CheckPasswordAsync(BaristaBuddyUser user, string password)
            {
                return userManager.CheckPasswordAsync(user, password);
            }

            public Task<IdentityResult> CreateAsync(BaristaBuddyUser user, string password)
            {
                return userManager.CreateAsync(user, password);
            }

            public Task<BaristaBuddyUser> FindByIdAsync(string userId)
            {
                return userManager.FindByIdAsync(userId);
            }

            public Task<BaristaBuddyUser> FindByNameAsync(string username)
            {
                return userManager.FindByNameAsync(username);
            }

            public Task<IdentityResult> UpdateAsync(BaristaBuddyUser user)
            {
                return userManager.UpdateAsync(user);
            }

            public string CreateToken(BaristaBuddyUser user)
            {
                var secret = configuration["JWT:Secret"];
                var secretBytes = Encoding.UTF8.GetBytes(secret);
                var signingKey = new SymmetricSecurityKey(secretBytes);

                var tokenClaims = new[]
                {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim("UserId", user.Id),
                new Claim("FullName", $"{user.FirstName} {user.LastName}"),
            };

                var token = new JwtSecurityToken(
                    expires: DateTime.UtcNow.AddSeconds(10),
                    claims: tokenClaims,
                    signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
                    );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

                return tokenString;
            }
        }

        public interface IUserManager
        {
            Task<BlogUser> FindByNameAsync(string username);
            Task<bool> CheckPasswordAsync(BlogUser user, string password);
            Task AccessFailedAsync(BlogUser user);
            Task<IdentityResult> CreateAsync(BlogUser user, string password);
            Task<BlogUser> FindByIdAsync(string userId);
            Task<IdentityResult> UpdateAsync(BlogUser user);
            string CreateToken(BlogUser user);
        }
    }
}
