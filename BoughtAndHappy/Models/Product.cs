using System.ComponentModel.DataAnnotations;

namespace BoughtAndHappy.Models
{
    public enum ProductCategory
    {
        Electronics,
        Clothing,
        HomeGoods,
        Books,
        Toys,
        Groceries,
        HealthAndBeauty,
        SportsAndOutdoors,
        Automotive,
        Others
    }

    public class Product
    {
        public int? Id { get; set; }

        [Required, MaxLength(100)]
        public string? Name { get; set; }

        [Required]
        public decimal? Price { get; set; }

        public ProductCategory? Category { get; set; }

        [Required]
        public int? Stock { get; set; }
    }
}
