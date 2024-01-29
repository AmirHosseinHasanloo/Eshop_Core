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
            if (!User.Identity.IsAuthenticated)
            {
                return null;
            }
            return View(_orderService.GetOrdersForUserInPayment(User.Identity.Name));
        }

        public IActionResult AddOrder(int id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return null;
            }

            _orderService.AddOrder(User.Identity.Name, id);

            return PartialView("ListOrder", _orderService.GetOrdersForUserInBasket(User.Identity.Name));
        }

        public IActionResult ListOrder()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return null;
            }
            return PartialView(_orderService.GetOrdersForUserInBasket(User.Identity.Name));
        }

        public IActionResult UpdatePriceByCount(int id, int count)
        {
            //id = orderDetailId
            if (!User.Identity.IsAuthenticated)
            {
                return null;
            }
            _orderService.UpdateOrderDetailPrice(id, count, User.Identity.Name);
            return PartialView("Index", _orderService.GetOrdersForUserInPayment(User.Identity.Name));
        }

        public IActionResult DeleteOrderDetial(int id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return null;
            }

            _orderService.DeleteOrderDetail(id, User.Identity.Name);
            return PartialView("Index", _orderService.GetOrdersForUserInPayment(User.Identity.Name));
        }


        public IActionResult Payment()
        {
            //TODO Pay Order and close it !
            // First check user details is complete !
            // Then pay and Product Seller send it !
            return null;
        }
    }
}
