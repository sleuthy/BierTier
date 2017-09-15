using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BierTier.Models
{
    public class Beer
    {
        [Key]
        public int BeerId { get; set; }

        public string Name { get; set; }
        
        public string Brewery { get; set; }

        public string Description { get; set; }

        public string Type { get; set; }

        public double ABV { get; set; }

        public int IBU { get; set; }

        public string Image { get; set; }

        public virtual ICollection<BlacklistBeer> BlacklistBeers { get; set; }
        public virtual ICollection<FavoriteBeer> FavoriteBeers { get; set; }
        public virtual ICollection<WishlistBeer> WishlistBeers { get; set; }

    }
}