using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Twenty.Data;
using Twenty.Data.Domain;

namespace Twenty.Controllers
{
    public class UserBetsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserBetsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UserBets
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.UserBets.Include(u => u.Bet).Include(u => u.Member).Include(u => u.Selection);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: UserBets/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userBet = await _context.UserBets
                .Include(u => u.Bet)
                .Include(u => u.Member)
                .Include(u => u.Selection)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userBet == null)
            {
                return NotFound();
            }

            return View(userBet);
        }

        // GET: UserBets/Create
        public IActionResult Create()
        {
            ViewData["BetId"] = new SelectList(_context.Bets, "Id", "Id");
            ViewData["MemberId"] = new SelectList(_context.Members, "Id", "Id");
            ViewData["SelectionId"] = new SelectList(_context.Teams, "Id", "Id");
            return View();
        }

        // POST: UserBets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Correct,Spread,Amount,SelectionId,MemberId,BetId,Id,Created,Updated")] UserBet userBet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userBet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BetId"] = new SelectList(_context.Bets, "Id", "Id", userBet.BetId);
            ViewData["MemberId"] = new SelectList(_context.Members, "Id", "Id", userBet.MemberId);
            ViewData["SelectionId"] = new SelectList(_context.Teams, "Id", "Id", userBet.SelectionId);
            return View(userBet);
        }

        // GET: UserBets/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userBet = await _context.UserBets.FindAsync(id);
            if (userBet == null)
            {
                return NotFound();
            }
            ViewData["BetId"] = new SelectList(_context.Bets, "Id", "Id", userBet.BetId);
            ViewData["MemberId"] = new SelectList(_context.Members, "Id", "Id", userBet.MemberId);
            ViewData["SelectionId"] = new SelectList(_context.Teams, "Id", "Id", userBet.SelectionId);
            return View(userBet);
        }

        // POST: UserBets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Correct,Spread,Amount,SelectionId,MemberId,BetId,Id,Created,Updated")] UserBet userBet)
        {
            if (id != userBet.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userBet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserBetExists(userBet.Id))
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
            ViewData["BetId"] = new SelectList(_context.Bets, "Id", "Id", userBet.BetId);
            ViewData["MemberId"] = new SelectList(_context.Members, "Id", "Id", userBet.MemberId);
            ViewData["SelectionId"] = new SelectList(_context.Teams, "Id", "Id", userBet.SelectionId);
            return View(userBet);
        }

        // GET: UserBets/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userBet = await _context.UserBets
                .Include(u => u.Bet)
                .Include(u => u.Member)
                .Include(u => u.Selection)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userBet == null)
            {
                return NotFound();
            }

            return View(userBet);
        }

        // POST: UserBets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var userBet = await _context.UserBets.FindAsync(id);
            _context.UserBets.Remove(userBet);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserBetExists(long id)
        {
            return _context.UserBets.Any(e => e.Id == id);
        }
    }
}
