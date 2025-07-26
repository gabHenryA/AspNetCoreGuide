using Microsoft.AspNetCore.Mvc;
using ControllersExample.Models;

namespace ControllersExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("sayhello")]
        public string method1()
        {
            return "Hello from method 1";
        }

        [Route("/")]
        public ContentResult Index()
        {
            //return new ContentResult() { Content = "Hello from Index", ContentType = "text/plain" };
            return Content("<h1>Welcome</h1> <h2>Hello from Index</h2>", "text/html");
        }

        [Route("person")]
        public JsonResult Person()
        {
            Person person = new Person()
            {
                Id = Guid.NewGuid(),
                FirstName = "Peter",
                LastName = "Parker",
                Age = 19
            };
            //return new JsonResult(person);
            return Json(person);
        }

        [Route("file-download1")]
        public VirtualFileResult FileDownload1()
        {
            //return new VirtualFileResult("/Ficha.pdf", "application/pdf");
            return File("/Ficha.pdf", "application/pdf");
        }

        [Route("file-download2")]
        public PhysicalFileResult FileDownload2()
        {
            //return new PhysicalFileResult(@"C:\Users\smo computadores\Documents\PDE\Programação\CSHARP\AspNetCore9Udemy\ControllersExample\ControllersExample\Ficha.pdf", "application/pdf");
            return PhysicalFile(@"C:\Users\smo computadores\Documents\PDE\Programação\CSHARP\AspNetCore9Udemy\ControllersExample\ControllersExample\Ficha.pdf", "application/pdf");
        }

        [Route("file-download3")]
        public FileContentResult FileDownload3()
        {
            byte[] bytes = System.IO.File.ReadAllBytes(@"C:\Users\smo computadores\Documents\PDE\Programação\CSHARP\AspNetCore9Udemy\ControllersExample\ControllersExample\Ficha.pdf");
            //return new FileContentResult(bytes, "application/pdf");
            return File(bytes, "application/pdf");
        }
    }
}
