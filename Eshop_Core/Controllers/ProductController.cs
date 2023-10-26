using Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Eshop_Core.Controllers
{
    public class ProductController : Controller
    {
        IProductRepository _ProductRepository;

        public ProductController(IProductRepository ProductRepository)
        {
            _ProductRepository = ProductRepository;
        }

        public IActionResult ShowLastProducts()
        {
            return PartialView(_ProductRepository.Get24OfNewProducts());
        }
    }
}
