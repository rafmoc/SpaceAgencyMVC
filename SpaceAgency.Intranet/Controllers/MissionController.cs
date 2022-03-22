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
    public class MissionController : Controller
    {
        private readonly SpaceAgencyContext _context;

        public MissionController(SpaceAgencyContext context)
        {
            _context = context;
        }

        // GET: Mission
        public async Task<IActionResult> Index()
        {
            var model = new TwoViewsAtOnce()
            {
                Missions = await _context.Mission.ToListAsync()
            };
            return View(model);
        }

        /*// GET: Mission/Details/5                 ///"Mrówkowa" wersja Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mission = await _context.Mission
                .FirstOrDefaultAsync(m => m.IdMission == id);
            if (mission == null)
            {
                return NotFound();
            }

            return View(mission);
        }*/

        public async Task<IActionResult> Details(int? id)
        {
            if (id is null)
            {
                return PartialView();
            }
            var model = new TwoViewsAtOnce();
            var mission = await _context.Mission.FindAsync(id);
            model.Mission = mission;

            return PartialView(model);
        }

        // GET: Mission/Create
        public IActionResult Create()
        {
            return PartialView();
        }

        // POST: Mission/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMission,Name,Destination,Type,Status")] Mission mission)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mission);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        /*// GET: Mission/Edit/5                 ///"Mrówkowa" wersja Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mission = await _context.Mission.FindAsync(id);
            if (mission == null)
            {
                return NotFound();
            }
            return View(mission);
        }*/

        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null)
            {
                return PartialView();
            }
            var model = new TwoViewsAtOnce();
            var mission = await _context.Mission.FindAsync(id);
            model.Mission = mission;

            return PartialView(model);
        }

        // POST: Mission/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMission,Name,Destination,Type,Status")] Mission mission)
        {
            if (id != mission.IdMission)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mission);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MissionExists(mission.IdMission))
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
            return RedirectToAction(nameof(Index));
        }

        // GET: Mission/Delete/5                 ///"Mrówkowa" wersja Delete
        /*public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mission = await _context.Mission
                .FirstOrDefaultAsync(m => m.IdMission == id);
            if (mission == null)
            {
                return NotFound();
            }

            return View(mission);
        }*/

        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null)
            {
                return PartialView();
            }
            var model = new TwoViewsAtOnce();
            var mission = await _context.Mission.FindAsync(id);
            model.Mission = mission;

            return PartialView(model);
        }

        // POST: Mission/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mission = await _context.Mission.FindAsync(id);
            _context.Mission.Remove(mission);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MissionExists(int id)
        {
            return _context.Mission.Any(e => e.IdMission == id);
        }
    }
}
