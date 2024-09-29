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
    public class UnitsController : Controller
    {
        private readonly HardwaremanagementContext _context;

        public UnitsController(HardwaremanagementContext context)
        {
            _context = context;
        }


        [HttpPost]
        public IActionResult Index([Bind("Id,Unit")] TblUnit unt)
        {
            var UnitList = (from TblUnit in _context.TblUnits
                            select new SelectListItem()
                            {
                                Text = TblUnit.Unit,
                                Value = TblUnit.Id.ToString(),
                            }).ToList();
            UnitList.Insert(0, new SelectListItem()
            {
                Text = "...Select...",
                Value = string.Empty

            });
            ViewBag.ListOfunit = UnitList;

            return View();

        }
        // GET: TblUnits
        public async Task<IActionResult> Index()
        {
              return _context.TblUnits != null ? 
                          View(await _context.TblUnits.ToListAsync()) :
                          Problem("Entity set 'HardwaremanagementContext.TblUnits'  is null.");
        }

        // GET: TblUnits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TblUnits == null)
            {
                return NotFound();
            }

            var tblUnit = await _context.TblUnits
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblUnit == null)
            {
                return NotFound();
            }

            return View(tblUnit);
        }

        // GET: TblUnits/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblUnits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Unit")] TblUnit tblUnit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblUnit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblUnit);
        }

        // GET: TblUnits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TblUnits == null)
            {
                return NotFound();
            }

            var tblUnit = await _context.TblUnits.FindAsync(id);
            if (tblUnit == null)
            {
                return NotFound();
            }
            return View(tblUnit);
        }

        // POST: TblUnits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Unit")] TblUnit tblUnit)
        {
            if (id != tblUnit.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblUnit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblUnitExists(tblUnit.Id))
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
            return View(tblUnit);
        }

        // GET: TblUnits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TblUnits == null)
            {
                return NotFound();
            }

            var tblUnit = await _context.TblUnits
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblUnit == null)
            {
                return NotFound();
            }

            return View(tblUnit);
        }

        // POST: TblUnits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TblUnits == null)
            {
                return Problem("Entity set 'HardwaremanagementContext.TblUnits'  is null.");
            }
            var tblUnit = await _context.TblUnits.FindAsync(id);
            if (tblUnit != null)
            {
                _context.TblUnits.Remove(tblUnit);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblUnitExists(int id)
        {
          return (_context.TblUnits?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
