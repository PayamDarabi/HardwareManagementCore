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
    public class PersonsController : Controller
    {
        private readonly HardwaremanagementContext _context;

        public PersonsController(HardwaremanagementContext context)
        {
            _context = context;
        }

       

        // GET: TblPersons
        public async Task<IActionResult> Index()

        {

            return _context.TblPeople != null ?
                        View(await _context.TblPeople.ToListAsync()) :
                        Problem("Entity set 'HardwaremanagementContext.TblPeople'  is null.");
        }

        public async Task<IActionResult> InfoPrs()
        {
            return _context.TblPeople != null ?
                             View(await _context.TblPeople.ToListAsync()) :
                             Problem("Entity set 'HardwaremanagementContext.tblPeople'  is null.");
        }

        public async Task <IActionResult> ShowAddModal([Bind("PersonId,Name,Phone,Unit,RoomNo,Status,Note")] TblPerson tblPerson)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblPerson);
                await _context.SaveChangesAsync();
                return RedirectToAction("Create", "Persons");
            }
            return PartialView("_AddPrs", new TblPerson()
            {Name=tblPerson.Name,
            PersonId=tblPerson.PersonId,
            Unit=tblPerson.Unit,
            });
        }

        // GET: TblPersons/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.TblPeople == null)
            {
                return NotFound();
            }

            var tblPerson = await _context.TblPeople
                .FirstOrDefaultAsync(m => m.PersonId == id);
            if (tblPerson == null)
            {
                return NotFound();
            }

            return View(tblPerson);
        }

        // GET: TblPersons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblPersons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonId,Name,Phone,Unit,RoomNo,Status,Note")] TblPerson tblPerson)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblPerson);
                await _context.SaveChangesAsync();
                return RedirectToAction("Create","Persons");
            }
            return View();
        }

        // GET: TblPersons/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.TblPeople == null)
            {
                return NotFound();
            }

            var tblPerson = await _context.TblPeople.FindAsync(id);
            if (tblPerson == null)
            {
                return NotFound();
            }
            return View(tblPerson);
        }

        // POST: TblPersons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("PersonId,Name,Phone,Unit,RoomNo,Status,Note")] TblPerson tblPerson)
        {
            if (id != tblPerson.PersonId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblPerson);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblPersonExists(tblPerson.PersonId))
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
            return View(tblPerson);
        }

        // GET: TblPersons/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.TblPeople == null)
            {
                return NotFound();
            }

            var tblPerson = await _context.TblPeople
                .FirstOrDefaultAsync(m => m.PersonId == id);
            if (tblPerson == null)
            {
                return NotFound();
            }

            return View(tblPerson);
        }

        // POST: TblPersons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.TblPeople == null)
            {
                return Problem("Entity set 'HardwaremanagementContext.TblPeople'  is null.");
            }
            var tblPerson = await _context.TblPeople.FindAsync(id);
            if (tblPerson != null)
            {
                _context.TblPeople.Remove(tblPerson);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblPersonExists(string id)
        {
          return (_context.TblPeople?.Any(e => e.PersonId == id)).GetValueOrDefault();
        }
    }
}
