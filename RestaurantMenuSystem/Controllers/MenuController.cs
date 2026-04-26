using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantSystem.Models;

namespace RestaurantSystem.Controllers
{
    public class MenuController : Controller
    {
        private readonly AppDbContext _context;

        public MenuController(AppDbContext context)
        {
            _context = context;
        }

        // list and filter logic
        public async Task<IActionResult> Index(string category)
        {
            var menuQuery = _context.MenuItems.AsQueryable();

            if (!string.IsNullOrEmpty(category))
            {
                menuQuery = menuQuery.Where(x => x.Category == category);
            }

            return View(await menuQuery.ToListAsync());
        }

        // detail logic
        public async Task<IActionResult> Details(int id)
        {
            var item = await _context.MenuItems.FindAsync(id);
            if (item == null) return NotFound();

            return View(item);
        }
    }
}
