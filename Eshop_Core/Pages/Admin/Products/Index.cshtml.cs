using Core.DTOs;
using Core.Services.Interfaces;
using DataLayer.Entities;
using Eshop_Core.RoleChecker;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Eshop_Core.Pages.Admin.Products
{
    [RoleChecker(new int[] { 1, 2 })]
    public class IndexModel : PageModel
    {
        IProductService _productRepository;
        public IndexModel(IProductService productRepository)
        {
            _productRepository = productRepository;
        }

        [BindProperty]
        public IEnumerable<Product> Products { get; set; }
        public void OnGet()
        {
            Products = _productRepository.GetAll();
        }
    }
}
