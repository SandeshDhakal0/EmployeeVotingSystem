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
    public class EmailController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmailController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Email
        public async Task<IActionResult> Index()
        {
              return _context.Email != null ? 
                          View(await _context.Email.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Email'  is null.");
        }

        // GET: Email/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Email == null)
            {
                return NotFound();
            }

            var email = await _context.Email
                .FirstOrDefaultAsync(m => m.Email_Address == id);
            if (email == null)
            {
                return NotFound();
            }

            return View(email);
        }

        // GET: Email/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Email/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Email_Address,EmployeeID")] Email email)
        {
            if (ModelState.IsValid)
            {
                _context.Add(email);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(email);
        }

        // GET: Email/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Email == null)
            {
                return NotFound();
            }

            var email = await _context.Email.FindAsync(id);
            if (email == null)
            {
                return NotFound();
            }
            return View(email);
        }

        // POST: Email/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Email_Address,EmployeeID")] Email email)
        {
            if (id != email.Email_Address)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(email);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmailExists(email.Email_Address))
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
            return View(email);
        }

        // GET: Email/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Email == null)
            {
                return NotFound();
            }

            var email = await _context.Email
                .FirstOrDefaultAsync(m => m.Email_Address == id);
            if (email == null)
            {
                return NotFound();
            }

            return View(email);
        }

        // POST: Email/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Email == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Email'  is null.");
            }
            var email = await _context.Email.FindAsync(id);
            if (email != null)
            {
                _context.Email.Remove(email);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmailExists(string id)
        {
          return (_context.Email?.Any(e => e.Email_Address == id)).GetValueOrDefault();
        }
    }
}
