using System.ComponentModel.DataAnnotations;

namespace BoughtAndHappy.Data
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
}
