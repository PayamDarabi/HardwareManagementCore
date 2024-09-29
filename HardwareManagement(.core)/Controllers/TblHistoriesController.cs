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
    public class TblHistoriesController : Controller
    {
        private readonly HardwaremanagementContext _context;

        public TblHistoriesController(HardwaremanagementContext context)
        {
            _context = context;
        }

        // GET: TblHistories
        public async Task<IActionResult> Index()
        {
              return _context.TblHistories != null ? 
                          View(await _context.TblHistories.ToListAsync()) :
                          Problem("Entity set 'HardwaremanagementContext.TblHistories'  is null.");
        }

        // GET: TblHistories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TblHistories == null)
            {
                return NotFound();
            }

            var tblHistory = await _context.TblHistories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblHistory == null)
            {
                return NotFound();
            }

            return View(tblHistory);
        }

        // GET: TblHistories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblHistories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AssetNo,SerialNo,Title,Model,AssignDate,RecieveDate,UserSender,RepairDate,OutOfDate,StatusHw")] TblHistory tblHistory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblHistory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblHistory);
        }

        // GET: TblHistories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TblHistories == null)
            {
                return NotFound();
            }

            var tblHistory = await _context.TblHistories.FindAsync(id);
            if (tblHistory == null)
            {
                return NotFound();
            }
            return View(tblHistory);
        }

        // POST: TblHistories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AssetNo,SerialNo,Title,Model,AssignDate,RecieveDate,UserSender,RepairDate,OutOfDate,StatusHw")] TblHistory tblHistory)
        {
            if (id != tblHistory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblHistory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblHistoryExists(tblHistory.Id))
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
            return View(tblHistory);
        }

        // GET: TblHistories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TblHistories == null)
            {
                return NotFound();
            }

            var tblHistory = await _context.TblHistories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblHistory == null)
            {
                return NotFound();
            }

            return View(tblHistory);
        }

        // POST: TblHistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TblHistories == null)
            {
                return Problem("Entity set 'HardwaremanagementContext.TblHistories'  is null.");
            }
            var tblHistory = await _context.TblHistories.FindAsync(id);
            if (tblHistory != null)
            {
                _context.TblHistories.Remove(tblHistory);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblHistoryExists(int id)
        {
          return (_context.TblHistories?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
