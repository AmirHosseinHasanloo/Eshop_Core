using Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Eshop_Core.Pages.Admin.Submissions
{
    public class IsSendModel : PageModel
    {

        private ISubmissionsService _SubService;
        public IsSendModel(ISubmissionsService SubService)
        {
            _SubService = SubService;
        }
        public void OnGet(int id, bool send)
        {
            _SubService.ChangeOrderIsSendByForm(id, send);
        }
    }
}
