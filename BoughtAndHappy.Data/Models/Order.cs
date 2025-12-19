using System.ComponentModel.DataAnnotations;

namespace BoughtAndHappy.Data.Models
{
    public class Order
    {
        public int Id { get; set; }

        public string? UserId { get; set; } = null;

        public ApplicationUser User { get; set; } = null;
        
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public decimal TotalPrice { get; set; }

        public List<OrderItem> Items { get; set; } = new();

        public OrderStatus Status { get; set; } = OrderStatus.New;
    }
}
