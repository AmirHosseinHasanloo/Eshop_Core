using DataLayer.Models;
using DataLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Eshop_Core.Pages.Admin.Features
{
    public class EditFeatureModel : PageModel
    {
        private UnitOfWork _unit;

        public EditFeatureModel(EshopContext context)
        {
            _unit = new UnitOfWork(context);
        }

        [BindProperty]
        public Feature Features { get; set; }
        public void OnGet(int id)
        {
            Features = _unit.FeaturesRepository.GetById(id);
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Insert & Save 
            _unit.FeaturesRepository.Update(Features);
            _unit.FeaturesRepository.Save();

            return RedirectToPage("Index");
        }
    }
}
