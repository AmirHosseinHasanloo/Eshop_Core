using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Interfaces
{
    public interface IProductGroupService
    {
        Task<List<ProductGroup>> GetAllGroupsAsync();
        ProductGroup GetById(int id);
        Task<bool> AddGroups(ProductGroup group);
        bool UpdateGroups(ProductGroup group);
        IEnumerable<ProductGroup> GetAllGroups();

        void DeleteGroups(int groupid);
    }
}
