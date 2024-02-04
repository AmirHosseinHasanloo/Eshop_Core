using System.Threading.Tasks;
using Core.Services.Interfaces;
using DataLayer.Entities;
using Eshop_Core.RoleChecker;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Eshop_Core.Pages.Admin.ProductGroups
{
    [RoleChecker(new int[] { 1 })]
    public class DeleteModel : PageModel
    {
        private IProductGroupService _groupRepository;


        public DeleteModel(IProductGroupService groupRepository)
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
            _groupRepository.DeleteGroups(Groups.GroupId);
            return RedirectToPage("index");
        }
    }
}
