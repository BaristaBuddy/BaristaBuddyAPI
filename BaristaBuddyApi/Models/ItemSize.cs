using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BaristaBuddyApi.Models
{
    public class ItemSize
    {
        public int ItemId { get; set; }
        public Item Item { get; set; }

        public string Size { get; set; }


        [Column(TypeName = "money")]
        public decimal AdditionalCost { get; set; }
    }
}
