using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaristaBuddyApi.Models.DTO
{
    public class ItemModifierDTO
    {
        // PK, FK to Item
        //public int ItemId { get; set; }
       // public Item Item { get; set; }

        // PK, FK to StoreModifier
        //public int ModifierId { get; set; }
        public string Modifier { get; set; }
        //public string Name { get; set; }

        [Column(TypeName = "money")]
        public decimal AdditionalCost { get; set; }
    }
}
