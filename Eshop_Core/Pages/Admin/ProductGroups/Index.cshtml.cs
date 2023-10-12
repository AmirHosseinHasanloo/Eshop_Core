using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Eshop_Core.Pages.Admin.ProductGroups
{
    public class IndexModel : PageModel
    {
        private IProductGroupRepository _groupRepository;

        public IndexModel(IProductGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        [BindProperty]
        public IEnumerable<DataLayer.ProductGroup> Groups { get; set; }
        public async Task OnGetAsync()
        {
            Groups = await _groupRepository.GetAllGroupsAsync();
        }

    }
}
