using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HardwareManagement_.core_.Models.Entity;

namespace HardwareManagement_.core_.Controllers
{
    public class StatusController : Controller
    {
        private readonly HardwaremanagementContext _context;

        public StatusController(HardwaremanagementContext context)
        {
            _context = context;
        }

        // GET: TblStatus
        public async Task<IActionResult> Index()
        {
              return _context.TblStatuses != null ? 
                          View(await _context.TblStatuses.ToListAsync()) :
                          Problem("Entity set 'HardwaremanagementContext.TblStatuses'  is null.");
        }

        // GET: TblStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TblStatuses == null)
            {
                return NotFound();
            }

            var tblStatus = await _context.TblStatuses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblStatus == null)
            {
                return NotFound();
            }

            return View(tblStatus);
        }

        // GET: TblStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Status")] TblStatus tblStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblStatus);
        }

        // GET: TblStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TblStatuses == null)
            {
                return NotFound();
            }

            var tblStatus = await _context.TblStatuses.FindAsync(id);
            if (tblStatus == null)
            {
                return NotFound();
            }
            return View(tblStatus);
        }

        // POST: TblStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Status")] TblStatus tblStatus)
        {
            if (id != tblStatus.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblStatusExists(tblStatus.Id))
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
            return View(tblStatus);
        }

        // GET: TblStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TblStatuses == null)
            {
                return NotFound();
            }

            var tblStatus = await _context.TblStatuses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblStatus == null)
            {
                return NotFound();
            }

            return View(tblStatus);
        }

        // POST: TblStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TblStatuses == null)
            {
                return Problem("Entity set 'HardwaremanagementContext.TblStatuses'  is null.");
            }
            var tblStatus = await _context.TblStatuses.FindAsync(id);
            if (tblStatus != null)
            {
                _context.TblStatuses.Remove(tblStatus);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblStatusExists(int id)
        {
          return (_context.TblStatuses?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
