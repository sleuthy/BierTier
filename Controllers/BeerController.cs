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
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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
            }
            return RedirectToAction ("FavoriteBeer");
        }

         public async Task<IActionResult> FavoriteBeer()
        {
            var beers = await _context.FavoriteBeer.Include("IndivBeer").ToListAsync();
            return View (beers);
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
                    viewModel.Beers = viewModel.Beers.Where(b => b.Name.Contains(searchString)
                                        || b.Brewery.Contains(searchString)
                                        || b.Type.Contains(searchString)).ToList();
                }

            return View(viewModel);
        }
    }
}
