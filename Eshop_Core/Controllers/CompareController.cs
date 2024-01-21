﻿using Core.Services.Interfaces;
using DataLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace Eshop_Core.Controllers
{
    public class CompareController : Controller
    {

        private IFeaturesService _featureService;
        private IProductService _productService;

        public CompareController(IFeaturesService featuresService, IProductService productService)
        {
            _featureService = featuresService;
            _productService = productService;
        }

        public IActionResult Index()
        {
            List<Core.DTOs.CompareItemViewModel> compareList = new List<Core.DTOs.CompareItemViewModel>();

            if (HttpContext.Session.TryGetValue("Compare", out var compareData))
            {

                compareList = JsonSerializer.Deserialize<List<Core.DTOs.CompareItemViewModel>>(compareData);
            }

            List<DataLayer.Entities.Feature> feature = new List<Feature>();
            List<DataLayer.Entities.ProductFeature> productFeatures = new List<ProductFeature>();


            foreach (var item in compareList)
            {
                feature.AddRange(_featureService.GetAllFeatures());
                productFeatures.AddRange(_featureService.GetProductFeaturesByProductId(item.ProductId).Distinct());
            }

            ViewBag.Features = feature.Distinct().ToList();
            ViewBag.ProductFeatures = productFeatures.ToList();

            return View(compareList);
        }

        public IActionResult AddToCompareList(int id)
        {
            List<Core.DTOs.CompareItemViewModel> compareList = new List<Core.DTOs.CompareItemViewModel>();

            if (HttpContext.Session.TryGetValue("Compare", out var compareData))
            {
                compareList = JsonSerializer.Deserialize<List<Core.DTOs.CompareItemViewModel>>(compareData);
            }

            if (!compareList.Any(c => c.ProductId == id))
            {
                var product = _productService.GetCompareByProductId(id);

                compareList.Add(new Core.DTOs.CompareItemViewModel
                {
                    ProductId = id,
                    ImageName = product.ImageName,
                    ProductTitle = product.ProductTitle
                });
            }

            HttpContext.Session.Set("Compare", Encoding.UTF8.GetBytes(JsonSerializer.Serialize(compareList)));

            return PartialView("CompareList", compareList);
        }

        public IActionResult CompareList()
        {
            List<Core.DTOs.CompareItemViewModel> compareList = new List<Core.DTOs.CompareItemViewModel>();

            if (!HttpContext.Session.TryGetValue("Compare", out var compareData))
            {
                        compareList = JsonSerializer.Deserialize<List<Core.DTOs.CompareItemViewModel>>(compareData);
            }
            return PartialView(compareList);
        }

    }
}
