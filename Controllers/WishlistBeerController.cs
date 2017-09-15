using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BierTier.Data;
using BierTier.Models;

namespace biertier.Controllers
{
    public class WishlistBeerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WishlistBeerController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: WishlistBeer
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.WishlistBeer.Include(w => w.IndivBeer);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: WishlistBeer/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wishlistBeer = await _context.WishlistBeer
                .Include(w => w.IndivBeer)
                .SingleOrDefaultAsync(m => m.WishListBeerId == id);
            if (wishlistBeer == null)
            {
                return NotFound();
            }

            return View(wishlistBeer);
        }

        // GET: WishlistBeer/Create
        public IActionResult Create()
        {
            ViewData["BeerId"] = new SelectList(_context.Beer, "BeerId", "BeerId");
            return View();
        }

        // POST: WishlistBeer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WishListBeerId,BeerId")] WishlistBeer wishlistBeer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(wishlistBeer);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["BeerId"] = new SelectList(_context.Beer, "BeerId", "BeerId", wishlistBeer.BeerId);
            return View(wishlistBeer);
        }

        // GET: WishlistBeer/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wishlistBeer = await _context.WishlistBeer.SingleOrDefaultAsync(m => m.WishListBeerId == id);
            if (wishlistBeer == null)
            {
                return NotFound();
            }
            ViewData["BeerId"] = new SelectList(_context.Beer, "BeerId", "BeerId", wishlistBeer.BeerId);
            return View(wishlistBeer);
        }

        // POST: WishlistBeer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WishListBeerId,BeerId")] WishlistBeer wishlistBeer)
        {
            if (id != wishlistBeer.WishListBeerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wishlistBeer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WishlistBeerExists(wishlistBeer.WishListBeerId))
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
            ViewData["BeerId"] = new SelectList(_context.Beer, "BeerId", "BeerId", wishlistBeer.BeerId);
            return View(wishlistBeer);
        }

        // GET: WishlistBeer/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wishlistBeer = await _context.WishlistBeer
                .Include(w => w.IndivBeer)
                .SingleOrDefaultAsync(m => m.WishListBeerId == id);
            if (wishlistBeer == null)
            {
                return NotFound();
            }

            return View(wishlistBeer);
        }

        // POST: WishlistBeer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var wishlistBeer = await _context.WishlistBeer.SingleOrDefaultAsync(m => m.WishListBeerId == id);
            _context.WishlistBeer.Remove(wishlistBeer);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool WishlistBeerExists(int id)
        {
            return _context.WishlistBeer.Any(e => e.WishListBeerId == id);
        }
    }
}
