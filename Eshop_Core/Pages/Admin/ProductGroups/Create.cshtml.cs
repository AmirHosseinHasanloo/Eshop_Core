using System.Threading.Tasks;
using Core.Services.Interfaces;
using DataLayer;
using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Eshop_Core.Pages.Admin.ProductGroups
{
    public class CreateModel : PageModel
    {
        private IProductGroupService _groupRepository;

        public CreateModel(IProductGroupService groupRepository)
        {
            _groupRepository = groupRepository;
        }


        [BindProperty]
        public ProductGroup Groups { get; set; }
        public void OnGet(int id)
        {
            if (id != 0)
            {
                Groups = new ProductGroup
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
