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
        void AddProduct(Product product, List<int> groups, string tags, IFormFile imagename);

        #region Admin Panel

        #endregion
    }
}
