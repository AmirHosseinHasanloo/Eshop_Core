using Core.Services.Interfaces;
using DataLayer;
using DataLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eshop_Core.Controllers
{
    public class ProductsController : Controller
    {
        IProductService _ProductService;
        IProductGroupService _ProductGroupService;
        public ProductsController(IProductService Product, IProductGroupService ProductGroupService)
        {
            _ProductService = Product;
            _ProductGroupService = ProductGroupService;
        }

        [Route("Product/{id}")]
        public IActionResult ShowProductPage(int id)
        {
            ViewBag.FeaturesTitle = _ProductService.GetProductFeaturesByProductIdForShowingPage(id);
            return View(id);
        }

        [HttpPost]
        public IActionResult CreateComment(ProductComments comment)
        {
            if (User.Identity.IsAuthenticated)
            {
                _ProductService.AddProductComment(comment, User.Identity.Name);
            }
            return PartialView("ShowComments", _ProductService.GetCommentsForProduct(comment.ProductId));
        }

        public IActionResult ShowComments(int id, int pageId = 1)
        {
            return PartialView(_ProductService.GetCommentsForProduct(id, pageId));
        }

        public IActionResult FilterProduct(int pageId = 1, string title = "", int startPrice = 0, int endPrice = 0
            , List<int> selectedGroups = null, int take = 24)
        {
            ViewBag.ProductTitle = title;
            ViewBag.PageId = pageId;
            ViewBag.startPrice = startPrice;
            ViewBag.endPrice = endPrice;
            ViewBag.selectedGroups = selectedGroups;
            ViewBag.take = take;
            ViewBag.ProductGroups = _ProductGroupService.GetAllGroups();

            return View(_ProductService.FilterProduct(pageId, title, startPrice, endPrice, selectedGroups, take));
        }

        [Route("Search")]
        public IActionResult Search(string q)
        {
            ViewBag.q = q;
            return View(_ProductService.Search(q));
        }


    }
}
