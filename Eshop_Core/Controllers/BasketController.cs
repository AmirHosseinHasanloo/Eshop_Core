using Microsoft.AspNetCore.Mvc;

namespace Eshop_Core.Controllers
{
    public class BasketController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
