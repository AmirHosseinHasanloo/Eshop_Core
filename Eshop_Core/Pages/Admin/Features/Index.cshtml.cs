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

        IFeatures _features;

        public IndexModel(IFeatures features)
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
