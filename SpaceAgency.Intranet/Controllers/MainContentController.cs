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
    public class MainContentController : Controller
    {
        private readonly SpaceAgencyContext _context;

        public MainContentController(SpaceAgencyContext context)
        {
            _context = context;
        }

        // GET: Structure
        public async Task<IActionResult> Index()
        {
            var model = new TwoViewsAtOnce()
            {
                MainContents = await _context.MainContent.ToListAsync()
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
            var MainContent = await _context.MainContent.FindAsync(id);
            model.MainContent = MainContent;

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
        public async Task<IActionResult> Create([Bind("IdMainContent,Icon,Header,Content")] MainContent mainContent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mainContent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null)
            {
                return PartialView();
            }
            var model = new TwoViewsAtOnce();
            var MainContent = await _context.MainContent.FindAsync(id);
            model.MainContent = MainContent;

            return PartialView(model);
        }

        // POST: Structure/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMainContent,Icon,Header,Content")] MainContent mainContent)
        {
            if (id != mainContent.IdMainContent)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mainContent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MainContentExists(mainContent.IdMainContent))
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

        // GET: Structure/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null)
            {
                return PartialView();
            }
            var model = new TwoViewsAtOnce();
            var MainContent = await _context.MainContent.FindAsync(id);
            model.MainContent = MainContent;

            return PartialView(model);
        }

        // POST: Structure/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var MainContent = await _context.MainContent.FindAsync(id);
            _context.MainContent.Remove(MainContent);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MainContentExists(int id)
        {
            return _context.MainContent.Any(e => e.IdMainContent == id);
        }
    }
}
