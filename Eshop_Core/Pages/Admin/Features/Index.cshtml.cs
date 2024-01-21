using System.Collections.Generic;
using System.Linq;
using Core.Services.Interfaces;
using DataLayer;
using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Eshop_Core.Pages.Admin.Features
{
    public class IndexModel : PageModel
    {

        IFeaturesService _features;

        public IndexModel(IFeaturesService features)
        {
            _features = features;
        }


        [BindProperty]
        public IEnumerable<Feature> Features { get; set; }
        public void OnGet()
        {
            Features = _features.GetAllFeatures();
        }
    }
}
