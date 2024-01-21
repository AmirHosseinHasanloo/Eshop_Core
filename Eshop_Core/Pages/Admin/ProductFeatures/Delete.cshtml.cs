using Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NuGet.Protocol.Core.Types;

namespace Eshop_Core.Pages.Admin.ProductFeatures
{
    public class DeleteModel : PageModel
    {
        IProductService _Product;

        public DeleteModel(IProductService Product)
        {
            _Product = Product;
        }
        public void OnGet(int id)
        {
            var Delete = _Product.GetProductFeatureByid(id);
            _Product.DeleteFeature(Delete);
        }

    }
}
