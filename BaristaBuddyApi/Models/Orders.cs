using BaristaBuddyApi.Models.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaristaBuddyApi.Models
{
    public class Orders
    {
        public int Id { get; set; }
        public DateTime? PickupTime { get; set; }
        public DateTime? OrderTime { get; set; }
        public string PickupName { get; set; }
        public BaristaBuddyUser User{ get; set;}
        public List <OrderItem> OrderItem { get; set;}
    }
}
