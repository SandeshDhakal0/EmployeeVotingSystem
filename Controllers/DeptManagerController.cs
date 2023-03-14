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
    public class DeptManagerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DeptManagerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DeptManager
        public async Task<IActionResult> Index()
        {
              return _context.DeptManager != null ? 
                          View(await _context.DeptManager.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.DeptManager'  is null.");
        }

        // GET: DeptManager/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DeptManager == null)
            {
                return NotFound();
            }

            var deptManager = await _context.DeptManager
                .FirstOrDefaultAsync(m => m.DeptID == id);
            if (deptManager == null)
            {
                return NotFound();
            }

            return View(deptManager);
        }

        // GET: DeptManager/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DeptManager/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DeptID,EmployeeID")] DeptManager deptManager)
        {
            if (ModelState.IsValid)
            {
                _context.Add(deptManager);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(deptManager);
        }

        // GET: DeptManager/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DeptManager == null)
            {
                return NotFound();
            }

            var deptManager = await _context.DeptManager.FindAsync(id);
            if (deptManager == null)
            {
                return NotFound();
            }
            return View(deptManager);
        }

        // POST: DeptManager/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DeptID,EmployeeID")] DeptManager deptManager)
        {
            if (id != deptManager.DeptID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deptManager);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeptManagerExists(deptManager.DeptID))
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
            return View(deptManager);
        }

        // GET: DeptManager/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DeptManager == null)
            {
                return NotFound();
            }

            var deptManager = await _context.DeptManager
                .FirstOrDefaultAsync(m => m.DeptID == id);
            if (deptManager == null)
            {
                return NotFound();
            }

            return View(deptManager);
        }

        // POST: DeptManager/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DeptManager == null)
            {
                return Problem("Entity set 'ApplicationDbContext.DeptManager'  is null.");
            }
            var deptManager = await _context.DeptManager.FindAsync(id);
            if (deptManager != null)
            {
                _context.DeptManager.Remove(deptManager);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeptManagerExists(int id)
        {
          return (_context.DeptManager?.Any(e => e.DeptID == id)).GetValueOrDefault();
        }
    }
}
