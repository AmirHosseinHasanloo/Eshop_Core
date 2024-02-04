using Core.Convertors;
using Core.Services.Interfaces;
using Eshop_Core.RoleChecker;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Globalization;

namespace Eshop_Core.Pages.Admin.Slider
{
    [RoleChecker(new int[] { 1 })]
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
        }

        public IActionResult OnPost(IFormFile slide, bool IsActive, string startDate = "", string endDate = "")
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

            slider.IsSliderActive = IsActive;

            _sliderService.UpdateSlider(slider, slide);

            return RedirectToPage("Index");
        }
    }
}
