using System.ComponentModel.DataAnnotations;

namespace BoughtAndHappy.Data
{
    public class Product
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [Display(Name = "Price, $")]
        [Required, Range(0, 999999)]
        public decimal Price { get; set; }

        [Required]
        public ProductCategories Category { get; set; }

        [Display(Name = "Stock, pcs")]
        [Required, Range(0, int.MaxValue)]
        public int Stock { get; set; }
    }
}
