using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Core.Services.Interfaces;
using DataLayer.Entities;
using Eshop_Core.RoleChecker;

namespace Eshop_Core.Pages.Admin.Features
{
    [RoleChecker(new int[] { 1 })]
    public class DeleteFeatureModel : PageModel
    {
        private IFeaturesService _feature;

        public DeleteFeatureModel(IFeaturesService features)
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
            // Insert & Save 
            _feature.DeleteFeature(Features);

            return RedirectToPage("Index");
        }
    }
}
