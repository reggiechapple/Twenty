using System.Linq;
using System.Threading.Tasks;
using Twenty.Areas.Members.Models;
using Twenty.Data;
using Twenty.Data.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Twenty.Areas.Members.Controllers
{
    [Authorize(Roles = "Member")]
    [Area("Members")]
    [Route("[area]/{id}/[action]")]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<HomeController> _logger;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(ILogger<HomeController> logger, 
            SignInManager<ApplicationUser> signInManager, 
            UserManager<ApplicationUser> userManager,
            ApplicationDbContext context)
        {
            _context = context;
            _logger = logger;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet("/[area]/{id}")]
        public async Task<IActionResult> Index(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = await _context.Members.Include(m => m.Identity).FirstOrDefaultAsync(m => m.Id == id);

            if (member == null)
            {
               return NotFound();
            }

            ViewData["CurrentMemberId"] = member.Id;

            return View(member);
        }
    }
}