using Core.Services.Interfaces;
using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace Eshop_Core.Pages.Admin.Submissions
{
    public class DetailModel : PageModel
    {
        private ISubmissionsService _SubService;
        public DetailModel(ISubmissionsService SubService)
        {
            _SubService = SubService;
        }

        [BindProperty]
        public List<OrderDetail> OrderDetails { get; set; }

        public void OnGet(int id)
        {
            ViewData["OrderId"] = id;
            OrderDetails = _SubService.GetOrderDetailByOrderId(id);
        }

        [HttpPost]
        public IActionResult OnPost(int id, bool isSend)
        {

            _SubService.ChangeOrderIsSendByForm(id, isSend);

            return null;
        }
    }
}
