using Core.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Eshop_Core.Pages.Admin.Slider
{
    public class EditModel : PageModel
    {
        private ISliderService _sliderService;

        public EditModel(ISliderService sliderservice)
        {
            _sliderService = sliderservice;
        }

        [BindProperty]
        public DataLayer.Entities.Slider slider { get; set; }

        public void OnGet(int id)
        {
            slider = _sliderService.GetSliderById(id);

            ViewData["endDate"] = slider.EndTime;
            ViewData["startDate"]= slider.StartDate;
        }

        public IActionResult OnPost(IFormFile slide)
        {
            if (!ModelState.IsValid)
                return Page();

            _sliderService.UpdateSlider(slider.SliderId, slide);

            return RedirectToPage("Index");
        }
    }
}
