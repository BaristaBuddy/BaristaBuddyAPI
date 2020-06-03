using BaristaBuddyApi.Models;
using BaristaBuddyApi.Models.DTO;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BaristaBuddyApi.Models.DTO
{
    public class StoreDTO
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

        public List<ItemDTO> Items { get; set;}
        public List<StoreModifierDTO> Modifiers { get; set; }
    }
}