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
    public class ProductFeaturesViewModel
    {
        public string FeatureTitle { get; set; }
        public List<string> Values { get; set; }
    }

    public class FilterProductViewModel
    {
        public List<Product> Products { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
    }

    public class CompareItemViewModel
    {
        public int ProductId { get; set; }
        public string ProductTitle { get; set; }
        public string ImageName { get; set; }
    }
}
