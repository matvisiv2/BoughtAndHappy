using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoughtAndHappy.Data.Models
{
    public class OrderItem
    {
        public int Id { get; set; }

        [Required]
        public int OrderId { get; set; }

        [ForeignKey(nameof(OrderId))]
        public Order Order { get; set; } = null!;

        [Required]
        public int ProductId { get; set; }

        [DisplayName("Name")]
        [Required, MaxLength(100)]
        public string ProductName { get; set; } = null!;

        [DisplayName("Price, $")]
        [Required]
        public decimal Price { get; set; }

        [DisplayName("Quantity, pcs")]
        [Required]
        public int Quantity { get; set; }
    }
}
