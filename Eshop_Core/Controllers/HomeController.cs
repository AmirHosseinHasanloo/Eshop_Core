using Eshop_Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Eshop_Core.ViewComponents;
using Core.Services.Interfaces;
namespace Eshop_Core.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ISliderService _sliderService;

        public HomeController(ILogger<HomeController> logger, ISliderService sliderService)
        {
            _logger = logger;
            _sliderService = sliderService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
