using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BaristaBuddyApi.Models.DTO
{
    public class StoreModifierDTO
    {
        public int ModifierId { get; set; }

        public int StoreId { get; set; }
        public Store Store { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

    }
}
