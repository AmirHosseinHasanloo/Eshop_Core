using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Models;
using DataLayer.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Eshop_Core.Pages.Admin.Products
{
    public class AddModel : PageModel
    {
        private EshopContext _context;

        private IProductRepository _product;
        public AddModel(EshopContext context, IProductRepository product)
        {
            _context = context;
            _product = product;
        }
        public void OnGet()
        {
            ViewData["Groups"] = _context.ProductGroups.ToList();
        }

        [BindProperty]
        public Product Product { get; set; }
        public IActionResult OnPost(List<int> selectedGroups, string Tags)
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


            // add Product Tags
            _product.AddProductTags(Product.ProductId, Tags);

            // add Selected groups
            _product.AddProductSelectedGroups(Product.ProductId, selectedGroups);

            //TODO : Add Image & Product To DataBase


            return RedirectToPage("Index");
        }
    }
}
