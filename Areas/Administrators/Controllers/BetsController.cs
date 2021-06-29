using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Twenty.Data;
using Twenty.Data.Domain;

namespace Twenty.Areas.Administrators.Controllers
{
    [Area("Administrators")]
    [Route("[area]/[controller]/[action]")]
    public class BetsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BetsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("/[area]/[controller]")]
        // GET: Bets
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Bets.Include(b => b.Match).Include(b => b.Winner);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Bets/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bet = await _context.Bets
                .Include(b => b.Match)
                .Include(b => b.Winner)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bet == null)
            {
                return NotFound();
            }

            return View(bet);
        }

        // GET: Bets/Create
        public IActionResult Create()
        {
            ViewData["MatchId"] = new SelectList(_context.Matches, "Id", "Id");
            ViewData["WinnerId"] = new SelectList(_context.Teams, "Id", "Id");
            return View();
        }

        // POST: Bets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Description,WinningOdds,StartDate,CloseDate,IsLive,MatchId,WinnerId,Id,Created,Updated")] Bet bet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MatchId"] = new SelectList(_context.Matches, "Id", "Id", bet.MatchId);
            ViewData["WinnerId"] = new SelectList(_context.Teams, "Id", "Id", bet.WinnerId);
            return View(bet);
        }

        // GET: Bets/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bet = await _context.Bets.FindAsync(id);
            if (bet == null)
            {
                return NotFound();
            }
            ViewData["MatchId"] = new SelectList(_context.Matches, "Id", "Id", bet.MatchId);
            ViewData["WinnerId"] = new SelectList(_context.Teams, "Id", "Id", bet.WinnerId);
            return View(bet);
        }

        // POST: Bets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Title,Description,WinningOdds,StartDate,CloseDate,IsLive,MatchId,WinnerId,Id,Created,Updated")] Bet bet)
        {
            if (id != bet.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BetExists(bet.Id))
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
            ViewData["MatchId"] = new SelectList(_context.Matches, "Id", "Id", bet.MatchId);
            ViewData["WinnerId"] = new SelectList(_context.Teams, "Id", "Id", bet.WinnerId);
            return View(bet);
        }

        // GET: Bets/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bet = await _context.Bets
                .Include(b => b.Match)
                .Include(b => b.Winner)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bet == null)
            {
                return NotFound();
            }

            return View(bet);
        }

        // POST: Bets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var bet = await _context.Bets.FindAsync(id);
            _context.Bets.Remove(bet);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BetExists(long id)
        {
            return _context.Bets.Any(e => e.Id == id);
        }
    }
}
