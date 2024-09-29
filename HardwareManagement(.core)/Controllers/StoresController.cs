using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HardwareManagement_.core_.Models.Entity;
using Stimulsoft.Report;
using Stimulsoft.Report.Dictionary;
using Stimulsoft.Report.Mvc;
using Stimulsoft.Report.Web;
using Microsoft.Extensions.Hosting;
using System.Data;
using Stimulsoft.Blockly.Model;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HardwareManagement_.core_.Controllers6
{
    public class StoresController : Controller
    {
        private readonly HardwaremanagementContext _context;

        public StoresController(HardwaremanagementContext context)
        {
            _context = context;
        }

             


        [HttpGet]
        public IActionResult RptOfSt()
        {
            var StList = (from TblStore in _context.TblStores
                          select new SelectListItem()
                          {
                              Text = TblStore.StLocation,
                              Value = TblStore.StoreId.ToString()
                          }).ToList();
            StList.Insert(0, new SelectListItem()
            {
                Text = "...Select...",
                Value = string.Empty

            });
            ViewBag.ListOfSt=StList;
             
            return View();

        }
        
        [HttpPost]
        public async Task<IActionResult> RptOfSt([Bind("StoreId ,StLocation")] TblStore Str)

        {

           
            return View();
        }

        public IActionResult GetReport()
         {


            var path = StiNetCoreHelper.MapPath(this, "Report/RptOfStoreStock.mrt");
            StiReport report = new StiReport();

            report.Load(path);
            //report.Dictionary.Variables["StLocation"].Value=ViewBag.ListOfSt;
            //report.RegData(name: "StoreStock",StList);

            return StiNetCoreViewer.GetReportResult(this, report);


        }

        public IActionResult ViewrEvent()
        {
            return StiNetCoreViewer.ViewerEventResult(this);
        }
        // GET: TblStores
        public async Task<IActionResult> Index()
        {
              return _context.TblStores != null ? 
                          View(await _context.TblStores.ToListAsync()) :
                          Problem("Entity set 'HardwaremanagementContext.TblStores'  is null.");
          
        }

        // GET: TblStores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TblStores == null)
            {
                return NotFound();
            }

            var tblStore = await _context.TblStores
                .FirstOrDefaultAsync(m => m.StoreId == id);
            if (tblStore == null)
            {
                return NotFound();
            }

            return View(tblStore);
        }

        // GET: TblStores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblStores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StoreId,StLocation")] TblStore tblStore)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblStore);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Stores");
            }
            return View(Index);
        }

        // GET: TblStores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TblStores == null)
            {
                return NotFound();
            }

            var tblStore = await _context.TblStores.FindAsync(id);
            if (tblStore == null)
            {
                return NotFound();
            }
            return View(tblStore);
        }

        // POST: TblStores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StoreId,StLocation")] TblStore tblStore)
        {
            if (id != tblStore.StoreId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblStore);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblStoreExists(tblStore.StoreId))
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
            return View(tblStore);
        }

        // GET: TblStores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TblStores == null)
            {
                return NotFound();
            }

            var tblStore = await _context.TblStores
                .FirstOrDefaultAsync(m => m.StoreId == id);
            if (tblStore == null)
            {
                return NotFound();
            }

            return View(tblStore);
        }

        // POST: TblStores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TblStores == null)
            {
                return Problem("Entity set 'HardwaremanagementContext.TblStores'  is null.");
            }
            var tblStore = await _context.TblStores.FindAsync(id);
            if (tblStore != null)
            {
                _context.TblStores.Remove(tblStore);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Stores");
        }

        private bool TblStoreExists(int id)
        {
          return (_context.TblStores?.Any(e => e.StoreId == id)).GetValueOrDefault();
        }
    }
}
