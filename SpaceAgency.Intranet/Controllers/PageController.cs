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
    public class PageController : Controller
    {
        private readonly SpaceAgencyContext _context;

        public PageController(SpaceAgencyContext context)
        {
            _context = context;
        }

        // GET: page
        public async Task<IActionResult> Index()
        {
            var model = new TwoViewsAtOnce()
            {
                Pages = await _context.Page.ToListAsync()
            };
            return View(model);
        }

        /*// GET: page/Details/5                 ///"Mrówkowa" wersja Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var page = await _context.page
                .FirstOrDefaultAsync(m => m.Idpage == id);
            if (page == null)
            {
                return NotFound();
            }

            return View(page);
        }*/

        public async Task<IActionResult> Details(int? id)
        {
            if (id is null)
            {
                return PartialView();
            }
            var model = new TwoViewsAtOnce();
            var page = await _context.Page.FindAsync(id);
            model.Page = page;

            return PartialView(model);
        }

        // GET: page/Create
        public IActionResult Create()
        {
            return PartialView();
        }

        // POST: page/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPage,Title,Header,TopContent,BotContent")] Page page)
        {
            if (ModelState.IsValid)
            {
                _context.Add(page);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        /*// GET: page/Edit/5                 ///"Mrówkowa" wersja Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var page = await _context.page.FindAsync(id);
            if (page == null)
            {
                return NotFound();
            }
            return View(page);
        }*/

        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null)
            {
                return PartialView();
            }
            var model = new TwoViewsAtOnce();
            var page = await _context.Page.FindAsync(id);
            model.Page = page;

            return PartialView(model);
        }

        // POST: page/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPage,Title,Header,TopContent,BotContent")] Page page)
        {
            if (id != page.IdPage)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(page);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!pageExists(page.IdPage))
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

        // GET: page/Delete/5                 ///"Mrówkowa" wersja Delete
        /*public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var page = await _context.page
                .FirstOrDefaultAsync(m => m.Idpage == id);
            if (page == null)
            {
                return NotFound();
            }

            return View(page);
        }*/

        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null)
            {
                return PartialView();
            }
            var model = new TwoViewsAtOnce();
            var page = await _context.Page.FindAsync(id);
            model.Page = page;

            return PartialView(model);
        }

        // POST: page/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var page = await _context.Page.FindAsync(id);
            _context.Page.Remove(page);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool pageExists(int id)
        {
            return _context.Page.Any(e => e.IdPage == id);
        }
    }
}
