using Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Eshop_Core.ViewComponents
{
    public class Last24ProductsComponent : ViewComponent
    {
        IProductService _ProductRepository;

        public Last24ProductsComponent(IProductService ProductRepository)
        {
            _ProductRepository = ProductRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("/Views/Components/Last24ProductComponent.cshtml", _ProductRepository.Get24OfNewProducts());
        }
    }
}
