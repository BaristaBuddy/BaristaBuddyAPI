using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BaristaBuddyApi.Models
{
    public class Item
    {
        public int ItemId { get; set; }

        public int StoreId { get; set; }

        public List<Store> Stores { get; set; }
        [Required]
        public string Name { get; set; }

        public string Ingredients { get; set; }

        public string ImageUrl { get; set; }

        public double Price { get; set; }

    }
}
