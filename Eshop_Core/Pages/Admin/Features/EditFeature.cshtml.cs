using DataLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DataLayer.Entities;
using Core.Services.Interfaces;

namespace Eshop_Core.Pages.Admin.Features
{
    public class EditFeatureModel : PageModel
    {

        private IFeatures _feature;

        public EditFeatureModel(IFeatures features)
        {
            _feature = features;
        }

        [BindProperty]
        public Feature Features { get; set; }
        public void OnGet(int id)
        {
            Features = _feature.GetFeatureById(id);
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Update & Save 
            _feature.EditFeature(Features);
            return RedirectToPage("Index");
        }
    }
}
