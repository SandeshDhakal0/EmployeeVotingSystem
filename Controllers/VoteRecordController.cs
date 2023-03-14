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
    public class VoteRecordController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VoteRecordController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: VoteRecord
        public async Task<IActionResult> Index()
        {
              return _context.VoteRecord != null ? 
                          View(await _context.VoteRecord.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.VoteRecord'  is null.");
        }

        // GET: VoteRecord/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.VoteRecord == null)
            {
                return NotFound();
            }

            var voteRecord = await _context.VoteRecord
                .FirstOrDefaultAsync(m => m.recordid == id);
            if (voteRecord == null)
            {
                return NotFound();
            }

            return View(voteRecord);
        }

        // GET: VoteRecord/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VoteRecord/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("recordid,voterid,candidateid,votingyear,votingmonth")] VoteRecord voteRecord)
        {
            if (ModelState.IsValid)
            {
                _context.Add(voteRecord);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(voteRecord);
        }

        // GET: VoteRecord/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.VoteRecord == null)
            {
                return NotFound();
            }

            var voteRecord = await _context.VoteRecord.FindAsync(id);
            if (voteRecord == null)
            {
                return NotFound();
            }
            return View(voteRecord);
        }

        // POST: VoteRecord/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("recordid,voterid,candidateid,votingyear,votingmonth")] VoteRecord voteRecord)
        {
            if (id != voteRecord.recordid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(voteRecord);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VoteRecordExists(voteRecord.recordid))
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
            return View(voteRecord);
        }

        // GET: VoteRecord/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.VoteRecord == null)
            {
                return NotFound();
            }

            var voteRecord = await _context.VoteRecord
                .FirstOrDefaultAsync(m => m.recordid == id);
            if (voteRecord == null)
            {
                return NotFound();
            }

            return View(voteRecord);
        }

        // POST: VoteRecord/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.VoteRecord == null)
            {
                return Problem("Entity set 'ApplicationDbContext.VoteRecord'  is null.");
            }
            var voteRecord = await _context.VoteRecord.FindAsync(id);
            if (voteRecord != null)
            {
                _context.VoteRecord.Remove(voteRecord);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VoteRecordExists(string id)
        {
          return (_context.VoteRecord?.Any(e => e.recordid == id)).GetValueOrDefault();
        }
    }
}
