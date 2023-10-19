using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AuthSystem.Data;
using AuthSystem.Models;

namespace AuthSystem.Controllers
{
    public class LeaveBalancesController : Controller
    {
        private readonly AuthDbContext _context;

        public LeaveBalancesController(AuthDbContext context)
        {
            _context = context;
        }

        // GET: LeaveBalances
        public async Task<IActionResult> Index()
        {
            var authDbContext = _context.LeaveBalances.Include(l => l.User);
            return View(await authDbContext.ToListAsync());
        }

        // GET: LeaveBalances/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.LeaveBalances == null)
            {
                return NotFound();
            }

            var leaveBalance = await _context.LeaveBalances
                .Include(l => l.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (leaveBalance == null)
            {
                return NotFound();
            }

            return View(leaveBalance);
        }

        // GET: LeaveBalances/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: LeaveBalances/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,VacationDays,SickDays,SickKidsDays")] LeaveBalance leaveBalance)
        {
            if (ModelState.IsValid)
            {
                _context.Add(leaveBalance);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", leaveBalance.UserId);
            return View(leaveBalance);
        }

        // GET: LeaveBalances/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.LeaveBalances == null)
            {
                return NotFound();
            }

            var leaveBalance = await _context.LeaveBalances.FindAsync(id);
            if (leaveBalance == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", leaveBalance.UserId);
            return View(leaveBalance);
        }

        // POST: LeaveBalances/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,VacationDays,SickDays,SickKidsDays")] LeaveBalance leaveBalance)
        {
            if (id != leaveBalance.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(leaveBalance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeaveBalanceExists(leaveBalance.Id))
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
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", leaveBalance.UserId);
            return View(leaveBalance);
        }

        // GET: LeaveBalances/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.LeaveBalances == null)
            {
                return NotFound();
            }

            var leaveBalance = await _context.LeaveBalances
                .Include(l => l.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (leaveBalance == null)
            {
                return NotFound();
            }

            return View(leaveBalance);
        }

        // POST: LeaveBalances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.LeaveBalances == null)
            {
                return Problem("Entity set 'AuthDbContext.LeaveBalances'  is null.");
            }
            var leaveBalance = await _context.LeaveBalances.FindAsync(id);
            if (leaveBalance != null)
            {
                _context.LeaveBalances.Remove(leaveBalance);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LeaveBalanceExists(int id)
        {
          return _context.LeaveBalances.Any(e => e.Id == id);
        }
    }
}
