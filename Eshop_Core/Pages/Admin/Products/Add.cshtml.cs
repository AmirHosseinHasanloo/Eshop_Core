using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Services.Interfaces;
using DataLayer;
using DataLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Eshop_Core.Pages.Admin.Products
{
    public class AddModel : PageModel
    {
        private IProductGroupRepository _productGroup;
        private IProductRepository _product;
        public AddModel(IProductGroupRepository productGroup, IProductRepository product)
        {
            _productGroup = productGroup;
            _product = product;
        }
        public void OnGet()
        {
            ViewData["Groups"] = _productGroup.GetAllGroups();
        }

        [BindProperty]
        public Product Product { get; set; }
        public IActionResult OnPost(List<int> selectedGroups, string Tags, IFormFile ImageUP)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (selectedGroups == null || string.IsNullOrEmpty(Tags))
            {
                ViewData["Error"] = "false";
                return Page();
            }

            // Save Product
            _product.AddProduct(Product, selectedGroups, Tags, ImageUP);

            return RedirectToPage("Index");
        }
    }
}
