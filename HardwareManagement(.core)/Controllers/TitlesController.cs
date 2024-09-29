using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HardwareManagement_.core_.Models.Entity;
using System.Data;

namespace HardwareManagement_.core_.Controllers
{
    public class TitlesController : Controller
    {
        private readonly HardwaremanagementContext _context;

        public TitlesController(HardwaremanagementContext context)
        {
            _context = context;
        }

        // GET: TblTitles
        public async Task<IActionResult> Index()
        {
              return _context.TblTitles != null ? 
                          View(await _context.TblTitles.ToListAsync()) :
                          Problem("Entity set 'HardwaremanagementContext.TblTitles'  is null.");
        }

        // GET: TblTitles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TblTitles == null)
            {
                return NotFound();
            }

            var tblTitle = await _context.TblTitles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblTitle == null)
            {
                return NotFound();
            }

            return View(tblTitle);
        }

        // GET: TblTitles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblTitles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title")] TblTitle tblTitle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblTitle);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index","Titles");
            }
            return View(Index);
        }

        // GET: TblTitles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TblTitles == null)
            {
                return NotFound();
            }

            var tblTitle = await _context.TblTitles.FindAsync(id);
            if (tblTitle == null)
            {
                return NotFound();
            }
            return View(tblTitle);
        }

        // POST: TblTitles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title")] TblTitle tblTitle)
        {
            if (id != tblTitle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblTitle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblTitleExists(tblTitle.Id))
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
            return View(tblTitle);
        }

        // GET: TblTitles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TblTitles == null)
            {
                return NotFound();
            }

            var tblTitle = await _context.TblTitles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblTitle == null)
            {
                return NotFound();
            }

            return View(tblTitle);
        }

        // POST: TblTitles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TblTitles == null)
            {
                return Problem("Entity set 'HardwaremanagementContext.TblTitles'  is null.");
            }
            var tblTitle = await _context.TblTitles.FindAsync(id);
            if (tblTitle != null)
            {
                _context.TblTitles.Remove(tblTitle);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblTitleExists(int id)
        {
          return (_context.TblTitles?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
