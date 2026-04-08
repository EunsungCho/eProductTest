using eProductTest.Infrastructure;
using eProductTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace eProductTest.Pages
{
    public class CartModel : PageModel
    {
        private IDataRepository repository;

        public CartModel(IDataRepository repo)
        {
            repository = repo;
        }

        public Cart? Cart { get; set; }
        public string ReturnUrl { get; set; } = "/";

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }

        public IActionResult OnPost(long productId, string returnUrl)
        {
            Product? product = repository.Products.FirstOrDefault(p => p.ProductID == productId);
            if(product != null)
            {
                Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
                Cart.AddItem(product, 1);
                HttpContext.Session.SetJson("cart", Cart);
            }
            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}
