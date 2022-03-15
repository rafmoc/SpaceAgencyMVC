#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SpaceAgency.Data.Data;
using SpaceAgency.Data.Data.CMS;

namespace SpaceAgency.Intranet.Controllers
{
    public class PioneerController : Controller
    {
        private readonly SpaceAgencyContext _context;

        public PioneerController(SpaceAgencyContext context)
        {
            _context = context;
        }

        // GET: Pioneer
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pioneer.ToListAsync());
        }

        // GET: Pioneer/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pioneer = await _context.Pioneer
                .FirstOrDefaultAsync(m => m.IdPioneer == id);
            if (pioneer == null)
            {
                return NotFound();
            }

            return View(pioneer);
        }

        // GET: Pioneer/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pioneer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPioneer,Name,SurName,Status,CurrentPlanet")] Pioneer pioneer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pioneer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pioneer);
        }

        // GET: Pioneer/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pioneer = await _context.Pioneer.FindAsync(id);
            if (pioneer == null)
            {
                return NotFound();
            }
            return View(pioneer);
        }

        // POST: Pioneer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPioneer,Name,SurName,Status,CurrentPlanet")] Pioneer pioneer)
        {
            if (id != pioneer.IdPioneer)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pioneer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PioneerExists(pioneer.IdPioneer))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pioneer);
        }

        // GET: Pioneer/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pioneer = await _context.Pioneer
                .FirstOrDefaultAsync(m => m.IdPioneer == id);
            if (pioneer == null)
            {
                return NotFound();
            }

            return View(pioneer);
        }

        // POST: Pioneer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pioneer = await _context.Pioneer.FindAsync(id);
            _context.Pioneer.Remove(pioneer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PioneerExists(int id)
        {
            return _context.Pioneer.Any(e => e.IdPioneer == id);
        }
    }
}
