using System.ComponentModel.DataAnnotations;

namespace BierTier.Models
{
    public class Beer
    {
        [Key]
        public int BeerId { get; set; }

        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Brewery { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public int ABV { get; set; }

        [Required]
        public int IBU { get; set; }
    }
}