using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HardwareManagement_.core_.Models.Entity;
using NuGet.ContentModel;
using System.Drawing.Printing;


namespace HardwareManagement_.core_.Controllers
{
    public class HardwaresController : Controller
    {
        private readonly HardwaremanagementContext _context;

        public HardwaresController(HardwaremanagementContext context)
        {
            _context = context;
           
        }
       
        public async Task<IActionResult>SearchHw()
        {
            return _context.TblHardwares != null ?
                             View(await _context.TblHardwares.ToListAsync()) :
                             Problem("Entity set 'HardwaremanagementContext.TblHardwares'  is null.");
        }
       
          // GET: TblHardwares
            public async Task<IActionResult> Index()
        {
           
            return _context.TblHardwares != null ? 
                          View(await _context.TblHardwares.ToListAsync()) :
                          Problem("Entity set 'HardwaremanagementContext.TblHardwares'  is null.");
                    }


        
        // GET: TblHardwares/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.TblHardwares == null)
            {
                return NotFound();
            }

            var tblHardware = await _context.TblHardwares
                .FirstOrDefaultAsync(m => m.AssetNo == id);
            if (tblHardware == null)
            {
                return NotFound();
            }

            return View(tblHardware);

        }

        // GET: TblHardwares/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblHardwares/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AssetNo,SerialNo,Title,Model,AssignDate,RecieveDate,PersonId,Location,StatusHw")] TblHardware tblHardware)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblHardware);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblHardware);
        }

        // GET: TblHardwares/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.TblHardwares == null)
            {
                return NotFound();
            }

            var tblHardware = await _context.TblHardwares.FindAsync(id);
            if (tblHardware == null)
            {
                return NotFound();
            }
            return View(tblHardware);
        }

        // POST: TblHardwares/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("AssetNo,SerialNo,Title,Model,AssignDate,RecieveDate,PersonId,Location,StatusHw")] TblHardware tblHardware)
        {
            if (id != tblHardware.AssetNo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblHardware);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblHardwareExists(tblHardware.AssetNo))
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
            return View(tblHardware);
        }

        // GET: TblHardwares/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.TblHardwares == null)
            {
                return NotFound();
            }

            var tblHardware = await _context.TblHardwares
                .FirstOrDefaultAsync(m => m.AssetNo == id);
            if (tblHardware == null)
            {
                return NotFound();
            }

            return View(tblHardware);
        }

        // POST: TblHardwares/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.TblHardwares == null)
            {
                return Problem("Entity set 'HardwaremanagementContext.TblHardwares'  is null.");
            }
            var tblHardware = await _context.TblHardwares.FindAsync(id);
            if (tblHardware != null)
            {
                _context.TblHardwares.Remove(tblHardware);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblHardwareExists(string id)
        {
          return (_context.TblHardwares?.Any(e => e.AssetNo == id)).GetValueOrDefault();
        }
    }
}
