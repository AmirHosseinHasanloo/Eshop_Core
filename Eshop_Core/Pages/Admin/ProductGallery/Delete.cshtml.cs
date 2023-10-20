using Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Eshop_Core.Pages.Admin.ProductGallery
{
    public class DeleteModel : PageModel
    {
        IProductRepository _Product;

        public DeleteModel(IProductRepository Product)
        {
            _Product = Product;
        }

        // id ==> Gallery id
        public void OnGet(int id)
        {
            _Product.DeleteProductGallery(id);
        }
    }
}
