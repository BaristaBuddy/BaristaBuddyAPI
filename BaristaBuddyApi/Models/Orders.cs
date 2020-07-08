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
        public int storeId { get; set;}
        public Store store { get; set; }
        public DateTime? PickupTime { get; set; }
        public DateTime? OrderTime { get; set; }
        public string PickupName { get; set; }
        public BaristaBuddyUser user{ get; set;}
        public List <OrderItem> OrderItem { get; set;}

    }
}
