using Core.DTOs;
using Core.Generators;
using DataLayer;
using DataLayer.Entities;
using Microsoft.AspNetCore.Http;
using NuGet.Packaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Interfaces
{
    public class ProductRepository : IProductRepository
    {
        EshopContext _context;

        public ProductRepository(EshopContext context)
        {
            _context = context;
        }

        public void AddProduct(Product product, List<int> groups, string tags, IFormFile imagename)
        {
            if (imagename != null)
            {
                string path = "";
                if (imagename.FileName != "no-image.png")
                {
                    product.ImageName = NameGenerator.Generate() + Path.GetExtension(imagename.FileName);
                    path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ProductImage", product.ImageName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        imagename.CopyTo(stream);
                    }
                }
            }
            product.CreateDate = DateTime.Now;
            _context.Add(product);
            _context.SaveChanges();
            // insert selected group
            AddProductSelectedGroups(product.ProductId, groups);

            // insert tags
            AddProductTags(product.ProductId, tags);

        }

        public void AddProductSelectedGroups(int productid, List<int> groupid)
        {
            foreach (var group in groupid)
            {
                _context.SelectedGroups.Add(new SelectedGroup()
                {
                    ProductId = productid,
                    GroupId = group,
                });
                _context.SaveChanges();
            }
        }

        public void AddProductTags(int productid, string tag)
        {
            if (!string.IsNullOrEmpty(tag))
            {
                string[] Tags = tag.Split(',');

                foreach (string Tag in Tags)
                {
                    _context.ProductTags.Add(new ProductTag
                    {
                        ProductId = productid,
                        Tag = Tag.Trim(),
                    });
                }
                _context.SaveChanges();
            }
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        #region Admin Panel

       

        #endregion
    }
}