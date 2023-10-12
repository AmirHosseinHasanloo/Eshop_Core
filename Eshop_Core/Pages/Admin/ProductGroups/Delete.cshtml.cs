using System.Threading.Tasks;
using DataLayer.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Eshop_Core.Pages.Admin.ProductGroups
{
    public class DeleteModel : PageModel
    {
        private IProductGroupRepository _groupRepository;


        public DeleteModel(IProductGroupRepository groupRepository)
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
            _groupRepository.DeleteGroups(Groups.GroupId);
            return RedirectToPage("index");
        }
    }
}
