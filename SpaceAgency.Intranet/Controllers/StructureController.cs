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
    public class StructureController : Controller
    {
        private readonly SpaceAgencyContext _context;

        public StructureController(SpaceAgencyContext context)
        {
            _context = context;
        }

        // GET: Structure
        public async Task<IActionResult> Index()
        {
            var model = new TwoViewsAtOnce()
            {
                Structures = await _context.Structure.ToListAsync()
            };
            return View(model);
        }

        // GET: Structure/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id is null)
            {
                return PartialView();
            }
            var model = new TwoViewsAtOnce();
            var Structure = await _context.Structure.FindAsync(id);
            model.Structure = Structure;

            return PartialView(model);
        }

        // GET: Structure/Create
        public IActionResult Create()
        {
            return PartialView();
        }

        // POST: Structure/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdStructure,Name,Type,Planet,Latitude,Longitude,Status")] Structure Structure)
        {
            if (ModelState.IsValid)
            {
                _context.Add(Structure);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(Structure);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null)
            {
                return PartialView();
            }
            var model = new TwoViewsAtOnce();
            var Structure = await _context.Structure.FindAsync(id);
            model.Structure = Structure;

            return PartialView(model);
        }

        // POST: Structure/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdStructure,Name,Destination,Type,Status")] Structure Structure)
        {
            if (id != Structure.IdStructure)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Structure);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StructureExists(Structure.IdStructure))
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
            return View(Structure);
        }

        // GET: Structure/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null)
            {
                return PartialView();
            }
            var model = new TwoViewsAtOnce();
            var Structure = await _context.Structure.FindAsync(id);
            model.Structure = Structure;

            return PartialView(model);
        }

        // POST: Structure/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Structure = await _context.Structure.FindAsync(id);
            _context.Structure.Remove(Structure);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StructureExists(int id)
        {
            return _context.Structure.Any(e => e.IdStructure == id);
        }
    }
}
