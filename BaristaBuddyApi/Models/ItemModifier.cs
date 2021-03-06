﻿using System.ComponentModel.DataAnnotations.Schema;

namespace BaristaBuddyApi.Models
{
    public class ItemModifier
    {
        // PK, FK to Item
        public int ItemId { get; set; }
        public Item Item { get; set; }

        // PK, FK to StoreModifier
        public int ModifierId { get; set; }
        public StoreModifier Modifier { get; set; }

        [Column(TypeName = "money")]
        public decimal AdditionalCost { get; set; }
    }
}
