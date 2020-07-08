using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaristaBuddyApi.Models.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public DateTime? PickupTime { get; set; }
        public DateTime? OrderTime { get; set; }
        public List<OrderItemDTO> OrderItem { get; set; }
    }
}
