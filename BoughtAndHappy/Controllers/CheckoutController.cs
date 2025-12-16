using BoughtAndHappy.Data;
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

            // stock check  and place order
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                // get all products
                var productsIds = cart.Select(i => i.ProductId).ToList();

                var products = _context.Products
                    .Where(p => productsIds.Contains(p.Id))
                    .ToList();

                // stock check
                foreach (var item in cart)
                {
                    var product = products.First(p => p.Id == item.ProductId);

                    if (product.Stock < item.Quantity)
                    {
                        ModelState.AddModelError(string.Empty, $"Not enough stock for {product.Name}");
                        return View("Index", cart);
                    }
                }

                // decrease stock
                foreach (var item in cart)
                {
                    var product = products.First(p => p.Id == item.ProductId);
                    product.Stock -= item.Quantity;
                }

                // place order
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

                // save new stock data and new order
                _context.SaveChanges();
                transaction.Commit();

                _cart.Clear();

                return RedirectToAction(nameof(Success), new { id = order.Id });
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public IActionResult Success(int id)
        {
            return View(id);
        }
    }
}
