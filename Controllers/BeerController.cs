using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BierTier.Data;
using BierTier.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IO;
using System.Reflection;
using System.Xml.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using BierTier.Models.AppViewModels;

namespace BierTier.Controllers
{
    public class BeerController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public BeerController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;    
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
        
        // GET: Beer
        public async Task<IActionResult> Index()
        {
            return View(await _context.Beer.ToListAsync());
        }

        // GET: Beer/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beer = await _context.Beer
                .SingleOrDefaultAsync(m => m.BeerId == id);
            if (beer == null)
            {
                return NotFound();
            }

            return View(beer);
        }


        // GET: Beer/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Beer/Create
        // Add beer to Favorites or Wishlist

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveBeer(FavOrWishBeerViewModel viewModel)
        {
            var id = await GetCurrentUserAsync();

            if (viewModel.BeerChoice == "Add to Favorites")
            {
                FavoriteBeer beerToAdd = new FavoriteBeer(){
                    BeerId = viewModel.BeerToSaveId,
                    User = id
                };
                    _context.Add(beerToAdd);
                    await _context.SaveChangesAsync();

            return RedirectToAction ("FavoriteBeer");
            
            }
        
            else if (viewModel.BeerChoice == "Add to Wishlist")
            {
                WishlistBeer beerToAdd = new WishlistBeer(){
                    BeerId = viewModel.BeerToSaveId,
                    User = id
                };
                    _context.Add(beerToAdd);
                    await _context.SaveChangesAsync();

            return RedirectToAction ("WishlistBeer");
            }
            return View ("Index");
        }

         public async Task<IActionResult> FavoriteBeer()
        {
            var beers = await _context.FavoriteBeer.Include("IndivBeer").ToListAsync();
            return View (beers);
        }

        public async Task<IActionResult> WishlistBeer()
        {
            var wishbeers = await _context.WishlistBeer.Include("IndivBeer").ToListAsync();
            return View (wishbeers);
        }

        // GET: Beer/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beer = await _context.Beer.SingleOrDefaultAsync(m => m.BeerId == id);
            if (beer == null)
            {
                return NotFound();
            }
            return View(beer);
        }

        // POST: Beer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BeerId,Name,Brewery,Description,Type,ABV,IBU,Image")] Beer beer)
        {
            if (id != beer.BeerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(beer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BeerExists(beer.BeerId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(beer);
        }

        // GET: Beer/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beer = await _context.Beer
                .SingleOrDefaultAsync(m => m.BeerId == id);
            if (beer == null)
            {
                return NotFound();
            }

            return View(beer);
        }

        // POST: Beer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var beer = await _context.Beer.SingleOrDefaultAsync(m => m.BeerId == id);
            _context.Beer.Remove(beer);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // POST: Beer/DeleteFavorite/5
        [HttpPost, ActionName("DeleteFavorite")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteFavoriteConfirmed(int id)
        {
            var beer = await _context.FavoriteBeer.SingleOrDefaultAsync(m => m.FavoriteBeerId == id);
            _context.FavoriteBeer.Remove(beer);
            await _context.SaveChangesAsync();
            return RedirectToAction("FavoriteBeer");
        }

        // POST: Beer/DeleteWishlist/5
        [HttpPost, ActionName("DeleteWishlist")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteWishlistConfirmed(int id)
        {
            var beer = await _context.WishlistBeer.SingleOrDefaultAsync(m => m.WishListBeerId == id);
            _context.WishlistBeer.Remove(beer);
            await _context.SaveChangesAsync();
            return RedirectToAction("WishlistBeer");
        }

        private bool BeerExists(int id)
        {
            return _context.Beer.Any(e => e.BeerId == id);
        }

        // Beer Search Functionality
        [ActionName("Search")]
        public async Task<IActionResult> SearchIndex(string searchString)
        {
            FavOrWishBeerViewModel viewModel = new FavOrWishBeerViewModel();

            viewModel.Beers = (from b in _context.Beer
                           select b).ToList();

            var id = await GetCurrentUserAsync();

    
            if (!String.IsNullOrEmpty(searchString))
                {
                    viewModel.Beers = viewModel.Beers.Where(b => b.Name.ToLower().Contains(searchString.ToLower())
                                        || b.Brewery.ToLower().Contains(searchString.ToLower())
                                        || b.Type.ToLower().Contains(searchString.ToLower())).ToList();
                }

            return View(viewModel);
        }

        // Beer Recommendations Functionality

        [ActionName("RecommendBeer")]
        public async Task<IActionResult> RecommendBeer(string recommendString)
        {
            RecommendBeerViewModel viewModel = new RecommendBeerViewModel();
            
            var id = await GetCurrentUserAsync();

            viewModel.Beers = _context.Beer.Where(b => b.Type.Contains(recommendString)).ToList();

            return View(viewModel);
        }
    }
}
