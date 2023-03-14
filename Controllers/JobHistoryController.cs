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
    public class JobHistoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JobHistoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: JobHistory
        public async Task<IActionResult> Index()
        {
              return _context.JobHistory != null ? 
                          View(await _context.JobHistory.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.JobHistory'  is null.");
        }

        // GET: JobHistory/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.JobHistory == null)
            {
                return NotFound();
            }

            var jobHistory = await _context.JobHistory
                .FirstOrDefaultAsync(m => m.JobHistoryID == id);
            if (jobHistory == null)
            {
                return NotFound();
            }

            return View(jobHistory);
        }

        // GET: JobHistory/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: JobHistory/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("JobHistoryID,startdate,enddate,DepartmentID,RoleID")] JobHistory jobHistory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jobHistory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jobHistory);
        }

        // GET: JobHistory/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.JobHistory == null)
            {
                return NotFound();
            }

            var jobHistory = await _context.JobHistory.FindAsync(id);
            if (jobHistory == null)
            {
                return NotFound();
            }
            return View(jobHistory);
        }

        // POST: JobHistory/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("JobHistoryID,startdate,enddate,DepartmentID,RoleID")] JobHistory jobHistory)
        {
            if (id != jobHistory.JobHistoryID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jobHistory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobHistoryExists(jobHistory.JobHistoryID))
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
            return View(jobHistory);
        }

        // GET: JobHistory/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.JobHistory == null)
            {
                return NotFound();
            }

            var jobHistory = await _context.JobHistory
                .FirstOrDefaultAsync(m => m.JobHistoryID == id);
            if (jobHistory == null)
            {
                return NotFound();
            }

            return View(jobHistory);
        }

        // POST: JobHistory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.JobHistory == null)
            {
                return Problem("Entity set 'ApplicationDbContext.JobHistory'  is null.");
            }
            var jobHistory = await _context.JobHistory.FindAsync(id);
            if (jobHistory != null)
            {
                _context.JobHistory.Remove(jobHistory);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JobHistoryExists(int id)
        {
          return (_context.JobHistory?.Any(e => e.JobHistoryID == id)).GetValueOrDefault();
        }
    }
}
