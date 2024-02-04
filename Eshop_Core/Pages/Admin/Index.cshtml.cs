using DataLayer.Entities;
using Eshop_Core.RoleChecker;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Eshop_Core.Pages.Admin
{
    [RoleChecker(new int[] { 1, 2 })]
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
