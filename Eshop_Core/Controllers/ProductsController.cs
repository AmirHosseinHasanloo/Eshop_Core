using DataLayer;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Eshop_Core.Controllers
{
    public class ProductsController : Controller
    {
        EshopContext _context;
        public ProductsController(EshopContext context)
        {
            _context = context;
        }
    }
}
