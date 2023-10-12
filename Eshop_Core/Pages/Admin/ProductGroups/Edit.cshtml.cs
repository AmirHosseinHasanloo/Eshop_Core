using System.Threading.Tasks;
using DataLayer;
using DataLayer.Repositories;
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
        public DataLayer.ProductGroup Groups { get; set; }
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
