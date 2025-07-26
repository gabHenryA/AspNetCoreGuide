using Microsoft.AspNetCore.Mvc;
using ModelValidationsExample.CustomModelBinders;
using ModelValidationsExample.Models;

namespace ModelValidationsExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("register")]
        public IActionResult Index(/*[Bind(nameof(Person.PersonName), nameof(Person.Email), nameof(Person.Password), nameof(Person.ConfirmPassword))]*/ /*[FromBody]*/ /*[ModelBinder(BinderType = typeof(PersonModelBinder))] */ Person person, [FromHeader(Name = "User-Agent")] string UserAgent)
        {
            if(ModelState.IsValid == false)
            {
                //List<string> errorList = new List<string>();
                //foreach(var value in ModelState.Values)
                //{
                //    foreach(var error in value.Errors)
                //    {
                //        errorList.Add(error.ErrorMessage);
                //    }
                //}

                //string errors = string.Join("\n", errorList);
                //return BadRequest(errors);

                string errors = string.Join("\n", ModelState.Values.SelectMany(values => values.Errors).Select(errors => errors.ErrorMessage));

                return BadRequest(errors);
            }
            return Content($"{person}, {UserAgent}");
        }
    }
}
