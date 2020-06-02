using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BaristaBuddyApi.Models
{
    public class StoreModifier
    {
        public int ModifierId { get; set; }

        public int StoreId { get; set; }

        public List<Store> Stores { get; set; }

        public List<Item> Items { get; set; }
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
