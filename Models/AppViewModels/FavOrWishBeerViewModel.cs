using System.Collections.Generic;
using BierTier.Models;

namespace BierTier.Models.AppViewModels
{
    public class FavOrWishBeerViewModel
    {
        public int BeerToSaveId { get; set; }
        public List<Beer> Beers { get; set; }

        public string BeerChoice { get; set; }

    }
}