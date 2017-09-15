using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BierTier.Data;
using BierTier.Models;

namespace BierTier.Controllers
{
    public class BeerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BeerController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Beer
        public async Task<IActionResult> Index()
        {
            return View(await _context.Beers.ToListAsync());
        }

        // GET: Beer/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beer = await _context.Beers
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
        public async Task<IActionResult> Create([Bind("BeerId,Name,Brewery,Description,Type,ABV,IBU,Image")] Beer beer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(beer);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(beer);
        }

        // GET: Beer/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beer = await _context.Beers.SingleOrDefaultAsync(m => m.BeerId == id);
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

            var beer = await _context.Beers
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
            var beer = await _context.Beers.SingleOrDefaultAsync(m => m.BeerId == id);
            _context.Beers.Remove(beer);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool BeerExists(int id)
        {
            return _context.Beers.Any(e => e.BeerId == id);
        }
    }
}
