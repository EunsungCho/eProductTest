using eProductTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace eProductTest.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private IDataRepository repository;
        public NavigationMenuViewComponent(IDataRepository repo)
        {
            repository = repo;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];

            return View(repository.Products.
                Select(p => p.Category)
                .Distinct()
                .OrderBy(p => p));
        }
    }
}
