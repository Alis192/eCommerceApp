using eCommerceApp.CustomValidators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation; //for custom validation
using System.ComponentModel.DataAnnotations; // set of predefined to add validation rules
using System.Collections.Generic; 

namespace eCommerceApp.Models
{
    public class Order
    {
        [BindNever]
        public int OrderNo { get; set; }

        
        [Required(ErrorMessage = "{0} can't be empty or null")] // TO DO: Add Proper DateTime validator
        [Range(typeof(DateTime), "2023/2/20", "2030/2/20", ErrorMessage = "Value for {0} must be between {1} and {2}")]
        public DateTime? OrderDate { get; set; }

        
        [Required(ErrorMessage = "{0} can't be empty or null")] //[InvoiceValidator]
        [InvoiceValidator("SumOfPrices", ErrorMessage = "InvoicePrice doesn't match with the total cost of the specified products in the order.\r\n\r\n")]
        [Range(0, 99999.99, ErrorMessage = "Range must be between 0 and 99999.99")]
        public double? InvoicePrice { get; set; }


        [BindNever]
        public double? SumOfPrices
        {
            get
            {
                return Products.Sum(p => p.TotalPrice);
            }
        }

        
        public List<Product> Products { get; set; } = new List<Product>();



        public Order() //constructor is called each time when Order instance is created
        {
            Random rand = new Random();
            OrderNo= rand.Next(99999);

        }
    }
}
