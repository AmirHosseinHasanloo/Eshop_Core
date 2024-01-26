using Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Eshop_Core.ViewComponents
{
    public class SliderComponent : ViewComponent
    {
        private ISliderService _sliderService;

        public SliderComponent(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("/Views/Components/SliderComponent.cshtml", await _sliderService.GetSlidersForSlider());
        }

    }
}
