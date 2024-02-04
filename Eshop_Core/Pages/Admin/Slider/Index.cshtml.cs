using Core.Services.Interfaces;
using DataLayer.Entities;
using Eshop_Core.RoleChecker;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace Eshop_Core.Pages.Admin.Slider
{
    [RoleChecker(new int[] {1})]
    public class IndexModel : PageModel
    {
        private ISliderService _sliderService;

        public IndexModel(ISliderService sliderservice)
        {
            _sliderService = sliderservice;
        }

        [BindProperty]
        public IEnumerable<DataLayer.Entities.Slider> Sliders { get; set; }

        public void OnGet()
        {
            Sliders = _sliderService.GetAllSliders(); 
        }
    }
}
