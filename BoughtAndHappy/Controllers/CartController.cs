using BoughtAndHappy.DTO;
using BoughtAndHappy.Services;
using Microsoft.AspNetCore.Mvc;

namespace BoughtAndHappy.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly CartService _cart;

        public CartController(ApplicationDbContext context, CartService cart)
        {
            _context = context;
            _cart = cart;
        }

        public IActionResult Index()
        {
            return View(_cart.GetCart());
        }

        public IActionResult Add(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _cart.AddToCart(product);
            }

            return RedirectToAction("Index", "Shop");
        }

        public IActionResult Plus(int id)
        {
            _cart.Increase(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Minus(int id)
        {
            _cart.Decrease(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Remove(int id)
        {
            _cart.RemoveFromCart(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Clear()
        {
            _cart.Clear();
            return RedirectToAction(nameof(Index));
        }
    }
}
