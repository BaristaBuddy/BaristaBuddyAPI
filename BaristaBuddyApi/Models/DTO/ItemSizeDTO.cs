using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BaristaBuddyApi.Models.DTO
{
    public class ItemSizeDTO
    {
        public string Size { get; set; }


        [Column(TypeName = "money")]
        public decimal AdditionalCost { get; set; }
    }
}
