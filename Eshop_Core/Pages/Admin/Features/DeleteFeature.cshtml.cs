using DataLayer.Models;
using DataLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Eshop_Core.Pages.Admin.Features
{
    public class DeleteFeatureModel : PageModel
    {
        private UnitOfWork _unit;

        public DeleteFeatureModel(EshopContext context)
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
            // Insert & Save 
            _unit.FeaturesRepository.Delete(Features);
            _unit.FeaturesRepository.Save();

            return RedirectToPage("Index");
        }
    }
}
