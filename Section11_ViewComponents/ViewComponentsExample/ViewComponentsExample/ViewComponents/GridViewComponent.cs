using Microsoft.AspNetCore.Mvc;
using ViewComponentsExample.Models;

namespace ViewComponentsExample.ViewComponents
{
    [ViewComponent]
    public class GridViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(PersonGridModel grid)
        {
            ViewData["Grid"] = grid;

            return View("Sample", grid); // invoked a partial view in Views/Shared/Components/Grid/Default.cshtml
        }
    }
}
