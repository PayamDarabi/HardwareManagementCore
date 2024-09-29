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
    public class ModelsController : Controller
    {
        private readonly HardwaremanagementContext _context;

        public ModelsController(HardwaremanagementContext context)
        {
            _context = context;
        }

        // GET: TblModels
        public async Task<IActionResult> Index()
        {
              return _context.TblModels != null ? 
                          View(await _context.TblModels.ToListAsync()) :
                          Problem("Entity set 'HardwaremanagementContext.TblModels'  is null.");
        }

        // GET: TblModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TblModels == null)
            {
                return NotFound();
            }

            var tblModel = await _context.TblModels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblModel == null)
            {
                return NotFound();
            }

            return View(tblModel);
        }

        // GET: TblModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Model,Title")] TblModel tblModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblModel);
        }

        // GET: TblModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TblModels == null)
            {
                return NotFound();
            }

            var tblModel = await _context.TblModels.FindAsync(id);
            if (tblModel == null)
            {
                return NotFound();
            }
            return View(tblModel);
        }

        // POST: TblModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Model,Title")] TblModel tblModel)
        {
            if (id != tblModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblModelExists(tblModel.Id))
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
            return View(tblModel);
        }

        // GET: TblModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TblModels == null)
            {
                return NotFound();
            }

            var tblModel = await _context.TblModels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblModel == null)
            {
                return NotFound();
            }

            return View(tblModel);
        }

        // POST: TblModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TblModels == null)
            {
                return Problem("Entity set 'HardwaremanagementContext.TblModels'  is null.");
            }
            var tblModel = await _context.TblModels.FindAsync(id);
            if (tblModel != null)
            {
                _context.TblModels.Remove(tblModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblModelExists(int id)
        {
          return (_context.TblModels?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
