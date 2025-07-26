using Microsoft.AspNetCore.Mvc;

namespace ExerciseController.Controllers
{
    public class BankController : Controller
    {
        [HttpGet("/")]
        public IActionResult Home()
        {
            return Content("Welcome to the Best Bank");
        }

        [HttpGet("/account-details")]
        public IActionResult Details()
        {
            return Json(new { accountNumber = 1001, accountHolderName = "ExampleName", currentBalance = 5000 });
        }

        [HttpGet("/account-statement")]
        public IActionResult Statement()
        {
            return File("BANK.pdf", "application/pdf");
        }

        [HttpGet("/get-current-balance/{accountNumber:int?}")]
        public IActionResult CurrentBalance()
        {
            if(!Request.RouteValues.ContainsKey("accountNumber"))
            {
                return NotFound("Account number should be supplied");
            }

            int accountNumber = Convert.ToInt32(Request.RouteValues["accountNumber"]);

            if(accountNumber != 1001)
            {
                return BadRequest("Account Number should be 1001");
            }
            return Content("5000");
        }
    }   
}
