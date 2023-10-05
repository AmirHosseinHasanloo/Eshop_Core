using DataLayer;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Eshop_Core.ViewComponents
{
    public class ProductGroupsComponent : ViewComponent
    {
        UnitOfWork _db;
        public ProductGroupsComponent(EshopContext context)
        {
            _db = new UnitOfWork(context);
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var ProductGroups = _db.ProductGroupsRepository.GetAll();
            return View("/Views/Components/ProductsGroupComponent.cshtml", ProductGroups);
        }
    }
}
