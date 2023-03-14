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
    public class EmployeeAddressController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeAddressController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EmployeeAddress
        public async Task<IActionResult> Index()
        {
              return _context.EmployeeAddress != null ? 
                          View(await _context.EmployeeAddress.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.EmployeeAddress'  is null.");
        }

        // GET: EmployeeAddress/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.EmployeeAddress == null)
            {
                return NotFound();
            }

            var employeeAddress = await _context.EmployeeAddress
                .FirstOrDefaultAsync(m => m.addressid == id);
            if (employeeAddress == null)
            {
                return NotFound();
            }

            return View(employeeAddress);
        }

        // GET: EmployeeAddress/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmployeeAddress/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("addressid,employeeid")] EmployeeAddress employeeAddress)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeAddress);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employeeAddress);
        }

        // GET: EmployeeAddress/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.EmployeeAddress == null)
            {
                return NotFound();
            }

            var employeeAddress = await _context.EmployeeAddress.FindAsync(id);
            if (employeeAddress == null)
            {
                return NotFound();
            }
            return View(employeeAddress);
        }

        // POST: EmployeeAddress/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("addressid,employeeid")] EmployeeAddress employeeAddress)
        {
            if (id != employeeAddress.addressid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeAddress);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeAddressExists(employeeAddress.addressid))
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
            return View(employeeAddress);
        }

        // GET: EmployeeAddress/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.EmployeeAddress == null)
            {
                return NotFound();
            }

            var employeeAddress = await _context.EmployeeAddress
                .FirstOrDefaultAsync(m => m.addressid == id);
            if (employeeAddress == null)
            {
                return NotFound();
            }

            return View(employeeAddress);
        }

        // POST: EmployeeAddress/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.EmployeeAddress == null)
            {
                return Problem("Entity set 'ApplicationDbContext.EmployeeAddress'  is null.");
            }
            var employeeAddress = await _context.EmployeeAddress.FindAsync(id);
            if (employeeAddress != null)
            {
                _context.EmployeeAddress.Remove(employeeAddress);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeAddressExists(string id)
        {
          return (_context.EmployeeAddress?.Any(e => e.addressid == id)).GetValueOrDefault();
        }
    }
}
