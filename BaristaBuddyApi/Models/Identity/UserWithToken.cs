using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaristaBuddyApi.Models.Identity
{
    public class UserWithToken
    {
        public string UserId { get; set; }
        public String Token { get; set; }
    }
}
