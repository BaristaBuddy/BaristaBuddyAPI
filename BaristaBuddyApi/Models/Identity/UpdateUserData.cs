using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BaristaBuddyApi.Models.Identity
{
    public class UpdateUserData
    {
        [Required]

        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string ImageUrl { get; set; }

    }
}
