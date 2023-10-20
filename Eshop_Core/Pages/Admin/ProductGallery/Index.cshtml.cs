using Core.Services.Interfaces;
using DataLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Runtime.CompilerServices;

namespace Eshop_Core.Pages.Admin.ProductGallery
{
    public class IndexModel : PageModel
    {
        IProductRepository _ProductRepository;

        public IndexModel(IProductRepository ProductRepository)
        {
            _ProductRepository = ProductRepository;
        }

        [BindProperty]
        public DataLayer.Entities.ProductGallery Gallery { get; set; }

        // id ==> ProductId 
        public void OnGet(int id)
        {
            ViewData["ProductGalleries"] = _ProductRepository.GetProductGalleriesByProductId(id);
            Gallery = new DataLayer.Entities.ProductGallery()
            {
                ProductId = id
            };
        }


        public IActionResult OnPost(IFormFile ImageUP)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _ProductRepository.AddProductGallery(Gallery, ImageUP);

            return RedirectToPage("Index", new { id = Gallery.ProductId });
        }
    }
}
