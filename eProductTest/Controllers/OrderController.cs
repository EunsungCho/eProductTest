using eProductTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace eProductTest.Controllers
{
    public class OrderController : Controller
    {
        private IOrderRepository _orderRepository;
        private Cart _cart;

        public OrderController(IOrderRepository orderRepository, Cart cartService)
        {
            _orderRepository = orderRepository;
            _cart = cartService;
        }

        public ViewResult Checkout() => View(new Order());

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            if (_cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }
            if (ModelState.IsValid)
            {
                order.Lines = _cart.Lines;
                _orderRepository.SaveOrder(order);
                _cart.Clear();
                return RedirectToPage("/Completed", new { orderId = order.OrderId });
            } else
            {
                return View(order);
                //return View();
            }
        }
    }
}
