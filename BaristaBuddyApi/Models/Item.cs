using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaristaBuddyApi.Models
{
    public class Item
    {
        public int ItemId { get; set; }

        // FK to parent Store
        public int StoreId { get; set; }
        public Store Store { get; set; }

        [Required]
        public string Name { get; set; }

        public string Ingredients { get; set; }

        public string ImageUrl { get; set; }

        
        [Column (TypeName = "money")]
        public decimal Price { get; set; }

        // Inverse navigation property
        public List<ItemModifier> ItemModifiers { get; set; }
    }
}
