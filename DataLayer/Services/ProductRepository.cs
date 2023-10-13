using DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Services
{
    public class ProductRepository : IProductRepository
    {
        EshopContext _context;

        public ProductRepository(EshopContext context)
        {
            _context = context;
        }

        public void AddProductSelectedGroups(int productid, List<int> groupid)
        {
            foreach (var group in groupid)
            {
                _context.SelectedGroups.Add(new Models.SelectedGroup()
                {
                    ProductId = productid,
                    GroupId = group,
                });
                _context.SaveChanges();
            }
        }

        public void AddProductTags(int productid, string tag)
        {
            if (string.IsNullOrEmpty(tag))
            {
                string[] Tags = tag.Split(',');

                foreach (string Tag in Tags)
                {
                    _context.ProductTags.Add(new Models.ProductTag
                    {
                        ProductId = productid,
                        Tag = Tag.Trim(),
                    });
                    _context.SaveChanges();
                }
            }
        }
    }
}
