using Core.Services.Interfaces;
using DataLayer;
using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

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
        public async Task<IActionResult> ShowProductPage(int id)
        {
            ViewBag.FeaturesTitle = _Product.GetProductFeaturesByProductIdForShowingPage(id);
            return View(id);
        }

        public IActionResult ShowComments(int id)
        {
            return PartialView(_Product.GetProductCommentsByProductId(id));
        }

        public IActionResult AddComments(int id)
        {
            return PartialView(new ProductComments
            {
                ParentId = id
            });
        }

        [HttpPost]
        public IActionResult AddComments(int ProductId ,int ParentId, string UserName, string Email, string Website, string Comment)
        {
            return PartialView();
        }
    }
}
