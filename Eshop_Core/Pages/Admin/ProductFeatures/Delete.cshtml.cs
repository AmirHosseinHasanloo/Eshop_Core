using Core.Services.Interfaces;
using Eshop_Core.RoleChecker;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NuGet.Protocol.Core.Types;

namespace Eshop_Core.Pages.Admin.ProductFeatures
{
    [RoleChecker(new int[] { 1, 2 })]
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
