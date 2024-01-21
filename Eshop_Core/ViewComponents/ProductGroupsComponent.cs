using Core.Services.Interfaces;
using DataLayer;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Eshop_Core.ViewComponents
{
    public class ProductGroupsComponent : ViewComponent
    {
        IProductGroupService _groupservice;
        public ProductGroupsComponent(IProductGroupService groupservice)
        {
            _groupservice = groupservice;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var ProductGroups = _groupservice.GetAllGroups();
            return View("/Views/Components/ProductsGroupComponent.cshtml", ProductGroups);
        }
    }
}
