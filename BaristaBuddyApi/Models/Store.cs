using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BaristaBuddyApi.Models
{
    public class Store
    {

        public int Id { get; set; }
        [Required]
       public string Name { get; set; }

        [Required]
        public string StreetAddress { get; set; }

        [Required]

        public string City { get; set; }

        [Required]
        public string State { get; set; }
        [Required]

        public string Zip { get; set; }
        
        public string Phone { get; set; }

        public string WebsiteUrl { get; set; }

        public string StoreImageUrl { get; set; }

       
    }
}
