using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BaristaBuddyApi.Models
{
    public class StoreModifier
    {
        public int ModifierId { get; set; }

        public int StoreId { get; set; }
        public Store Store { get; set; }

        // List of ItemModifier that refer back to this StoreModifier
       

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
