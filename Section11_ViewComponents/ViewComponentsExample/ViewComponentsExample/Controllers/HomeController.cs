using Microsoft.AspNetCore.Mvc;
using ViewComponentsExample.Models;

namespace ViewComponentsExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("about")]
        public IActionResult About()
        {
            return View();
        }

        [Route("friends-list")]
        public IActionResult LoadFriendsList()
        {
            PersonGridModel personGridModel = new PersonGridModel()
            {
                GridTitle = "Friends",
                Persons = new List<Person>()
                {
                    new Person() { PersonName = "Paul", JobTitle = "Developer" },
                    new Person(){ PersonName = "Peter", JobTitle = "UI Designer" },
                    new Person(){ PersonName = "Raphael", JobTitle = "QA" }
                }
            };

            return ViewComponent("Grid", new { grid = personGridModel });
        }
    }
}
