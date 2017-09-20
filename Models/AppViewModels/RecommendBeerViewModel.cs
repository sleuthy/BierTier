using System.Collections.Generic;
using BierTier.Models;

namespace BierTier.Models.AppViewModels

{
    public class RecommendBeerViewModel
    {
        public int BeerToRecommendId { get; set; }
        public List<Beer> Beers { get; set; }
        public string BeerRecommend { get; set; }
    }
}