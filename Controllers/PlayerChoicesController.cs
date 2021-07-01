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
    public class PlayerChoicesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlayerChoicesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PlayerChoices
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PlayerChoices.Include(p => p.Choice).Include(p => p.Game).Include(p => p.Player);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PlayerChoices/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playerChoice = await _context.PlayerChoices
                .Include(p => p.Choice)
                .Include(p => p.Game)
                .Include(p => p.Player)
                .FirstOrDefaultAsync(m => m.PlayerId == id);
            if (playerChoice == null)
            {
                return NotFound();
            }

            return View(playerChoice);
        }

        // GET: PlayerChoices/Create
        public IActionResult Create()
        {
            ViewData["ChoiceId"] = new SelectList(_context.Choice, "Id", "Id");
            ViewData["GameId"] = new SelectList(_context.Games, "Id", "Id");
            ViewData["PlayerId"] = new SelectList(_context.Players, "Id", "Id");
            return View();
        }

        // POST: PlayerChoices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlayerId,ChoiceId,GameId")] PlayerChoice playerChoice)
        {
            if (ModelState.IsValid)
            {
                _context.Add(playerChoice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ChoiceId"] = new SelectList(_context.Choice, "Id", "Id", playerChoice.ChoiceId);
            ViewData["GameId"] = new SelectList(_context.Games, "Id", "Id", playerChoice.GameId);
            ViewData["PlayerId"] = new SelectList(_context.Players, "Id", "Id", playerChoice.PlayerId);
            return View(playerChoice);
        }

        // GET: PlayerChoices/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playerChoice = await _context.PlayerChoices.FindAsync(id);
            if (playerChoice == null)
            {
                return NotFound();
            }
            ViewData["ChoiceId"] = new SelectList(_context.Choice, "Id", "Id", playerChoice.ChoiceId);
            ViewData["GameId"] = new SelectList(_context.Games, "Id", "Id", playerChoice.GameId);
            ViewData["PlayerId"] = new SelectList(_context.Players, "Id", "Id", playerChoice.PlayerId);
            return View(playerChoice);
        }

        // POST: PlayerChoices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("PlayerId,ChoiceId,GameId")] PlayerChoice playerChoice)
        {
            if (id != playerChoice.PlayerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(playerChoice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlayerChoiceExists(playerChoice.PlayerId))
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
            ViewData["ChoiceId"] = new SelectList(_context.Choice, "Id", "Id", playerChoice.ChoiceId);
            ViewData["GameId"] = new SelectList(_context.Games, "Id", "Id", playerChoice.GameId);
            ViewData["PlayerId"] = new SelectList(_context.Players, "Id", "Id", playerChoice.PlayerId);
            return View(playerChoice);
        }

        // GET: PlayerChoices/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playerChoice = await _context.PlayerChoices
                .Include(p => p.Choice)
                .Include(p => p.Game)
                .Include(p => p.Player)
                .FirstOrDefaultAsync(m => m.PlayerId == id);
            if (playerChoice == null)
            {
                return NotFound();
            }

            return View(playerChoice);
        }

        // POST: PlayerChoices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var playerChoice = await _context.PlayerChoices.FindAsync(id);
            _context.PlayerChoices.Remove(playerChoice);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlayerChoiceExists(long id)
        {
            return _context.PlayerChoices.Any(e => e.PlayerId == id);
        }
    }
}
