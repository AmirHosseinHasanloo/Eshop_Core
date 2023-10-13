using DataLayer;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Eshop_Core.Pages.Admin.Products
{
    public class AddFeatureModel : PageModel
    {
        private UnitOfWork _unit;

        public AddFeatureModel(EshopContext context)
        {
            _unit = new UnitOfWork(context);
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
            _unit.FeaturesRepository.Insert(Features);
            _unit.FeaturesRepository.Save();

            return RedirectToPage("Index");
        }
    }
}
