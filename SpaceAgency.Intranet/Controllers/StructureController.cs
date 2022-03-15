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
            return View(await _context.Structure.ToListAsync());
        }

        // GET: Structure/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var structure = await _context.Structure
                .FirstOrDefaultAsync(m => m.IdStructure == id);
            if (structure == null)
            {
                return NotFound();
            }

            return View(structure);
        }

        // GET: Structure/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Structure/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdStructure,Name,Type,Planet,Latitude,Longitude,Status")] Structure structure)
        {
            if (ModelState.IsValid)
            {
                _context.Add(structure);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(structure);
        }

        // GET: Structure/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var structure = await _context.Structure.FindAsync(id);
            if (structure == null)
            {
                return NotFound();
            }
            return View(structure);
        }

        // POST: Structure/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdStructure,Name,Type,Planet,Latitude,Longitude,Status")] Structure structure)
        {
            if (id != structure.IdStructure)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(structure);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StructureExists(structure.IdStructure))
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
            return View(structure);
        }

        // GET: Structure/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var structure = await _context.Structure
                .FirstOrDefaultAsync(m => m.IdStructure == id);
            if (structure == null)
            {
                return NotFound();
            }

            return View(structure);
        }

        // POST: Structure/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var structure = await _context.Structure.FindAsync(id);
            _context.Structure.Remove(structure);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StructureExists(int id)
        {
            return _context.Structure.Any(e => e.IdStructure == id);
        }
    }
}
