using System.ComponentModel.DataAnnotations;

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

        public double Price { get; set; }

    }
}
