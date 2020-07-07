﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BaristaBuddyApi.Models.Identity
{
    public class Register
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        public string LastName { get; set; }

        public DateTime? BirthDate { get; set; }
        public string ImageUrl { get; set; }
    }
}
