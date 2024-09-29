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
    public class StatusHwsController : Controller
    {
        private readonly HardwaremanagementContext _context;

        public StatusHwsController(HardwaremanagementContext context)
        {
            _context = context;
        }

        // GET: TblStatusHws
        public async Task<IActionResult> Index()
        {
              return _context.TblStatusHws != null ? 
                          View(await _context.TblStatusHws.ToListAsync()) :
                          Problem("Entity set 'HardwaremanagementContext.TblStatusHws'  is null.");
        }

        // GET: TblStatusHws/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TblStatusHws == null)
            {
                return NotFound();
            }

            var tblStatusHw = await _context.TblStatusHws
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblStatusHw == null)
            {
                return NotFound();
            }

            return View(tblStatusHw);
        }

        // GET: TblStatusHws/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblStatusHws/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StatusHw")] TblStatusHw tblStatusHw)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblStatusHw);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblStatusHw);
        }

        // GET: TblStatusHws/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TblStatusHws == null)
            {
                return NotFound();
            }

            var tblStatusHw = await _context.TblStatusHws.FindAsync(id);
            if (tblStatusHw == null)
            {
                return NotFound();
            }
            return View(tblStatusHw);
        }

        // POST: TblStatusHws/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StatusHw")] TblStatusHw tblStatusHw)
        {
            if (id != tblStatusHw.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblStatusHw);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblStatusHwExists(tblStatusHw.Id))
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
            return View(tblStatusHw);
        }

        // GET: TblStatusHws/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TblStatusHws == null)
            {
                return NotFound();
            }

            var tblStatusHw = await _context.TblStatusHws
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblStatusHw == null)
            {
                return NotFound();
            }

            return View(tblStatusHw);
        }

        // POST: TblStatusHws/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TblStatusHws == null)
            {
                return Problem("Entity set 'HardwaremanagementContext.TblStatusHws'  is null.");
            }
            var tblStatusHw = await _context.TblStatusHws.FindAsync(id);
            if (tblStatusHw != null)
            {
                _context.TblStatusHws.Remove(tblStatusHw);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblStatusHwExists(int id)
        {
          return (_context.TblStatusHws?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
