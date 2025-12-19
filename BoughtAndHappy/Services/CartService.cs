using BoughtAndHappy.Data;
using BoughtAndHappy.Data.Models;

namespace BoughtAndHappy.Services
{
    public class CartService
    {
        private const string CartKey = "CART";

        private readonly IHttpContextAccessor _httpContextAccessor;

        public CartService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        private ISession Session => _httpContextAccessor.HttpContext!.Session;

        public List<CartItem> GetCart()
        {
            return Session.GetObject<List<CartItem>>(CartKey) ?? new();
        }

        private void SaveCart(List<CartItem> cart)
        {
            Session.SetObject(CartKey, cart);
        }

        public void AddToCart(Product product)
        {
            var cart = GetCart();

            var item = cart.FirstOrDefault(p => p.ProductId == product.Id);

            if (item == null)
            {
                cart.Add(new CartItem
                {
                    ProductId = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Quantity = 1
                });
            }
            else
            {
                item.Quantity++;
            }

            SaveCart(cart);
        }

        public void Increase(int productId)
        {
            var cart = GetCart();
            var item = cart.FirstOrDefault(p => p.ProductId == productId);
            if (item != null)
            {
                item.Quantity++;
                SaveCart(cart);
            }
        }

        public void Decrease(int productId)
        {
            var cart = GetCart();
            var item = cart.FirstOrDefault(p => p.ProductId == productId);
            if (item != null)
            {
                item.Quantity--;
                if (item.Quantity <= 0)
                {
                    cart.Remove(item);
                }
                SaveCart(cart);
            }
        }

        public void UpdateQuantity(int productId, int quantity)
        {
            var cart = GetCart();
            var item = cart.FirstOrDefault(i => i.ProductId == productId);

            if (item != null)
            {
                if (item.Quantity <= 0)
                {
                    cart.Remove(item);
                }
                else
                {
                    item.Quantity = quantity;
                }
                SaveCart(cart);
            }
        }

        public int TotalItems() => GetCart().Sum(p => p.Quantity);

        public decimal TotalPrice() => GetCart().Sum(p => p.Price * p.Quantity);

        public void RemoveFromCart(int productId)
        {
            var cart = GetCart();
            cart.RemoveAll(p => p.ProductId == productId);
            Session.SetObject(CartKey, cart);
        }

        public void Clear()
        {
            Session.Remove(CartKey);
        }
    }
}
