using Core.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;
using System;
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

        public IActionResult OnPost(IFormFile slide, string startDate = "", string endDate = "")
        {
            if (startDate != "")
            {
                string[] stDate = startDate.Split("/");

                slider.StartDate = new DateTime(int.Parse(stDate[0]), int.Parse(stDate[1]),
                    int.Parse(stDate[2]), new PersianCalendar());
            }

            if (endDate != "")
            {
                string[] enDate = endDate.Split("/");

                slider.EndTime = new DateTime(int.Parse(enDate[0]), int.Parse(enDate[1]),
                    int.Parse(enDate[2]), new PersianCalendar());
            }

            if (!ModelState.IsValid)
                return Page();

            _sliderService.AddSlider(slider, slide);

            return RedirectToPage("Index");
        }
    }
}
