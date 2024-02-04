using DataLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DataLayer.Entities;
using Core.Services.Interfaces;
using Eshop_Core.RoleChecker;

namespace Eshop_Core.Pages.Admin.Features
{
    [RoleChecker(new int[] { 1 })]
    public class EditFeatureModel : PageModel
    {

        private IFeaturesService _feature;

        public EditFeatureModel(IFeaturesService features)
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
