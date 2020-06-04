using BaristaBuddyApi.Models;
using BaristaBuddyApi.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaristaBuddyApi.Repositories
{
    public class CreateItem
    {
        public int ItemId { get; set; }
        public int StoreId { get; set; }
       
        public string Name { get; set; }

        public string Ingredients { get; set; }

        public string ImageUrl { get; set; }

        public decimal Price { get; set; }

        public List<ItemModifier> ItemModifiers { get; set; }
    }
}
