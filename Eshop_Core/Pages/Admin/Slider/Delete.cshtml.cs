using Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Eshop_Core.Pages.Admin.Slider
{
    public class DeleteModel : PageModel
    {

        private ISliderService _sliderService;

        public DeleteModel(ISliderService sliderservice)
        {
            _sliderService = sliderservice;
        }

        [BindProperty]
        public DataLayer.Entities.Slider slider { get; set; }
        public void OnGet(int id)
        {
            slider = _sliderService.GetSliderById(id);
        }

        public IActionResult OnPost()
        {
            _sliderService.RemoveSlider(slider.SliderId);

            return RedirectToPage("Index");
        }
    }
}
