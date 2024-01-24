using Core.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection.Metadata.Ecma335;

namespace Eshop_Core.Pages.Admin.Slider
{
    public class CreateModel : PageModel
    {

        private ISliderService _sliderService;

        public CreateModel(ISliderService sliderservice)
        {
            _sliderService = sliderservice;
        }

        [BindProperty]
        public DataLayer.Entities.Slider slider { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost(IFormFile slide)
        {
            if (!ModelState.IsValid)
                return Page();

            _sliderService.AddSlider(slider, slide);

            return RedirectToPage("Index");
        }
    }
}
