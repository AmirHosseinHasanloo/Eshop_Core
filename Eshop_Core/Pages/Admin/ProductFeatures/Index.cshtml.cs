using Core.DTOs;
using Core.Services;
using Core.Services.Interfaces;
using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Eshop_Core.Pages.Admin.ProductFeatures
{
    public class IndexModel : PageModel
    {
        IProductRepository _ProductRepository;

        public IndexModel(IProductRepository ProductRepository)
        {
            _ProductRepository = ProductRepository;
        }

        [BindProperty]
        public ProductFeature ProductFeature { get; set; }

        // id ==> Product Id
        public void OnGet(int id)
        {
            ViewData["Features"] = _ProductRepository.GetProductFeaturesByProductIdForAdmin(id);
            ViewData["FeatureId"] = new SelectList(_ProductRepository.GetAllFeatures(), "FeatureId", "FeatureTitle");
            ProductFeature = new ProductFeature()
            {
                ProductId = id,
            };
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _ProductRepository.AddProductFeature(ProductFeature);

            return RedirectToPage("Index", new { id = ProductFeature.ProductId });
        }

    }
}
