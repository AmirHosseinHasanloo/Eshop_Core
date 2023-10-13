using System.Collections.Generic;
using System.Linq;
using DataLayer;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Eshop_Core.Pages.Admin.Features
{
    public class IndexModel : PageModel
    {
        private UnitOfWork _unit;

        public IndexModel(EshopContext context)
        {
            _unit = new UnitOfWork(context);
        }

        [BindProperty]
        public List<Feature> Features { get; set; }
        public void OnGet()
        {
            Features = _unit.FeaturesRepository.GetAll().ToList();
        }
    }
}
