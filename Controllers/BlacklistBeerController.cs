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
    public class BlacklistBeerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BlacklistBeerController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: BlacklistBeer
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.BlacklistBeer.Include(b => b.IndivBeer);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: BlacklistBeer/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blacklistBeer = await _context.BlacklistBeer
                .Include(b => b.IndivBeer)
                .SingleOrDefaultAsync(m => m.BlackListBeerId == id);
            if (blacklistBeer == null)
            {
                return NotFound();
            }

            return View(blacklistBeer);
        }

        // GET: BlacklistBeer/Create
        public IActionResult Create()
        {
            ViewData["BeerId"] = new SelectList(_context.Beer, "BeerId", "BeerId");
            return View();
        }

        // POST: BlacklistBeer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BlackListBeerId,BeerId")] BlacklistBeer blacklistBeer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(blacklistBeer);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["BeerId"] = new SelectList(_context.Beer, "BeerId", "BeerId", blacklistBeer.BeerId);
            return View(blacklistBeer);
        }

        // GET: BlacklistBeer/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blacklistBeer = await _context.BlacklistBeer.SingleOrDefaultAsync(m => m.BlackListBeerId == id);
            if (blacklistBeer == null)
            {
                return NotFound();
            }
            ViewData["BeerId"] = new SelectList(_context.Beer, "BeerId", "BeerId", blacklistBeer.BeerId);
            return View(blacklistBeer);
        }

        // POST: BlacklistBeer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BlackListBeerId,BeerId")] BlacklistBeer blacklistBeer)
        {
            if (id != blacklistBeer.BlackListBeerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(blacklistBeer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BlacklistBeerExists(blacklistBeer.BlackListBeerId))
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
            ViewData["BeerId"] = new SelectList(_context.Beer, "BeerId", "BeerId", blacklistBeer.BeerId);
            return View(blacklistBeer);
        }

        // GET: BlacklistBeer/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blacklistBeer = await _context.BlacklistBeer
                .Include(b => b.IndivBeer)
                .SingleOrDefaultAsync(m => m.BlackListBeerId == id);
            if (blacklistBeer == null)
            {
                return NotFound();
            }

            return View(blacklistBeer);
        }

        // POST: BlacklistBeer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var blacklistBeer = await _context.BlacklistBeer.SingleOrDefaultAsync(m => m.BlackListBeerId == id);
            _context.BlacklistBeer.Remove(blacklistBeer);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool BlacklistBeerExists(int id)
        {
            return _context.BlacklistBeer.Any(e => e.BlackListBeerId == id);
        }
    }
}
