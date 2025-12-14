using BoughtAndHappy.DTO;
using BoughtAndHappy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BoughtAndHappy.Controllers
{
    public class ShopController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ShopController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index(string? searchText, ProductCategories? category)
        {
            var products = _context.Products.AsQueryable();

            if (category.HasValue)
            {
                products = products.Where(p => p.Category == category);
                ViewBag.SelectedCategory = Convert.ToByte(category);
            }

            if (!string.IsNullOrEmpty(searchText))
            {
                products = products.Where(p => p.Name.Contains(searchText));
                ViewBag.SearchText = searchText;
            }

            return View(await products.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
    }
}
