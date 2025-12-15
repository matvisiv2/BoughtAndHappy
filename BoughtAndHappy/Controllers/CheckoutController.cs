using BoughtAndHappy.DTO;
using BoughtAndHappy.Models;
using BoughtAndHappy.Services;
using Microsoft.AspNetCore.Mvc;

namespace BoughtAndHappy.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly CartService _cart;

        public CheckoutController(ApplicationDbContext context, CartService cart)
        {
            _context = context;
            _cart = cart;
        }

        public IActionResult Index()
        {
            var cart = _cart.GetCart();
            if (!cart.Any())
            {
                return RedirectToAction("Index", "Cart");
            }

            return View(cart);
        }

        [HttpPost]
        public IActionResult PlaceOrder()
        {
            var cart = _cart.GetCart();
            if (!cart.Any())
            {
                return RedirectToAction("Index", "Cart");
            }

            var order = new Order
            {
                TotalPrice = cart.Sum(i => i.Price * i.Quantity),
                Items = cart.Select(i => new OrderItem
                {
                    ProductId = i.ProductId,
                    ProductName = i.Name!,
                    Price = i.Price,
                    Quantity = i.Quantity
                }).ToList()
            };

            _context.Orders.Add(order);
            _context.SaveChanges();

            _cart.Clear();

            // TODO: dicrease items stock

            return RedirectToAction(nameof(Success), new { id = order.Id });
        }

        public IActionResult Success(int id)
        {
            return View(id);
        }
    }
}
