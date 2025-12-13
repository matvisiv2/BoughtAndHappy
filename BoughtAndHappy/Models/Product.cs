using System.ComponentModel.DataAnnotations;

namespace BoughtAndHappy.Models
{
    public enum ProductCategories
    {

        [Display(Name = "Electronics")]
        Electronics,

        [Display(Name = "Clothing")]
        Clothing,

        [Display(Name = "Home goods")]
        HomeGoods,

        [Display(Name = "Books")]
        Books,

        [Display(Name = "Toys")]
        Toys,

        [Display(Name = "Groceries")]
        Groceries,

        [Display(Name = "Health and beauty")]
        HealthAndBeauty,

        [Display(Name = "Sports and outdoors")]
        SportsAndOutdoors,

        [Display(Name = "Automotive")]
        Automotive,

        [Display(Name = "Computers and Laptops")]
        ComputersAndLaptops,

        [Display(Name = "Others")]
        Others
    }

    public class Product
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [Required, Range(0, 999999)]
        public decimal Price { get; set; }

        [Required]
        public ProductCategories Category { get; set; }

        [Required, Range(0, int.MaxValue)]
        public int Stock { get; set; }
    }
}
