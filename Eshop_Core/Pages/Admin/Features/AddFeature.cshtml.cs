using Core.Services.Interfaces;
using DataLayer;
using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Eshop_Core.Pages.Admin.Products
{
    public class AddFeatureModel : PageModel
    {
        private IFeaturesService _feature;

        public AddFeatureModel(IFeaturesService features)
        {
            _feature = features;
        }

        [BindProperty]
        public Feature Features { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Insert & Save 
            _feature.AddFeature(Features);

            return RedirectToPage("Index");
        }
    }
}
