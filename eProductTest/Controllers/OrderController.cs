using eProductTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace eProductTest.Controllers
{
    public class OrderController : Controller
    {
        public ViewResult Checkout() => View(new Order());

        public IActionResult Index()
        {
            return View();
        }
    }
}
