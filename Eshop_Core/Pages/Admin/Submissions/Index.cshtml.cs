using Core.DTOs;
using Core.Services.Interfaces;
using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace Eshop_Core.Pages.Admin.Submissions
{
    public class IndexModel : PageModel
    {
        private ISubmissionsService _SubService;

        public IndexModel(ISubmissionsService SubService)
        {
            _SubService = SubService;
        }
        [BindProperty]
        public List<SubmissionsProductsViewModel> order { get; set; }
        public void OnGet()
        {
            order = _SubService.GetUnSendedSubmissions();
        }
    }
}
