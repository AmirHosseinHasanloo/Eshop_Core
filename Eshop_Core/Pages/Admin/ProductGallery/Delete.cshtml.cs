using Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Eshop_Core.Pages.Admin.ProductGallery
{
    public class DeleteModel : PageModel
    {
        IProductService _Product;

        public DeleteModel(IProductService Product)
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
