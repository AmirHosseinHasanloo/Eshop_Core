using Microsoft.AspNetCore.Mvc;

namespace Eshop_Core.Controllers
{
    public class testController : Controller
    {
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.True = "Yes";
            }

            return View();
        }
    }
}
