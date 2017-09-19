using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BierTier.Data;
using BierTier.Models;
using Microsoft.AspNetCore.Identity;

namespace BierTier.Controllers
{
    public class FavoriteBeerController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public FavoriteBeerController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;    
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
        
        // GET: FavoriteBeer
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.FavoriteBeer.Include(f => f.IndivBeer);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: FavoriteBeer/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var favoriteBeer = await _context.FavoriteBeer
                .Include(f => f.IndivBeer)
                .SingleOrDefaultAsync(m => m.FavoriteBeerId == id);
            if (favoriteBeer == null)
            {
                return NotFound();
            }

            return View(favoriteBeer);
        }

        // GET: FavoriteBeer/Create
        public IActionResult Create()
        {
            ViewData["BeerId"] = new SelectList(_context.Beer, "BeerId", "BeerId");
            return View();
        }

        // POST: FavoriteBeer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FavoriteBeerId,BeerId")] FavoriteBeer favoriteBeer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(favoriteBeer);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["BeerId"] = new SelectList(_context.Beer, "BeerId", "BeerId", favoriteBeer.BeerId);
            return View(favoriteBeer);
        }

        // GET: FavoriteBeer/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var favoriteBeer = await _context.FavoriteBeer.SingleOrDefaultAsync(m => m.FavoriteBeerId == id);
            if (favoriteBeer == null)
            {
                return NotFound();
            }
            ViewData["BeerId"] = new SelectList(_context.Beer, "BeerId", "BeerId", favoriteBeer.BeerId);
            return View(favoriteBeer);
        }

        // POST: FavoriteBeer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FavoriteBeerId,BeerId")] FavoriteBeer favoriteBeer)
        {
            if (id != favoriteBeer.FavoriteBeerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(favoriteBeer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FavoriteBeerExists(favoriteBeer.FavoriteBeerId))
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
            ViewData["BeerId"] = new SelectList(_context.Beer, "BeerId", "BeerId", favoriteBeer.BeerId);
            return View(favoriteBeer);
        }

        // GET: FavoriteBeer/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var favoriteBeer = await _context.FavoriteBeer
                .Include(f => f.IndivBeer)
                .SingleOrDefaultAsync(m => m.FavoriteBeerId == id);
            if (favoriteBeer == null)
            {
                return NotFound();
            }

            return View(favoriteBeer);
        }

        // POST: FavoriteBeer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var favoriteBeer = await _context.FavoriteBeer.SingleOrDefaultAsync(m => m.FavoriteBeerId == id);
            _context.FavoriteBeer.Remove(favoriteBeer);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool FavoriteBeerExists(int id)
        {
            return _context.FavoriteBeer.Any(e => e.FavoriteBeerId == id);
        }
    }
}
