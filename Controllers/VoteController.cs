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
    public class VoteController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VoteController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Vote
        public async Task<IActionResult> Index()
        {
              return _context.Vote != null ? 
                          View(await _context.Vote.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Vote'  is null.");
        }

        // GET: Vote/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Vote == null)
            {
                return NotFound();
            }

            var vote = await _context.Vote
                .FirstOrDefaultAsync(m => m.VoteID == id);
            if (vote == null)
            {
                return NotFound();
            }

            return View(vote);
        }

        // GET: Vote/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vote/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VoteID,VotingYear,VotingMonth,CandidateID")] Vote vote)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vote);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vote);
        }

        // GET: Vote/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Vote == null)
            {
                return NotFound();
            }

            var vote = await _context.Vote.FindAsync(id);
            if (vote == null)
            {
                return NotFound();
            }
            return View(vote);
        }

        // POST: Vote/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VoteID,VotingYear,VotingMonth,CandidateID")] Vote vote)
        {
            if (id != vote.VoteID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vote);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VoteExists(vote.VoteID))
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
            return View(vote);
        }

        // GET: Vote/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Vote == null)
            {
                return NotFound();
            }

            var vote = await _context.Vote
                .FirstOrDefaultAsync(m => m.VoteID == id);
            if (vote == null)
            {
                return NotFound();
            }

            return View(vote);
        }

        // POST: Vote/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Vote == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Vote'  is null.");
            }
            var vote = await _context.Vote.FindAsync(id);
            if (vote != null)
            {
                _context.Vote.Remove(vote);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VoteExists(int id)
        {
          return (_context.Vote?.Any(e => e.VoteID == id)).GetValueOrDefault();
        }
    }
}
