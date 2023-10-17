using Core.Services.Interfaces;
using DataLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.MinimalApi;
using System.Collections.Generic;

namespace Eshop_Core.Pages.Admin.Products
{
    public class EditModel : PageModel
    {
        #region Injection

        private IProductGroupRepository _productGroup;
        private IProductRepository _product;
        public EditModel(IProductGroupRepository productGroup, IProductRepository product)
        {
            _productGroup = productGroup;
            _product = product;
        }

        #endregion

      
        public void OnGet(int id)
        {
            // Show Tags In Edit Page
            ViewData["Tags"] = _product.GetTagsForShowingInEditProductOnAdmin(id);

            // Show ProductGroups In Edit Page
            ViewData["Groups"] = _productGroup.GetAllGroups();

            // Show SelectedGroups In Edit Page
            ViewData["SelectedGroups"] = _product.GetAllProductGroups(id);

            Product = _product.GetProductById(id);
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

            //Update Product
            _product.UpdateProduct(Product, selectedGroups, Tags, ImageUP);

            return RedirectToPage("Index");
        }

    }
}
