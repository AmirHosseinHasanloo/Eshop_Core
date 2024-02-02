using Core.Services.Interfaces;
using DataLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Eshop_Core.Controllers
{
    public class BasketController : Controller
    {
        private IOrderService _orderService;
        private IProductService _productService;
        private IUsersService _userService;

        public BasketController(IOrderService orderService, IProductService productService, IUsersService usersService)
        {
            _orderService = orderService;
            _productService = productService;
            _userService = usersService;

        }

        public IActionResult Index(string IsSuccess = "")
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Redirect("/Account/Login");
            }
            if (IsSuccess != "")
            {
                ViewBag.IsSuccess = true;
            }

            var orderDetails = _orderService.GetOrdersForUserInPayment(User.Identity.Name);

            ViewBag.OrderId = _orderService.GetUsersOpenOrderId(User.Identity.Name);

            return View(orderDetails);
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


        [Route("Payment/{id}")]
        public IActionResult Payment(int id)
        {
            // id ==> orderId
            if (!User.Identity.IsAuthenticated)
            {
                return Redirect("/Account/Login");
            }

            if (!_orderService.CheckIsUserAllowToPay(User.Identity.Name))
            {
                return RedirectToAction("CompleteUserIdentity");
            }
            //TODO Pay Order and close it !
            // First check user details is complete !
            // Then pay and Product Seller send it !

            #region Online Payment

            var order = _orderService.GetOrderForPayment(id);

            var payment = new ZarinpalSandbox.Payment(order.OrderSum);

            var result = payment.PaymentRequest("خرید محصول", "https://localhost:5001/Basket/OnlinePayment/" + order.OrderId,
                "amirhosseinhasanloo2050@gmail.com", "09223334678");


            if (result.Result.Status == 100)
            {
                return Redirect("https://sandbox.zarinpal.com/pg/StartPay/" + result.Result.Authority);
            }

            #endregion

            return null;
        }

        public IActionResult OnlinePayment(int id)
        {
            if (HttpContext.Request.Query["Status"] != "" &&
              HttpContext.Request.Query["Status"].ToString().ToLower() == "ok"
              && HttpContext.Request.Query["Authority"] != "")
            {
                string authority = HttpContext.Request.Query["Authority"];

                var order = _orderService.GetOrderForPayment(id);

                var payment = new ZarinpalSandbox.Payment(order.OrderSum);
                var res = payment.Verification(authority).Result;
                if (res.Status == 100)
                {
                    ViewBag.code = res.RefId;
                    ViewBag.IsSuccess = true;
                    order.IsFainaly = true;
                    _orderService.UpdateOrder(order);
                }

            }
            return View();
        }

        public IActionResult CompleteUserIdentity()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Redirect("/Account/Login");
            }

            var user = _userService.GetUserByUserName(User.Identity.Name);
            return View(user);
        }

        [HttpPost]
        public IActionResult CompleteUserIdentity(User user)
        {
            _userService.EditUser(user);
            return Redirect("/Basket/Index?IsSuccess=true");
        }
    }
}
