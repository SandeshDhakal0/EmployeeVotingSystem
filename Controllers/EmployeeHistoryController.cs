using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmployeeVotingSystem.Models;

namespace EmployeeVotingSystem.Controllers
{
    public class EmployeeHistoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeHistoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EmployeeHistory
        public async Task<IActionResult> Index()
        {
              return _context.EmployeeHistory != null ? 
                          View(await _context.EmployeeHistory.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.EmployeeHistory'  is null.");
        }

        // GET: EmployeeHistory/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.EmployeeHistory == null)
            {
                return NotFound();
            }

            var employeeHistory = await _context.EmployeeHistory
                .FirstOrDefaultAsync(m => m.historyid == id);
            if (employeeHistory == null)
            {
                return NotFound();
            }

            return View(employeeHistory);
        }

        // GET: EmployeeHistory/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmployeeHistory/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("historyid,employeeid,departmentid,roleid,startdate,enddate")] EmployeeHistory employeeHistory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeHistory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employeeHistory);
        }

        // GET: EmployeeHistory/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.EmployeeHistory == null)
            {
                return NotFound();
            }

            var employeeHistory = await _context.EmployeeHistory.FindAsync(id);
            if (employeeHistory == null)
            {
                return NotFound();
            }
            return View(employeeHistory);
        }

        // POST: EmployeeHistory/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("historyid,employeeid,departmentid,roleid,startdate,enddate")] EmployeeHistory employeeHistory)
        {
            if (id != employeeHistory.historyid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeHistory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeHistoryExists(employeeHistory.historyid))
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
            return View(employeeHistory);
        }

        // GET: EmployeeHistory/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.EmployeeHistory == null)
            {
                return NotFound();
            }

            var employeeHistory = await _context.EmployeeHistory
                .FirstOrDefaultAsync(m => m.historyid == id);
            if (employeeHistory == null)
            {
                return NotFound();
            }

            return View(employeeHistory);
        }

        // POST: EmployeeHistory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.EmployeeHistory == null)
            {
                return Problem("Entity set 'ApplicationDbContext.EmployeeHistory'  is null.");
            }
            var employeeHistory = await _context.EmployeeHistory.FindAsync(id);
            if (employeeHistory != null)
            {
                _context.EmployeeHistory.Remove(employeeHistory);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeHistoryExists(string id)
        {
          return (_context.EmployeeHistory?.Any(e => e.historyid == id)).GetValueOrDefault();
        }
    }
}
