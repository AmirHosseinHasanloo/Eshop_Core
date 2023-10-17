using Core.DTOs;
using DataLayer.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Interfaces
{
    public interface IProductRepository
    {
        void AddProductTags(int productid, string tag);
        void AddProductSelectedGroups(int productid, List<int> groupid);
        IEnumerable<Product> GetAll();
        IEnumerable<ProductGroup> GetAllProductGroups(int productid);
        void AddProduct(Product product, List<int> groups, string tags, IFormFile imagename);
        void UpdateProduct(Product product, List<int> groups, string tags, IFormFile imagename);
        void UpdateProductTags(int productid, string tag);
        void UpdateProductSelectedGroups(int productid, List<int> groupid);

        Product GetProductById(int productid);
        string GetTagsForShowingInEditProductOnAdmin(int productid);
    }
}
