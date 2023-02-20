using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace eCommerceApp.Models
{
    public class Product
    {
        [Required(ErrorMessage = "{0} can't be empty or null")]
        [Range(0, 100, ErrorMessage = "Range must be between 0 and 100")]
        public int ProductCode { get; set; }


        [Required(ErrorMessage = "{0} can't be empty or null")]
        [Range(0, 599.99, ErrorMessage = "Range must be between 0 and 599.99")]
        public double? Price { get; set; }


        [Required(ErrorMessage = "{0} can't be empty or null")]
        [Range(1,50, ErrorMessage = "You can order at least 1 and maximum 50 quantity")]
        public int Quantity { get; set; }

        [BindNever] 
        public double? TotalPrice
        {
            get
            {
                return Price * Quantity;
            }
        } 

    }
}
