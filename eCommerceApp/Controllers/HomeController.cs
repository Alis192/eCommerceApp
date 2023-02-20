using eCommerceApp.Models;
using Microsoft.AspNetCore.Mvc;


namespace eCommerceApp.Controllers
{
    public class HomeController : Controller
    {
        [Route("order")]
        public IActionResult Index( Order order) //order instance is automatically created by application after sending data
        {
            if (!ModelState.IsValid) //if validations are not meet 
            {
                //get error messages from model state
                string errors = string.Join("\n", ModelState.Values.SelectMany(value => value.Errors).Select(err => err.ErrorMessage)); // all the errors are collected here

                return BadRequest(errors); 
            }

            //return Content($"{order}");
            return Json(order);

        }
    }
}
