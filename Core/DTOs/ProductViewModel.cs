using DataLayer.Entities;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class ShowProductsOnAdminPanelViewModel
    {
        public Product Products { get; set; }
        public List<ProductGroup> ProductGroup { get; set; }
    }
   
}
