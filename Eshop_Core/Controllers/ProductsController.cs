using Core.Services.Interfaces;
using DataLayer;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Eshop_Core.Controllers
{
    public class ProductsController : Controller
    {
        IProductRepository _Product;

        public ProductsController(IProductRepository Product)
        {
            _Product = Product;
        }

        [Route("Product/{id}")]
        public IActionResult ShowProductPage(int id)
        {
            ViewBag.FeaturesTitle = _Product.GetProductFeaturesByProductIdForShowingPage(id);
            return View(_Product.GetProductById(id));
        }
    }
}
