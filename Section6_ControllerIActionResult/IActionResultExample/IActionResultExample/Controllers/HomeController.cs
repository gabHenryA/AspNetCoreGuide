using Microsoft.AspNetCore.Mvc;
using IActionResultExample.Models;

namespace IActionResultExample.Controllers
{
    public class HomeController : Controller
    {
        // URL: /book?bookid=10&isloggedin=true
        [Route("book/{bookid?}/{isloggedin?}")]
        public IActionResult Index(int? bookid, [FromRoute]bool? isloggedin, Book book)
        {
            if(bookid.HasValue == false)
            {
                //Response.StatusCode = 400;
                //return Content("Book id is not supplied");
                //return new BadRequestResult();
                return BadRequest("Book id is not supplied");
            }

            if (bookid <=0)
            {
                //Response.StatusCode = 400;
                //return Content("Book id can't be null or empty");
                return BadRequest("Book id can't be less then or equal zero");
            }

            if (bookid > 1000)
            {
                //Response.StatusCode = 400;
                //return Content("Book id can't be greater than 1000");
                return NotFound("Book id can't be greater than 1000");
            }

            if (isloggedin == false)
            {
                //Response.StatusCode = 401;
                //return Content("User must be authenticated");
                return Unauthorized("User must be authenticated");
            }

            //return File("/Ficha.pdf", "application/pdf");


            //return new RedirectToActionResult("Books", "Store", new { id = bookId}); // Found
            //return new RedirectToActionResult("Books", "Store", new { }, true); //Move Permanently
            //return RedirectToAction("Books", "Store", new { }); // Found
            //return RedirectToAction("Books", "Store", new { }, true); //Move Permanently

            //return new LocalRedirectResult($"store/books/{bookId}"); // Found
            //return new LocalRedirectResult($"store/books/{bookId}", true); //Move Permanently
            //return LocalRedirect($"store/books/{bookId}"); // Found
            //return LocalRedirectPermanent($"store/books/{bookId}"); //Move Permanently

            //return new RedirectResult($"store/books/{bookId}"); // Found
            //return new RedirectResult($"store/books/{bookId}", false); //Move Permanently
            //return Redirect($"store/books/{bookId}"); // Found

            //return RedirectPermanent($"store/books/{bookid}"); //Move Permanently

            return Content($"Book id: {bookid}, Book: {book}", "text/plan");
        }
    }
}
