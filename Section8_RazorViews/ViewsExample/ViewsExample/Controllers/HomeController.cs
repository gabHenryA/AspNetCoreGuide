using Microsoft.AspNetCore.Mvc;
using ViewsExample.Models;

namespace ViewsExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("home")]
        [Route("/")]
        public IActionResult Index()
        {
            ViewData["appTitle"] = "Asp.Net Core Demo app";

            List<Person> people = new List<Person>()
            {
                new Person(){
                    Name = "Peter",
                    DateOfBirth = DateTime.Parse("2000-05-06"),
                    PersonGender = Gender.Male
                },
                new Person(){
                    Name = "May",
                    DateOfBirth = DateTime.Parse("1978-09-06"),
                    PersonGender = Gender.Female
                },
                new Person(){
                    Name = "Ben",
                    DateOfBirth = DateTime.Parse("1975-12-18"),
                    PersonGender = Gender.Male
                }
            };

            //ViewData["people"] = people;
            ViewBag.people = people;

            return View("Index", people); //Views/Home/Index.cshtml
            //return View("abc"); //Views/Home/abc.cshtml
            //return new ViewResult() { ViewName = "abc" };
        }

        [Route("person-details/{name}")]
        public IActionResult Details(string? name)
        {
            if(name == null)
            {
                return Content("Person name can't be null");
            }

            List<Person> people = new List<Person>()
            {
                new Person(){
                    Name = "Peter",
                    DateOfBirth = DateTime.Parse("2000-05-06"),
                    PersonGender = Gender.Male
                },
                new Person(){
                    Name = "May",
                    DateOfBirth = DateTime.Parse("1978-09-06"),
                    PersonGender = Gender.Female
                },
                new Person(){
                    Name = "Ben",
                    DateOfBirth = DateTime.Parse("1975-12-18"),
                    PersonGender = Gender.Male
                }
            };

            Person? matchingPerson = people.Where((temp) => temp.Name == name).FirstOrDefault();
            return View(matchingPerson); // View/Home/Details.cshtml
        }

        [Route("/person-with-product")]
        public IActionResult PersonWithProduct()
        {
            Person person = new Person()
            {
                Name = "Joseph",
                PersonGender = Gender.Male,
                DateOfBirth = Convert.ToDateTime("1924-07-01")
            };

            Product product = new Product()
            {
                ProductId = 1,
                ProductName = "Thompson"
            };

            PersonWithProductWrapperModel personWithProductWrapperModel = new PersonWithProductWrapperModel()
            {
                PersonData = person,
                ProductData = product
            };

            return View(personWithProductWrapperModel);
        }

        [Route("home/all-products")]
        public IActionResult All()
        {
            return View();
            // Views/Home/All.cshtml
            // Views/Shared/All.cshtml
        }
    }
}
