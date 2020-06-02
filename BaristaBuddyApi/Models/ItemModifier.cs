using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaristaBuddyApi.Models
{
    public class ItemModifier
    {
        public int ItemId { get; set; }

        public int ModifierId { get; set; }

        public List<StoreModifier> StoreModifiers { get; set; }

        public List<Item> Items { get; set; }

        public double AdditionalCost { get; set; }
    }
}
