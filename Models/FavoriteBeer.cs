using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BierTier.Models
{
    public class FavoriteBeer
    {
        [Key]
        public int BeerId { get; set; }
        public bool IsFavorited { get; set; }
    }
}