using Core.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Eshop_Core.Controllers
{
    public class BasketController : Controller
    {
        private IOrderService _orderService;
        private IProductService _productService;

        public BasketController(IOrderService orderService, IProductService productService)
        {
            _orderService = orderService;
            _productService = productService;

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddOrder(int id)
        {

            _orderService.AddOrder(User.Identity.Name, id);

            return PartialView("ListOrder", _orderService.GetOrdersForUserInBasket(User.Identity.Name));
        }

        public IActionResult ListOrder()
        {
            return PartialView(_orderService.GetOrdersForUserInBasket(User.Identity.Name));
        }
    }
}
