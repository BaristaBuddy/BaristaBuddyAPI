using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BaristaBuddyApi.Models.DTO
{
    public class OrderItemDTO
    {
        public int Id { get; set; }
        public ItemDTO Item { get; set; }
        public ItemDTO ImageUrl { get; set; }
        public ItemDTO Name { get; set; }
        public ItemDTO Price { get; set; }
        public int Quantity { get; set; }
        public string Size { get; set; }

        [Column(TypeName = "money")]
        public decimal AdditionalCost { get; set; }
    }
}
