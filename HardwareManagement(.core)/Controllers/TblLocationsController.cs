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
    public class TblLocationsController : Controller
    {
        private readonly HardwaremanagementContext _context;

        public TblLocationsController(HardwaremanagementContext context)
        {
            _context = context;
        }

        // GET: TblLocations
        public async Task<IActionResult> Index()
        {
              return _context.TblLocations != null ? 
                          View(await _context.TblLocations.ToListAsync()) :
                          Problem("Entity set 'HardwaremanagementContext.TblLocations'  is null.");
        }

        // GET: TblLocations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TblLocations == null)
            {
                return NotFound();
            }

            var tblLocation = await _context.TblLocations
                .FirstOrDefaultAsync(m => m.LocationId == id);
            if (tblLocation == null)
            {
                return NotFound();
            }

            return View(tblLocation);
        }

        // GET: TblLocations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblLocations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LocationId,Location")] TblLocation tblLocation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblLocation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblLocation);
        }

        // GET: TblLocations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TblLocations == null)
            {
                return NotFound();
            }

            var tblLocation = await _context.TblLocations.FindAsync(id);
            if (tblLocation == null)
            {
                return NotFound();
            }
            return View(tblLocation);
        }

        // POST: TblLocations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LocationId,Location")] TblLocation tblLocation)
        {
            if (id != tblLocation.LocationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblLocation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblLocationExists(tblLocation.LocationId))
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
            return View(tblLocation);
        }

        // GET: TblLocations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TblLocations == null)
            {
                return NotFound();
            }

            var tblLocation = await _context.TblLocations
                .FirstOrDefaultAsync(m => m.LocationId == id);
            if (tblLocation == null)
            {
                return NotFound();
            }

            return View(tblLocation);
        }

        // POST: TblLocations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TblLocations == null)
            {
                return Problem("Entity set 'HardwaremanagementContext.TblLocations'  is null.");
            }
            var tblLocation = await _context.TblLocations.FindAsync(id);
            if (tblLocation != null)
            {
                _context.TblLocations.Remove(tblLocation);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblLocationExists(int id)
        {
          return (_context.TblLocations?.Any(e => e.LocationId == id)).GetValueOrDefault();
        }
    }
}
