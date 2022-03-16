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
using SpaceAgency.Intranet.TwoViews;

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
            var model = new TwoViewsAtOnce()
            {
                Pioneers = await _context.Pioneer.ToListAsync()
            };
            return View(model);
        }

        // GET: Pioneer/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id is null)
            {
                return PartialView();
            }
            var model = new TwoViewsAtOnce();
            var Pioneer = await _context.Pioneer.FindAsync(id);
            model.Pioneer = Pioneer;

            return PartialView(model);
        }

        // GET: Pioneer/Create
        public IActionResult Create()
        {
            return PartialView();
        }

        // POST: Pioneer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPioneer,Name,SurName,Status,CurrentPlanet")] Pioneer Pioneer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(Pioneer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(Pioneer);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null)
            {
                return PartialView();
            }
            var model = new TwoViewsAtOnce();
            var Pioneer = await _context.Pioneer.FindAsync(id);
            model.Pioneer = Pioneer;

            return PartialView(model);
        }

        // POST: Pioneer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPioneer,Name,SurName,Status,CurrentPlanet")] Pioneer Pioneer)
        {
            if (id != Pioneer.IdPioneer)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Pioneer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PioneerExists(Pioneer.IdPioneer))
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
            return View(Pioneer);
        }

        // GET: Pioneer/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null)
            {
                return PartialView();
            }
            var model = new TwoViewsAtOnce();
            var Pioneer = await _context.Pioneer.FindAsync(id);
            model.Pioneer = Pioneer;

            return PartialView(model);
        }

        // POST: Pioneer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Pioneer = await _context.Pioneer.FindAsync(id);
            _context.Pioneer.Remove(Pioneer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PioneerExists(int id)
        {
            return _context.Pioneer.Any(e => e.IdPioneer == id);
        }
    }
}
