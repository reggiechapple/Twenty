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
    public class MatchesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MatchesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("/[area]/[controller]")]
        // GET: Matches
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Matches.Include(m => m.AwayTeam).Include(m => m.HomeTeam).Include(m => m.Winner);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Matches/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var match = await _context.Matches
                .Include(m => m.AwayTeam)
                .Include(m => m.HomeTeam)
                .Include(m => m.Winner)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (match == null)
            {
                return NotFound();
            }

            return View(match);
        }

        // GET: Matches/Create
        public IActionResult Create()
        {
            ViewData["AwayTeamId"] = new SelectList(_context.Teams, "Id", "Id");
            ViewData["HomeTeamId"] = new SelectList(_context.Teams, "Id", "Id");
            ViewData["WinnerId"] = new SelectList(_context.Teams, "Id", "Id");
            return View();
        }

        // POST: Matches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Start,HomeTeamId,AwayTeamId,WinnerId,Id,Created,Updated")] Match match)
        {
            if (ModelState.IsValid)
            {
                _context.Add(match);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AwayTeamId"] = new SelectList(_context.Teams, "Id", "Id", match.AwayTeamId);
            ViewData["HomeTeamId"] = new SelectList(_context.Teams, "Id", "Id", match.HomeTeamId);
            ViewData["WinnerId"] = new SelectList(_context.Teams, "Id", "Id", match.WinnerId);
            return View(match);
        }

        // GET: Matches/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var match = await _context.Matches.FindAsync(id);
            if (match == null)
            {
                return NotFound();
            }
            ViewData["AwayTeamId"] = new SelectList(_context.Teams, "Id", "Id", match.AwayTeamId);
            ViewData["HomeTeamId"] = new SelectList(_context.Teams, "Id", "Id", match.HomeTeamId);
            ViewData["WinnerId"] = new SelectList(_context.Teams, "Id", "Id", match.WinnerId);
            return View(match);
        }

        // POST: Matches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Start,HomeTeamId,AwayTeamId,WinnerId,Id,Created,Updated")] Match match)
        {
            if (id != match.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(match);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MatchExists(match.Id))
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
            ViewData["AwayTeamId"] = new SelectList(_context.Teams, "Id", "Id", match.AwayTeamId);
            ViewData["HomeTeamId"] = new SelectList(_context.Teams, "Id", "Id", match.HomeTeamId);
            ViewData["WinnerId"] = new SelectList(_context.Teams, "Id", "Id", match.WinnerId);
            return View(match);
        }

        // GET: Matches/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var match = await _context.Matches
                .Include(m => m.AwayTeam)
                .Include(m => m.HomeTeam)
                .Include(m => m.Winner)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (match == null)
            {
                return NotFound();
            }

            return View(match);
        }

        // POST: Matches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var match = await _context.Matches.FindAsync(id);
            _context.Matches.Remove(match);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MatchExists(long id)
        {
            return _context.Matches.Any(e => e.Id == id);
        }
    }
}
