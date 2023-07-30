﻿using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventTicketBookingSystemData.Model
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
         public string? CustomerName { get; set; }
         [Required]
        public string? CustomerEmail { get; set; }
        
        public string? Password { get; set; }
      
        public string? Role { get; set; }
    }
}
