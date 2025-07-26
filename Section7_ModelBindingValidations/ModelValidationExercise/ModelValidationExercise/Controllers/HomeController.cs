using System;
using Microsoft.AspNetCore.Mvc;
using ModelValidationExercise.Models;

namespace ModelValidationExercise.Controllers
{
    public class HomeController : Controller
    {
        [Route("order")]
        public IActionResult Index([Bind(nameof(order.OrderDate), nameof(order.Products), nameof(order.InvoicePrice))] Order order)
        {
            if(ModelState.IsValid == false)
            {
                string errors = string.Join("\n", ModelState.Values.SelectMany((values) => values.Errors).Select((errors) => errors.ErrorMessage));

                return BadRequest(errors);
            }

            Random random = new Random();
            int randomNumber  = random.Next(1, 99999);
            order.OrderNo = randomNumber;

            return Json(new { ordernumber = randomNumber });
        }
    }
}
