﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BierTier.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        
        public virtual ICollection<BlacklistBeer> BlacklistBeers { get; set; }
        public virtual ICollection<FavoriteBeer> FavoriteBeers { get; set; }
        public virtual ICollection<WishlistBeer> WishlistBeers { get; set; }
    }
}
