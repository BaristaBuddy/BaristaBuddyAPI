using BaristaBuddyApi.Models.DTO;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaristaBuddyApi.Models.Identity
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }

        public int ItemId { get; set; }
        public Orders Order { get; set; }
        public Item Item { get; set; }
        public int Quantity { get; set; }
        public string Size { get; set; }

       [Column(TypeName = "money")]
       public decimal AdditionalCost { get; set; }

    }
}
