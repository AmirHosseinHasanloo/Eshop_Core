using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Services.Interfaces;
using DataLayer;
using DataLayer.Entities;
using Eshop_Core.RoleChecker;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Eshop_Core.Pages.Admin.ProductGroups
{
    [RoleChecker(new int[] { 1 })]
    public class IndexModel : PageModel
    {
        private IProductGroupService _groupRepository;

        public IndexModel(IProductGroupService groupRepository)
        {
            _groupRepository = groupRepository;
        }

        [BindProperty]
        public IEnumerable<ProductGroup> Groups { get; set; }
        public async Task OnGetAsync()
        {
            Groups = await _groupRepository.GetAllGroupsAsync();
        }

    }
}
