using System.Threading.Tasks;
using Core.Services.Interfaces;
using DataLayer;
using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Eshop_Core.Pages.Admin.ProductGroups
{
    public class EditModel : PageModel
    {
        private IProductGroupRepository _groupRepository;


        public EditModel(IProductGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }


        public void OnGet(int id)
        {
            Groups = _groupRepository.GetById(id);
        }

        [BindProperty]
        public ProductGroup Groups { get; set; }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _groupRepository.UpdateGroups(Groups);

            return RedirectToPage("Index");
        }

    }
}
