using System.Threading.Tasks;
using DataLayer;
using DataLayer.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Eshop_Core.Pages.Admin.ProductGroups
{
    public class CreateModel : PageModel
    {
        private IProductGroupRepository _groupRepository;

        public CreateModel(IProductGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }


        [BindProperty]
        public DataLayer.ProductGroup Groups { get; set; }
        public void OnGet(int id)
        {
            if (id != 0)
            {
                Groups = new DataLayer.ProductGroup
                {
                    ParentId = id
                };
            }
        }



        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _groupRepository.AddGroups(Groups);
            return RedirectToPage("index");
        }
    }
}
