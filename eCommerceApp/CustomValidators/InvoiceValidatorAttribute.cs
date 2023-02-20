using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace eCommerceApp.CustomValidators
{
    public class InvoiceValidatorAttribute : ValidationAttribute
    {
        public string ProductPrices { get; set; } // we create a property
         public InvoiceValidatorAttribute(string productPrices) // we make a constructor
         {
             this.ProductPrices = productPrices; //in this constructor we get string value of 'SumOfPrices' in Order class which is noted inside InvoiceValidator. The first argument
        }

         protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
         {
             if (value  != null)
             {
                 Double invoicePrice = (Double)value; // we convert value from request to double. Since we work with double in this property

                PropertyInfo? product = validationContext.ObjectType.GetProperty(ProductPrices); // we access Property information of ProductPrices which also inherits data from productPrices which is also equal 'SumOfPrices' in our case 

                if (product != null) // if the property is not null, it means if we gave a value for it 
                {
                    Double fetchedValue = Convert.ToDouble(product.GetValue(validationContext.ObjectInstance)); //then we extract the actually wanted data product 
                   
                    if (invoicePrice != fetchedValue) // we compare both local and external values 
                    {
                        return new ValidationResult(ErrorMessage); // if they are not equal we send error message to controller
                    }
                    else
                    {
                        return ValidationResult.Success; // else we send success to class model and we continue with the next property
                    }
                }
                return null; // in this case product = null. which means we haven't given any value for it. So we don't need to execuate this validation
             }
            return null; //same applies here

        }
    }
}
