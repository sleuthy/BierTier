using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BierTier.Models
{
    public class WishlistBeer
    {
        [Key]
        public int WishListBeerId { get; set; }
        public int BeerId { get; set; }
        public ApplicationUser User { get; set; }
        public Beer IndivBeer { get; set; }
    }
}