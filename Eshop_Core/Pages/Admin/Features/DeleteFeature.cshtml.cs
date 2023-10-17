using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Core.Services.Interfaces;
using DataLayer.Entities;

namespace Eshop_Core.Pages.Admin.Features
{
    public class DeleteFeatureModel : PageModel
    {
        private IFeatures _feature;

        public DeleteFeatureModel(IFeatures features)
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
